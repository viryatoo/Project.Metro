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
        [SerializeField] private TMP_Text armyText;

        public event Action cellClicked;

        public void OnPointerClick(PointerEventData eventData)
        {
            cellClicked?.Invoke();
        }
    }
}

