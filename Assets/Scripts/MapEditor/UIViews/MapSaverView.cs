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
    public class MapSaverView: MonoBehaviour
    {
        [SerializeField] Dropdown dropdown;

        public MapSaverModel uiModel;

        [Inject]
        public void Init(MapSaverModel saverModel)
        {
            uiModel = saverModel;
        }

    }
}
