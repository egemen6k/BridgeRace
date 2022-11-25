using UnityEngine;

namespace ScriptableObjects.Scripts
{
    [CreateAssetMenu(fileName = "New Int Variable",menuName = "Int Variable")]
    public class IntVariable : ScriptableObject
    {
        public int Value;

        private void OnEnable()
        {
            Value = 0;
        }
    }
}
