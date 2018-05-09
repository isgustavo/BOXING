using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ADT.Boxing
{
    public class UIActionButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        [SerializeField]
        protected Image baseImage;
        [SerializeField]
        protected UnityEvent OnPointerDownEvent;
        [SerializeField]
        protected UnityEvent OnPointerUpEvent;

        public void OnPointerDown(PointerEventData eventData)
        {
            baseImage.gameObject.transform.localScale = new Vector3(.9f, .9f, .9f);
            OnPointerDownEvent.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            baseImage.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            OnPointerUpEvent.Invoke();
        }

        public void OnDisable()
        {
            OnPointerUpEvent.Invoke();
        }
    }
}
/*
    [SerializeField]
    private float timeHolding = 0f;
    [SerializeField]
    private float significantTimeHolding = 1f;
    [SerializeField]
    private float updateTimeInSeconds = 0.05f;
    [SerializeField]
    private bool isButtonAvailable = true;
    [SerializeField]
    private bool isButtonDown = false;

    public Animator animator;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isButtonAvailable)
        {
            isButtonAvailable = false;
            StartCoroutine("PointDown");
        }
        isButtonDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isButtonDown = false;
    }

    private IEnumerator PointDown()
    {
        while (timeHolding <= significantTimeHolding)
        {
            timeHolding += updateTimeInSeconds;
            animator.SetFloat("Left Push", timeHolding);
            yield return new WaitForSeconds(updateTimeInSeconds);
        }

        OnFinishedAction();
    }

    private IEnumerator PointerUp()
    {
        yield return new WaitUntil(() => isButtonDown == false);
        while (timeHolding >= 0f)
        {
            timeHolding -= updateTimeInSeconds;
            animator.SetFloat("Left Push", timeHolding);
            yield return new WaitForSeconds(updateTimeInSeconds);
        }

        timeHolding = 0f;
        isButtonAvailable = true;
    }

    private void OnFinishedAction()
    {
        StartCoroutine("PointerUp");
    }
}*/
