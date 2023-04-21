using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
namespace MapEditor
{
    //вьюшка боковой панели. отвечает ТОЛЬКО за ОТОБРАЖЕНИЕ и ПЕРЕДАЧИ команд\действий модели
    public class MainPanelView : MonoBehaviour
    {

        private IMapPanelModel uimodel;

        [SerializeField] private Button StationBlock;
        [SerializeField] private Button LinesBlock;
        [SerializeField] private Button SaveMap;
        [SerializeField] private InputField mapSaverName;

        [Inject]
        public void Construct(IMapPanelModel model)
        {
            uimodel = model;
            StationBlock.onClick.AddListener(StationBlockClicked);
            LinesBlock.onClick.AddListener(LineBlockClicked);
            SaveMap.onClick.AddListener(SaveMapCliced);
            Logger.Log(nameof(MainPanelView), "Bind done!");

        }

        public void Locked(bool status)
        {
            StationBlock.interactable = status;
            LinesBlock.interactable = status;
        }
        private void StationBlockClicked()
        {
            uimodel.StationBlockClicked();
        }
        private void LineBlockClicked()
        {
            uimodel.LineBlockClicked();
        }
        private void SaveMapCliced()
        {
            uimodel.SaveMap(mapSaverName.text);
        }
        


    }
}
