using ADT.Boxing.Scriptable;
using UnityEngine;

namespace ADT.Boxing
{
    public class ScoreBehaviour : MonoBehaviour
    {
        [SerializeField]
        private IntVariable scoreValue;

        [Header("Event")]
        [SerializeField]
        private GameEvent OnScoreUpdateEvent;

        public void AddScorePoint()
        {
            scoreValue.Value += 1;
            OnScoreUpdateEvent.Raise();
        }
    }
}
