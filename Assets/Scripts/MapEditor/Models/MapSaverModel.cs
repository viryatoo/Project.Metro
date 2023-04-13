using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MapEditor
{
    //логика загрузки сейвов. До конца не доделал.
    public class MapSaverModel
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
            string[] Directoryfiles = Directory.GetFiles(savesDirectory, ".json");
            string[] filesName = Directoryfiles.Where(file => { file = file.Replace(savesDirectory, ""); return true; }).ToArray();

            List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();

            foreach (string file in filesName)
            {
                options.Add(new Dropdown.OptionData(file));
            }
            return options;
        }
    }
}