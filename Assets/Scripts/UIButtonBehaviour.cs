using UnityEngine;
using UnityEngine.EventSystems;

namespace ODT.UI.Util
{
    public abstract class UIButtonBehaviour : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        [Header("Button Transforms")]
        [SerializeField]
        protected Transform handleTransform;

        public abstract string Input();

        private void OnEnable()
        {
            UIVirtualInput.AddInput(Input(), 0);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            handleTransform.position = eventData.position;
            handleTransform.localScale = new Vector3(.9f, .9f, .9f);
            UIVirtualInput.UpdateInput(Input(), 1);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            handleTransform.localScale = new Vector3(1f, 1f, 1f);
            UIVirtualInput.UpdateInput(Input(), 0);
        }
    }
}
