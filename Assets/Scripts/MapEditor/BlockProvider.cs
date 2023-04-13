﻿
using Unity.VisualScripting;

namespace MapEditor
{
    //связующий класс между маделью какой блок выбрали и фабрикой.
    public class BlockProvider
    {
        private MainPanelModel modelPanel;
        private BlockFactory factory;
        public BlockProvider(MainPanelModel model,BlockFactory fact)
        { 
            modelPanel = model;
            factory = fact;
        }
        //просим фабрику выдать нам блок на который кликнул игрок
        public BlockView GetView()
        {
            return factory.Get(modelPanel.GetSelectedBlock());
        }
        //аналогично с датой для блока.
        public BlockData GetData()
        {
            BlockData blockData = new BlockData();
            switch (modelPanel.GetSelectedBlock())
            {
                case BlockType.Noone:
                    blockData.type = BlockType.Noone;
                    blockData.variant = 0;
                    break;
                case BlockType.Line:
                    blockData.type = BlockType.Line;
                    blockData.variant = 0;
                    break;
                case BlockType.Staion:
                    blockData.type = BlockType.Staion;
                    blockData.variant = 0;
                    break;
            }
            return blockData;
        }
    }
}