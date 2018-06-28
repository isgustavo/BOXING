using ADT.Boxing.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace ADT.Boxing.UI
{
    public class UIPlayerScoreBehaviour : MonoBehaviour
    {
        [SerializeField]
        private IntVariable playerScore;

        private Text scoreText;

        private void Awake()
        {
            scoreText = GetComponent<Text>();
        }

        public void OnScoreUpdate()
        {
            scoreText.text = playerScore.Value.ToString();
        }
    }
}
