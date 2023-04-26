using MapEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;

namespace Game
{
    public class CellView : BlockView, IPointerClickHandler
    {

        public void OnPointerClick(PointerEventData eventData)
        {
            spriteRenderer.color = Color.red;
        }
    }
}

