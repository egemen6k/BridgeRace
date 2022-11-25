using System.Collections;
using System.Collections.Generic;
using ScriptableObjects.Scripts;
using UnityEngine;

public class ModelRotationController : MonoBehaviour
{
    [SerializeField] private Vector3Variable movementVector;
    
    void LateUpdate()
    {
        transform.LookAt(transform.parent.position + new Vector3(movementVector.Value.x,0f,movementVector.Value.y));
    }
}
