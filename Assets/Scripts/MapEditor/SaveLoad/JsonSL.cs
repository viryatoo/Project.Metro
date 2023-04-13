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

    public BlockData[,] Load(string path)
    {
        string file = File.ReadAllText(path);
        JSONObject json = new JSONObject(file);
        BlockData[,] bd;
        bd = new BlockData[32,32];
        foreach(var jdata in json)
        {
            BlockData data = jsonToData(jdata);
            bd[data.positon.x,data.positon.y] = data;
        }
        return bd;
    }

    public void Save(BlockData[,] data, string directory, string name)
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
        if(!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        File.WriteAllText(directory+name, json.ToString(true));
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
