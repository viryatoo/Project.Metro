using GameAssets;
using MapEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Game
{
    public class CellViewFactory : IBlockFactory<CellView>
    {
        private CellFactoryData factoryData;
        private Vector3 position;
        public CellViewFactory(GameContentProvider provider)
        {
            factoryData = provider.CellFactoryData;
        }
        public IBlockFactory<CellView> InPosition(Vector3 pos)
        {
            position = pos;
            return this;
        }
        public CellView Create(BlockType type)
        {
            switch (type)
            {
                case BlockType.Line:
                    var obj = UnityEngine.Object.Instantiate(factoryData.Line);
                    obj.Init();
                    obj.transform.position = position;
                    return obj;
                case BlockType.Staion:
                    obj = UnityEngine.Object.Instantiate(factoryData.Station);
                    obj.transform.position = position;
                    obj.Init();
                    return obj;
                case BlockType.Noone:
                    return null;
            }
            position = Vector3.zero;
            return null;
        }
    }
}

