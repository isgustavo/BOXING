using ODT.UI.Util;
using System.Collections;
using UnityEngine;

namespace ADT.Boxing
{
    [RequireComponent(typeof(Animator))]
    public class PunchBehaviour : MonoBehaviour
    {
        [Header("Punch Animation")]
        [SerializeField]
        private float timePunchAnimation = 0;
        [SerializeField]
        private float totalPunchTimeAnimation = 0.2f;
        [SerializeField]
        private float updatePunchTimeAnimation = 0.05f;
        
        private Animator animator;

        public Transform otherPlayerTransform;
        private Transform playerTargetTransform;

        private bool isPunching = false;
        private bool isAnimating = false;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            playerTargetTransform = GetComponentInChildren<Transform>();
        }

        private void Update()
        {
            if (UIVirtualInput.GetInput(UIPunchButtonBehaviour.VIRTUAL_PUNCH_BUTTON_VALUE) == 1)
            {
                if (!isPunching)
                {
                    isPunching = true;
                    Punch(IsOtherPlayerOnTheLeft());
                }
            }
            else
            {
                if (isPunching)
                {
                    isPunching = false;
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

        private void Punch(bool isLeft)
        {
            StartCoroutine(PunchAnimatorByCoroutine(isLeft));
        }

        private void Recover()
        {
            StartCoroutine(ReversePunchAnimatorByCoroutine());
        }

        private IEnumerator PunchAnimatorByCoroutine(bool isLeft)
        {
            isAnimating = true;
            if (isLeft)
            {
                yield return DecreaseTimePunchValeuAnimation(-totalPunchTimeAnimation);
            }
            else
            {
                yield return IncreaseTimePunchValueAnimation(totalPunchTimeAnimation);
            }
            isAnimating = false;
        }

        private IEnumerator ReversePunchAnimatorByCoroutine()
        {
            yield return new WaitUntil(() => (isAnimating == false));
            isAnimating = true;
            if (timePunchAnimation < 0f)
            {
                yield return DecreaseTimePunchValeuAnimation(0);
            }
            else
            {
                yield return DecreaseTimePunchValeuAnimation(0f);
            }
            timePunchAnimation = 0f;
            animator.SetFloat("Punch", timePunchAnimation);
            isAnimating = false;
        }


        private IEnumerator IncreaseTimePunchValueAnimation(float totalTime)
        {
            do
            {
                animator.SetFloat("Punch", timePunchAnimation);
                yield return new WaitForSeconds(updatePunchTimeAnimation);
                timePunchAnimation += updatePunchTimeAnimation;
            } while (timePunchAnimation <= totalTime);
        }

        private IEnumerator DecreaseTimePunchValeuAnimation(float totalTime)
        {
            do
            {
                animator.SetFloat("Punch", timePunchAnimation);
                yield return new WaitForSeconds(updatePunchTimeAnimation);
                timePunchAnimation -= updatePunchTimeAnimation;
            } while (timePunchAnimation >= totalTime);
        }
    }
}

