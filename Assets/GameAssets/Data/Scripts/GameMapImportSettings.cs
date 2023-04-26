using MapEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameAssets
{
    [CreateAssetMenu(fileName = "GameMapImportSettings", menuName = "Data/Game/MapImportSettings")]
    public class GameMapImportSettings : ScriptableObject
    {
        [SerializeField] private string FolderWithMaps = "/GameContent/";
        
        public string GetDirectorySaves()
        {
            return Application.dataPath + FolderWithMaps;
        }

        public MapEditorContentProvider mapEditorContentProvider;
        public string Format = ".json";
    }
}
