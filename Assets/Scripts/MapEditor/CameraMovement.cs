using MapEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapEditor
{
    //отвечает за перемещение камеры.
    public class CameraMovement
    {

        private bool isMouseButtonPressed;
        private Rect gameArea;//игровая область за которую нельзя выходить.
        private Camera gameCamera;
        private float sensitivity;
        private Map map;
        public CameraMovement(MapEditorContentProvider contentProvider,Map gameMap)
        {
           
            gameCamera = Camera.main;
            sensitivity = contentProvider.CameraSensivitity;
            map = gameMap;
            CalculateBounds();
        }

        public void UpdateArea()
        {
            gameArea = new Rect(0, 0, map.Size, map.Size);
        }

        public void UpdateCamera()
        {
            if(Input.GetMouseButtonDown(2))
            {
                isMouseButtonPressed = true;
            }
            if(Input.GetMouseButtonUp(2))
            {
                isMouseButtonPressed = false;
            }

            if(isMouseButtonPressed)
            {
                Vector3 pos = new Vector3(Input.GetAxis("Mouse X"),Input.GetAxis("Mouse Y"),0) * -1*sensitivity;
                gameCamera.transform.Translate(pos);
                CalculateBounds();
                
            }
        }
        //Проверяем не вышла ли камера за пределы игровой зоны, если вышла то стараемся вернуть на прошлую позицию.
        private void CalculateBounds()
        {
            Vector3 pos0 = gameCamera.ScreenToWorldPoint(Vector3.zero);
            Vector3 pos1 = gameCamera.ScreenToWorldPoint(new Vector3(gameCamera.pixelWidth,gameCamera.pixelHeight));

            Vector3 offset = Vector3.zero;
            if(pos0.x<gameArea.xMin)
            {
                offset.x = gameArea.xMin-pos0.x;
            }
            else if(pos1.x>gameArea.xMax)
            {
                offset.x = gameArea.xMax-pos1.x;
            }
            if(pos0.y<gameArea.yMin)
            {
                offset.y = gameArea.yMin-pos0.y;
            }
            else if(pos1.y>gameArea.yMax)
            {
                offset.y = gameArea.yMax-pos1.y;
            }

            if(offset!=Vector3.zero)
            {
                gameCamera.transform.position = gameCamera.transform.position+offset;
            }

        }


    }
}
