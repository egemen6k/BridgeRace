using System;
using UnityEngine;

namespace ScriptableObjects.Scripts
{
    [CreateAssetMenu(fileName = "New Float Range",menuName = "Float Range")]
    public class FloatRange : ScriptableObject
    {
        [Range(0.5f,1.5f)]
        public float initialSpeed = 1f;
        
        [Range(0.5f,1.5f)]
        public float speed;
        private void OnEnable()
        {
            speed = initialSpeed;
        }
    }
}
