﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

namespace MapEditor
{
    //класс игровой карты содержит все данные где и какие блоки расположены
    //Имеет методы для удобной работы с картой. Такие как: Создать карту, поставить\убрать блок, 
    //Проверить есть ли блок в какой-либо позиции и методы загрузки\сохранения данных
    public class Map
    {
        public Action<BlockData[,]> MapUpdated;
        public int Size { get; private set; }

        private string saveDirectory;

        private BlockData[,] blockData;
        private BlockView[,] view;
        private ISaveSevice SaveLoader;
        private MapBorderView mapBorderView;
        private ContentLoader loader;
        public Map(ISaveSevice service, MapEditorContentProvider contentProvider, ContentLoader contentLoader)
        {
            SaveLoader = service;
            loader = contentLoader;
            saveDirectory = contentProvider.GetDirectorySaves();
            mapBorderView = contentLoader.LoadBorder();
        }

        public bool SetBlock(BlockData b, BlockView bv)
        {
            if (InSize(b.positon.x, b.positon.y))
            {
                if (!HasBlock(b.positon.x, b.positon.y))
                {
                    blockData[b.positon.x, b.positon.y] = b;
                    view[b.positon.x, b.positon.y] = bv;
                    CalculateNeighbors(b.positon.x, b.positon.y);
                    MapUpdated?.Invoke(blockData);
                    return true;
                }

            }
            return false;
        }
        public void RemoveBlock(int posX, int posY)
        {
            if (HasBlock(posX, posY))
            {
                Logger.Log("State: wait input", $"Block remove in pos:({posX},{posY})");
                blockData[posX, posY].type = BlockType.Noone;
                UnityEngine.Object.Destroy(view[posX, posY].gameObject);
                MapUpdated?.Invoke(blockData);
            }


        }
        public void CreateMap(int size)
        {
            Size = size;
            blockData = new BlockData[size, size];
            view = new BlockView[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    BlockData bd = new BlockData();
                    bd.positon = new Positon(i, j);
                    bd.type = BlockType.Noone;
                    bd.variant = 0;
                    blockData[i, j] = bd;
                }
            }
            mapBorderView.GenerateBorder(size);
        }
        public bool HasBlock(int posX, int posY)
        {
            if (InSize(posX, posY))
            {
                return blockData[posX, posY].type != BlockType.Noone && view[posX, posY] != null;
            }
            return false;

        }

        public void SaveMap(string name)
        {
            SaveLoader.Save(blockData, saveDirectory, name);
        }

        public void LoadMap(string name)
        {
            ClearMap();
            CreateMap(32);
            BlockData[,] data = SaveLoader.Load(saveDirectory + name);
            blockData = data;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (blockData[i, j].type != BlockType.Noone)
                    {
                        view[i, j] = loader.GameBlockFactory.InPosition(new Vector3(i, j, 0)).Create(blockData[i, j].type);
                        CalculateNeighbors(i, j);
                    }
                }
            }
        }

        public void ClearMap()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (HasBlock(i, j))
                    {
                        UnityEngine.Object.Destroy(view[i, j].gameObject);
                    }


                }
            }
            blockData = new BlockData[0, 0];
            Size = 0;
        }


        private bool InSize(int x, int y)
        {
            return (x >= 0 & x < Size & y >= 0 & y < Size);
        }
        private void CalculateNeighbors(int posX, int posY)
        {
            if (HasBlock(posX - 1, posY))
            {
                view[posX - 1, posY].NeighborRight = true;
                view[posX, posY].NeighborLeft = true;
                view[posX - 1, posY].ColculateView();
                view[posX, posY].ColculateView();
            }
            if (HasBlock(posX + 1, posY))
            {
                view[posX + 1, posY].NeighborLeft = true;
                view[posX, posY].NeighborRight = true;
                view[posX + 1, posY].ColculateView();
                view[posX, posY].ColculateView();
            }
            if (HasBlock(posX, posY - 1))
            {
                view[posX, posY - 1].NeighborUp = true;
                view[posX, posY].NeighborDown = true;
                view[posX, posY - 1].ColculateView();
                view[posX, posY].ColculateView();
            }
            if (HasBlock(posX, posY + 1))
            {
                view[posX, posY + 1].NeighborDown = true;
                view[posX, posY].NeighborUp = true;
                view[posX, posY + 1].ColculateView();
                view[posX, posY].ColculateView();
            }
        }


    }
}