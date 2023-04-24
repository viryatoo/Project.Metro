using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;

namespace Game
{
    public class CellView : MonoBehaviour, IPointerClickHandler
    {
        private SpriteRenderer spriteRenderer;

        [Inject]
        public void Construct(Cell cellModel)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            spriteRenderer.color = Color.red;
        }
    }
}

