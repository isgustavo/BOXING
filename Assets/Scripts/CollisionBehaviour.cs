using UnityEngine;

namespace ADT.Boxing
{
    [RequireComponent(typeof(Animator))]
    public class CollisionBehaviour : MonoBehaviour
    {
        private static string HIT_ANIMATION_TRIGGERE_NAME = "Hit";

        private Animator animator;
        private IAcceptable acceptableObj;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            acceptableObj = GetComponent<IAcceptable>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            acceptableObj.OnFallbackEvent();
            animator.SetTrigger(HIT_ANIMATION_TRIGGERE_NAME);
        }
    }
}
