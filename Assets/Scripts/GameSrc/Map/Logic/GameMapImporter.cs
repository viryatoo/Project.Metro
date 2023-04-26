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
    private ContentLoader contentLoader;

    public GameMapImporter(ISaveSevice saveSevice,GameMapImportSettings settings,ContentLoader loader)
    {
        saveLoadService = saveSevice;
        findedMaps = new Dictionary<string, string>();
        importSettings = settings;
        contentLoader = loader;
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
     
    public GameMap Import(string name)
    {
        CellUpdater updater = new CellUpdater();
        CellPool pool = updater.CreatePool();
        Map geometryMap = new Map(saveLoadService,importSettings.mapEditorContentProvider,contentLoader);
        geometryMap.AddWrapperLoader(new WrapperMapLoader(updater, pool));
        geometryMap.LoadMap(name+importSettings.Format);

        return new GameMap(geometryMap, updater);
    }
}