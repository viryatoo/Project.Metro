using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace MapEditor
{
    //вьюшка панели сохранения. Не дописана.
    public class MapSaverView : MonoBehaviour
    {
        [SerializeField] private Dropdown dropdown;
        [SerializeField] private Button buttonLoadSave;
        [SerializeField] private Button buttonReimportSaves;
        private IMapSaverModel uiModel;

        [Inject]
        public void Construct(IMapSaverModel saverModel)
        {
            uiModel = saverModel;
            buttonReimportSaves.onClick.AddListener(BtnReimportSaveHandler);
            buttonLoadSave.onClick.AddListener(BtnLoadSaveHandler);
            dropdown.ClearOptions();
            dropdown.AddOptions(uiModel.GetAllSaveFilesForView());
        }


        private void BtnLoadSaveHandler()
        {
            uiModel.LoadSave(dropdown.options[dropdown.value]);
        }
        private void BtnReimportSaveHandler()
        {
            dropdown.ClearOptions();
            dropdown.AddOptions(uiModel.GetAllSaveFilesForView());
        }

    }
}
