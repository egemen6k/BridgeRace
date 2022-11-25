using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects.Scripts;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Vector3Variable movementVector;
    [SerializeField] private FloatRange animationSpeed;
    private Animator _animator;
    private int speedAnim = Animator.StringToHash("Speed");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void LateUpdate()
    {
        _animator.speed = Mathf.Clamp(_animator.speed,1f , animationSpeed.speed);
        _animator.SetFloat(speedAnim,movementVector.Value.magnitude/300f);
    }
}
