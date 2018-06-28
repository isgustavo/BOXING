using ODT.UI.Util;
using UnityEngine;

namespace ADT.Boxing
{
    public interface IAcceptable
    {
        void OnFallbackEvent();
    }

    public class MoveBehaviour : MonoBehaviour, IAcceptable
    {

        [SerializeField]
        private float speedMoviment = 20f;
        [SerializeField]
        private float fallBackMoviment = 35f;

        [Header("Other Player")]
        public Transform otherPlayerTransform; // temp 
        [SerializeField]
        private bool isPlayer2 = true; // temp

        private bool isFlip = false;

        private void Update()
        {
            if (transform.position.y >= otherPlayerTransform.position.y && !isFlip)
            {
                transform.Rotate(Vector3.up, 180f);
                isFlip = true;
            }
            else if(transform.position.y < otherPlayerTransform.position.y && isFlip)
            {
                transform.Rotate(Vector3.up, 180f);
                isFlip = false;
            }

            if (isPlayer2)
            {
                return;
            }

            Vector3 movement = new Vector2(
                    UIVirtualInput.GetInput(UIVirtualJoystickBehaviour.VIRTUAL_JOYSTICK_VERTICAL_VALUE) * (isFlip ? -1f : 1f), 
                    -UIVirtualInput.GetInput(UIVirtualJoystickBehaviour.VIRTUAL_JOYSTICK_HORIZONTAL_VALUE));

            transform.Translate(movement.normalized * speedMoviment * Time.deltaTime);
        }

        public void OnFallbackEvent()
        {
            transform.Translate(transform.up * fallBackMoviment * Time.deltaTime);
        }
    }
}
