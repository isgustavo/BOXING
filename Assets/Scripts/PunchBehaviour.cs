using ODT.UI.Util;
using System.Collections;
using UnityEngine;

namespace ADT.Boxing
{
    [RequireComponent(typeof(Animator))]
    public class PunchBehaviour : MonoBehaviour
    {
        private static string PUNCH_ANIMATION_VALUE_NAME = "Punch";

        [Header("Punch Animation")]
        [SerializeField]
        private float punchAnimatorValue = 0;
        [SerializeField]
        private float punchTotalTimeAnimation = 0.2f;
        [SerializeField]
        private float punchSpeedAnimation = 0.05f;

        private Animator animator;
        private BoxCollider2D[] punchColliders;

        public Transform otherPlayerTransform;

        private Transform playerTargetTransform;
        private float playerXOffset = .7f;

        private bool isPunching = false;
        private bool isAnimating = false;

        private bool isLeft = true;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            playerTargetTransform = GetComponentInChildren<Transform>();

            punchColliders = GetComponents<BoxCollider2D>();
        }

        private void Update()
        {
            if (isAnimating)
            {
                return;
            }

            if (UIVirtualInput.GetInput(UIPunchButtonBehaviour.VIRTUAL_PUNCH_BUTTON_VALUE) == 1)
            {
                if (isPunching)
                {
                    return;
                }

                isLeft = IsOtherPlayerOnTheLeft();
                Punch();
            }
            else
            {
                if (isPunching)
                {
                    DisableCollider(isLeft);
                    Recover(); 
                }
            }
        }

        private bool IsOtherPlayerOnTheLeft()
        {
            if (otherPlayerTransform != null &&
                playerTargetTransform.position.x > otherPlayerTransform.position.x)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Punch()
        {
            isPunching = true;
            StartCoroutine(PunchAnimator(isLeft));
        }

        private void Recover()
        {
            isPunching = false;
            StartCoroutine(RecoverPunchAnimator(isLeft));
        }

        private IEnumerator PunchAnimator(bool isLeft)
        {
            isAnimating = true;
            if (isLeft)
            {
                yield return DecreasePunchAnimatorValeuTo(-punchTotalTimeAnimation);
                punchAnimatorValue = -punchTotalTimeAnimation; 
            }
            else
            {
                yield return IncreasePunchAnimationValueTo(punchTotalTimeAnimation);
                punchAnimatorValue = punchTotalTimeAnimation;
            }

            EnableCollider(isLeft);
            animator.SetFloat(PUNCH_ANIMATION_VALUE_NAME, punchAnimatorValue);
            isAnimating = false;
        }

        private IEnumerator RecoverPunchAnimator(bool isLeft)
        {
            isAnimating = true;

            if (isLeft)
            {
                yield return IncreasePunchAnimationValueTo(0f);
            }
            else
            {
                yield return DecreasePunchAnimatorValeuTo(0f);
            }

            punchAnimatorValue = 0f;
            animator.SetFloat(PUNCH_ANIMATION_VALUE_NAME, 0);

            isAnimating = false;
        }

        private IEnumerator IncreasePunchAnimationValueTo(float animatorValue)
        {
            do
            {
                animator.SetFloat(PUNCH_ANIMATION_VALUE_NAME, punchAnimatorValue);
                yield return new WaitForSeconds(punchSpeedAnimation);
                punchAnimatorValue += punchSpeedAnimation;
            } while (punchAnimatorValue <= animatorValue);
        }

        private IEnumerator DecreasePunchAnimatorValeuTo(float animatorValue)
        {
            do
            {
                animator.SetFloat(PUNCH_ANIMATION_VALUE_NAME, punchAnimatorValue);
                yield return new WaitForSeconds(punchSpeedAnimation);
                punchAnimatorValue -= punchSpeedAnimation;
            } while (punchAnimatorValue >= animatorValue);
        }

        private void EnableCollider(bool isLeft)
        {
            if (isLeft)
            {
                punchColliders[0].enabled = true;
            }
            else
            {
                punchColliders[1].enabled = true;
            }
        }

        private void DisableCollider(bool isLeft)
        {
            if (isLeft)
            {
                punchColliders[0].enabled = false;
            }
            else
            {
                punchColliders[1].enabled = false;
            }
        }
    }
}

