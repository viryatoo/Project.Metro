//Простые типы данных которые используются для сохранения в файл.


namespace MapEditor
{
    public struct BlockData
    {
        public Positon positon;
        public BlockType type;
        public int variant;
        
    };
    public struct Positon
    {
        public int x;
        public int y;
        public Positon(int xx,int yy)
        {
            x = xx; y=yy;
        }
    }
}