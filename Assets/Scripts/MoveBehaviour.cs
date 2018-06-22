using ODT.UI.Util;
using UnityEngine;

namespace ODT.Boxing
{
    public class MoveBehaviour : MonoBehaviour
    {
        [SerializeField]
        private float speedMoviment = 20f;

        private Rigidbody2D rb2d;

        private void OnEnable()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Vector3 movement = new Vector2(
                    UIVirtualInput.GetInput(UIVirtualJoystickBehaviour.VIRTUAL_JOYSTICK_HORIZONTAL_VALUE), 
                    UIVirtualInput.GetInput(UIVirtualJoystickBehaviour.VIRTUAL_JOYSTICK_VERTICAL_VALUE));

            transform.position = Vector2.Lerp(transform.position, transform.position + movement, speedMoviment * Time.deltaTime);
        }
    }
}
