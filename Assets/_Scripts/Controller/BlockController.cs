using _Scripts.Base;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Scripts.Controller
{
    public class BlockController : MonoBehaviour, IRotation, IPointerClickHandler
    {
        [SerializeField] private float angle = 90;
        public void Rotate(float value)
        {
            this.transform.DORotate(transform.eulerAngles + new Vector3(0,0, angle), 0.5f, RotateMode.FastBeyond360).SetEase(Ease.Linear);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Rotate(angle);
        }
    }
}
