
namespace MapEditor
{
    public interface IMapPanelModel
    {
        public void LineBlockClicked();
        public void StationBlockClicked();
        public void SaveMap(string name);
    }
}