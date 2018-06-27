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
        private bool isNPC = true;
        [SerializeField]
        private float speedMoviment = 20f;

        private Rigidbody2D rb2d;


        //private bool isFallback = false;

        private void OnEnable()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            //if (isFallback)
            //{
            //    return;
            //}
            if (isNPC)
            {
                return;
            }

            Vector3 movement = new Vector2(
                    UIVirtualInput.GetInput(UIVirtualJoystickBehaviour.VIRTUAL_JOYSTICK_VERTICAL_VALUE), 
                    -UIVirtualInput.GetInput(UIVirtualJoystickBehaviour.VIRTUAL_JOYSTICK_HORIZONTAL_VALUE));

            transform.Translate(movement.normalized * speedMoviment * Time.deltaTime);
        }

        public void OnFallbackEvent()
        {

            transform.Translate(-transform.up * speedMoviment * Time.deltaTime);
        }
    }
}
