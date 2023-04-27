using MapEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;

namespace Game
{
    public class CellView : BlockView, IPointerClickHandler
    {

        public event Action OnCellClicked;

        public void OnPointerClick(PointerEventData eventData)
        {
            OnCellClicked?.Invoke();
        }
        public virtual void UpdateView(Cell cell)
        {

        }
    }
}

