using UnityEngine;

namespace ScriptableObjects.Scripts
{
    [CreateAssetMenu(fileName = "New Vector3 Variable",menuName = "Vector3 Variable")]
    public class Vector3Variable : ScriptableObject
    {
        public Vector3 Value;

        private void OnEnable()
        {
            Value = Vector3.zero;
        }
    }
}
