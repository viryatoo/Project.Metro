using System.Collections;
using UnityEngine;

namespace MapEditor
{
    //обычная вьюшка блока.
    public class BlockView : MonoBehaviour
    {
        public bool NeighborUp;
        public bool NeighborDown;
        public bool NeighborLeft;
        public bool NeighborRight;

        [SerializeField] private bool DependencyFromNeighbors;
        [SerializeField] private Sprite spriteVertical;
        [SerializeField] private Sprite spriteHorizontal;
        [SerializeField] private Sprite spriteConstation;
        [SerializeField] private Sprite spriteRotation;
        [SerializeField] private Sprite spriteFreeConntact;

        private SpriteRenderer spriteRenderer;
        public void Init()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        //считаем соседей и выставляем правильный спрайт.
        public void ColculateView()
        {
            if (DependencyFromNeighbors)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                if (NeighborUp || NeighborDown && !NeighborLeft && !NeighborRight)
                {
                    spriteRenderer.sprite = spriteVertical;
                }
                if (NeighborLeft || NeighborRight && !NeighborUp && !NeighborDown)
                {
                    spriteRenderer.sprite = spriteHorizontal;
                }
                if (NeighborRight && NeighborLeft && NeighborUp && NeighborDown)
                {
                    spriteRenderer.sprite = spriteConstation;
                }
                if (NeighborDown && NeighborRight && !NeighborLeft && !NeighborUp)
                {
                    spriteRenderer.sprite = spriteRotation;
                }
                if (NeighborLeft && NeighborDown && !NeighborRight && !NeighborUp)
                {
                    spriteRenderer.sprite = spriteRotation;
                    transform.localRotation = Quaternion.Euler(0, 0, -90);
                }
                if (NeighborLeft && NeighborUp && !NeighborRight && !NeighborDown)
                {
                    spriteRenderer.sprite = spriteRotation;
                    transform.localRotation = Quaternion.Euler(0, 0, -180);
                }
                if (NeighborRight && NeighborUp && !NeighborDown && !NeighborLeft)
                {
                    spriteRenderer.sprite = spriteRotation;
                    transform.localRotation = Quaternion.Euler(0, 0, -270);
                }
                if (NeighborLeft && NeighborRight && NeighborUp && !NeighborDown)
                {
                    spriteRenderer.sprite = spriteFreeConntact;
                }
                if (NeighborDown && NeighborRight && NeighborUp && !NeighborLeft)
                {
                    spriteRenderer.sprite = spriteFreeConntact;
                    transform.localRotation = Quaternion.Euler(0, 0, -90);
                }
                if (NeighborDown && NeighborRight && NeighborLeft && !NeighborUp)
                {
                    spriteRenderer.sprite = spriteFreeConntact;
                    transform.localRotation = Quaternion.Euler(0, 0, -180);
                }
                if (NeighborDown && NeighborUp && NeighborLeft && !NeighborRight)
                {
                    spriteRenderer.sprite = spriteFreeConntact;
                    transform.localRotation = Quaternion.Euler(0, 0, -270);
                }
            }

        }
    }
}