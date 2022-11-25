using System;
using ScriptableObjects.Scripts;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Atom Variables")]
    [SerializeField] private FloatVariable horizontalSwipe;
    [SerializeField] private FloatVariable verticalSwipe;
    [SerializeField] private Vector3Variable movementVector;
    
    [SerializeField] private bool isSwipeActive = true;

    private Vector3 previousTouchPosition;
    private Vector3 currentTouchPosition;
    
    private bool isFirstTouch = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(isSwipeActive) isFirstTouch = true;
        }
        else if (Input.GetMouseButton(0))
        {
            if(isSwipeActive) DetectSwipe();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // Reset swipe
            movementVector.Value = Vector3.zero;
            horizontalSwipe.Value = 0;
            verticalSwipe.Value = 0;
        }
    }

    private void DetectSwipe()
    {
        // Set previous touch position.
        if (isFirstTouch)
        {
            previousTouchPosition = Input.mousePosition;
            isFirstTouch = false;
        }
        // else
        // {
        //     previousTouchPosition = currentTouchPosition;
        // }
        
        currentTouchPosition = Input.mousePosition;

        if ((currentTouchPosition - previousTouchPosition).magnitude >= 300f)
        {
            movementVector.Value = (currentTouchPosition - previousTouchPosition).normalized * 300f;
        }
        else
            movementVector.Value = (currentTouchPosition - previousTouchPosition);
    }
}
