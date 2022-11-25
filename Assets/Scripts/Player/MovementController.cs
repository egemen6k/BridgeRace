using System;
using System.Collections;
using DG.DemiLib;
using DG.Tweening;
using ScriptableObjects.Scripts;
using UnityEngine;
using Range = DG.DemiLib.Range;

namespace Player
{
    public class MovementController : MonoBehaviour
    {
        [Header("Movement Variables")] 
        [SerializeField] private Vector3Variable movementVector;

        [SerializeField] private FloatRange floatRange;

        private CharacterController _cc;

        private bool isActive = false;

        private void Start()
        {
            _cc = TryGetComponent(out CharacterController cc) ? cc : gameObject.AddComponent<CharacterController>();
        }

        private void Update()
        {
            Vector3 velocity = new Vector3(movementVector.Value.x, 0f, movementVector.Value.y) * Time.deltaTime * (floatRange.speed / 50f);
            if (!_cc.isGrounded)
            {
                velocity.y = -0.1f;
            }
            _cc.Move(velocity);
        }
    }
}