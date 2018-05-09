using UnityEngine;

namespace ADT.Boxing
{
    public class MoveBehaviour : MonoBehaviour
    {
        [SerializeField]
        private float speedMoviment = 2f;

        private Vector3 currentInput;
        private bool isPointerDown;

        private void Awake()
        {
            currentInput.z = 0;
        }

        private void Update()
        {
            if(!isPointerDown)
            {
                transform.Translate(currentInput * speedMoviment * Time.deltaTime);
            }
        }

        public void OnPointerDownEvent()
        {
            isPointerDown = true;
        }

        public void OnPointerUpEvent()
        {
            isPointerDown = false;
        }

        public void OnCurrentInputX(int input)
        {
            currentInput.x = input;
        }

        public void OnCurrentInputY(int input)
        {
            currentInput.y = input;
        }
    }
}
