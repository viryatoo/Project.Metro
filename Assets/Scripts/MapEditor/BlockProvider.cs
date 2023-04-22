
using Unity.VisualScripting;

namespace MapEditor
{
    //связующий класс между маделью какой блок выбрали и фабрикой.
    public class BlockProvider
    {
        private IMapPanelModel modelPanel;
        private BlockFactory factory;
        public BlockProvider(IMapPanelModel model,BlockFactory fact)
        { 
            modelPanel = model;
            factory = fact;
        }
        //просим фабрику выдать нам блок на который кликнул игрок
        public BlockView GetView()
        {
            return factory.Create(modelPanel.GetSelectedBlock());
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