using UnityEngine;
using VContainer;

namespace MapEditor
{
    //корневой класс UI редактора. Сюда писать какие-либо глобальные вещи.
    public class UiEditor : MonoBehaviour
    {
        [SerializeField] private MainPanelView mainPanelView;

        public void LockedPanel(bool status)
        {
            mainPanelView.Locked(!status);
        }
    }
}