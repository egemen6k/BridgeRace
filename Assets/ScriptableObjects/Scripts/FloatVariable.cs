using System;
using UnityEngine;

namespace ScriptableObjects.Scripts
{
    [CreateAssetMenu(fileName = "New Float Variable",menuName = "Float Variable")]
    public class FloatVariable : ScriptableObject
    {
        public float Value;

        private void OnEnable()
        {
            Value = 0f;
        }
    }
}
