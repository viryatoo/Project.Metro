using MapEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Defective;
using Defective.JSON;
using System.IO;
//Реализация сохранения\загузки
public class JsonSL : ISaveSevice
{
    private const string BlockPositionName = "P";
    private const string BlockTypeName = "BT";
    private const string BlockVariantName = "V";
    private const string MapSize = "Size";
    private const string EditorVersion = "Editor version";
    private const string MapData = "MapData";
    private string MapEditorVersion;

    public GeometryMap Load(string path)
    {

        GeometryMap geometryMap = new GeometryMap();
        BlockData[,] bd;

        string file = File.ReadAllText(path);
        JSONObject json = new JSONObject(file);


        int size = json[MapSize].intValue;


        bd = new BlockData[size, size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                BlockData bdd = new BlockData();
                bdd.positon = new Positon(i, j);
                bdd.type = BlockType.Noone;
                bdd.variant = 0;
                bd[i, j] = bdd;
            }
        }

        JSONObject mapData = json[MapData];


        foreach (var jdata in mapData)
        {
            BlockData data = jsonToData(jdata);
            bd[data.positon.x, data.positon.y] = data;
        }
        geometryMap.MapEditorVersion = "ALPHA";
        geometryMap.MapSize = size;
        geometryMap.blocks = bd;

        return geometryMap;
    }

    public void Save(BlockData[,] data, string directory, string name,int size)
    {
        int id = 0;
        JSONObject json = new JSONObject();
        BlockData[] b = ToArray(data);
        foreach (BlockData bd in b)
        {
            if (bd.type != BlockType.Noone)
            {
                json.AddField(id.ToString(), dataToJson(bd));
            }
            id++;
        }
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        JSONObject geometryMap = new JSONObject();

        geometryMap.AddField(MapSize, size);
        geometryMap.AddField(EditorVersion, "ALPHA");
        geometryMap.AddField(MapData,json);

        File.WriteAllText(directory + name, geometryMap.ToString(true));
    }

    private BlockData[] ToArray(BlockData[,] data)
    {
        List<BlockData> list = new List<BlockData>();
        foreach (var item in data)
        {
            list.Add(item);
        }
        return list.ToArray();
    }

    private JSONObject dataToJson(BlockData data)
    {
        JSONObject jSONObject = new JSONObject();
        jSONObject.AddField(
            BlockPositionName, pos =>
            {
                pos.AddField("X", data.positon.x);
                pos.AddField("Y", data.positon.y);
            }
            );
        jSONObject.AddField(BlockTypeName, (int)data.type);
        jSONObject.AddField(BlockVariantName, data.variant);
        return jSONObject;
    }

    private BlockData jsonToData(JSONObject json)
    {
        BlockData data = new BlockData();
        data.positon.x = json[BlockPositionName]["X"].intValue;
        data.positon.y = json[BlockPositionName]["Y"].intValue;
        data.type = (BlockType)json[BlockTypeName].intValue;
        data.variant = json[BlockVariantName].intValue;
        return data;
    }

}
