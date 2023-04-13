using UnityEngine;
using VContainer;

namespace MapEditor
{
    //корневой класс UI редактора. Сюда писать какие-либо глобальные вещи.
    public class UiEditor : MonoBehaviour
    {
        [SerializeField] private MainPanelView mainPanel;

        [Inject]
        public void Init(MainPanelModel panelModel)
        {
            mainPanel.Init(panelModel);
        }

        public void LockedPanel(bool status)
        {
            mainPanel.Locked(!status);
        }
    }
}