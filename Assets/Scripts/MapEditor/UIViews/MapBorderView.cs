using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace MapEditor
{
    //Вьюшка границы карты. Отвечает за её генерацию.
    public class MapBorderView : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;

        public void GenerateBorder(int mapSize)
        {
            Vector3[] border = new Vector3[]
            {
                new Vector3(0-0.5f,0-0.5f,0),
                new Vector3(0-0.5f,mapSize+0.5f,0),
                new Vector3(mapSize-0.5f,mapSize+0.5f,0),
                new Vector3(mapSize-0.5f,0-0.5f,0)
            };

            lineRenderer.SetPositions(border);
        }
    }
}
