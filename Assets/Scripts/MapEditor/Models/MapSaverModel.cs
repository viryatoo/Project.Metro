using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MapEditor
{
    //логика загрузки сейвов. До конца не доделал.
    public class MapSaverModel : IMapSaverModel
    {
        private Map gameMap;
        private string savesDirectory;
        public MapSaverModel(Map map, MapEditorContentProvider contentProvider)
        {
            gameMap = map;
            savesDirectory = contentProvider.GetDirectorySaves();

        }

        public List<Dropdown.OptionData> GetAllSaveFilesForView()
        {
            string[] Directoryfiles = Directory.GetFiles(savesDirectory, "*.json");
            List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();

            foreach (var name in Directoryfiles)
            {
                string nameData = name.Replace(savesDirectory, "");
                options.Add(new Dropdown.OptionData(nameData));
            }
            return options;
        }

        public void LoadSave(Dropdown.OptionData data)
        {
            gameMap.LoadMap(data.text);
        }
    }
}