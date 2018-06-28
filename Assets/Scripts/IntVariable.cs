using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ADT.Boxing.Scriptable
{
    [CreateAssetMenu(menuName = "Objects/Int Variable")]
    public class IntVariable : ScriptableObject
    {
        [SerializeField]
        public int Value;

        [SerializeField]
        private bool resetOnEnable = false;

        private void OnEnable()
        {
            if (resetOnEnable)
            {
                Value = 0;
            }
        }
    }
}
