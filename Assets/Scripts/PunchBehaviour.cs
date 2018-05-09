using System.Collections;
using UnityEngine;

namespace ADT.Boxing
{
    [RequireComponent(typeof(Animator))]
    public class PunchBehaviour : MonoBehaviour
    {
        [SerializeField]
        private float timePunchAnimation = 0;
        [SerializeField]
        private float totalPunchTimeAnimation = 0.2f;
        [SerializeField]
        private float updatePunchTimeAnimation = 0.05f;
        [SerializeField]
        private bool isAnimating = false;
        [SerializeField]
        private bool isPointerDown = false;

        private Animator animator;
        private Transform punchTargetPoint;

        public Transform anotherFighterTargetPoint;

        private bool isAnotherFighterOnTheLeft = false;
        private bool wasAnotherFighterOnTheLeft = false;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            punchTargetPoint = GetComponentInChildren<Transform>();
        }
        
        private void Update()
        {
            if (isPointerDown)
            {
                if (!IsAnotherPlayerOnTheSameSide())
                {
                    OnPointerDownEvent();
                }
            }
        }

        private bool IsAnotherPlayerOnTheSameSide()
        {
            wasAnotherFighterOnTheLeft = isAnotherFighterOnTheLeft;
            isAnotherFighterOnTheLeft = IsAnotherFighterOnTheLeft();
            if (isAnotherFighterOnTheLeft == wasAnotherFighterOnTheLeft)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsAnotherFighterOnTheLeft()
        {
            if (anotherFighterTargetPoint != null &&
                punchTargetPoint != null &&
                punchTargetPoint.position.x >= anotherFighterTargetPoint.position.x)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public void OnPointerDownEvent()
        {
            if (!isAnimating)
            {
                isPointerDown = true;
                Punch();
            }
        }
        
        public void OnPointerUpEvent()
        {
            isPointerDown = false;
            StartCoroutine(ReversePunchAnimatorByCoroutine());
        }

        private void Punch()
        {
            StartCoroutine(PunchAnimatorByCoroutine(IsAnotherFighterOnTheLeft()));
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
            yield return new WaitUntil(() => (isPointerDown == false) && (isAnimating == false));
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

