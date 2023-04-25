using Game;
using GameAssets;
using MapEditor;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

public class GameMapImporter
{
    private ISaveSevice saveLoadService;
    private Dictionary<string, string> findedMaps;
    private GameMapImportSettings importSettings;

    public GameMapImporter(ISaveSevice saveSevice,GameMapImportSettings settings)
    {
        saveLoadService = saveSevice;
        findedMaps = new Dictionary<string, string>();
        importSettings = settings;
    }
    public void UpdateMapDirecory()
    {
        string savesDirectory = importSettings.GetDirectorySaves();
        string[] Directoryfiles = Directory.GetFiles(savesDirectory, "*.json");

        foreach (var name in Directoryfiles)
        {
            string nameData = name.Replace(savesDirectory, "");
            nameData = nameData.Replace(".json","");
            findedMaps[nameData] = name;
        }
    }
    /*
     
    public GameMap Import(string name)
    {
        CellUpdater updater = new CellUpdater();
        Map geometryMap = new Map();
    }

     
     */
}