using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapEditor
{
    [CreateAssetMenu(fileName ="EditorContentProvider",menuName ="Data/MapEditor/ContentProvider")]
    public class MapEditorContentProvider : ScriptableObject
    {
        public float CameraSensivitity;
        public string SaveFolder = "/GameContent/";
        public BlockFactoryData blockFactoryData;
        public UiEditor uiEditor;
        public MapBorderView borderView;
        public string GetDirectorySaves()
        {
           return Application.dataPath + SaveFolder;
        }
    }
}

