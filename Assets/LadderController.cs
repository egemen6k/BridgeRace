using System;
using System.Collections;
using System.Collections.Generic;
using Collectable.Base;
using Unity.VisualScripting;
using UnityEngine;

public class LadderController : MonoBehaviour,ILadderController
{
    [SerializeField] private Transform steps;
    [SerializeField] private List<LadderStep> ladders;
    private void Awake()
    {
        for (int i = 0; i < steps.transform.childCount; i++)
        {
            ladders.Add(steps.transform.GetChild(i).GetComponentInChildren<LadderStep>());
            steps.transform.GetChild(i).GetComponentInChildren<LadderStep>().iLadderController = this;
        }
    }

    public void LadderOpenRequest(LadderStep ladder,ICollector iCollector)
    {
        if (iCollector.CheckPullableStack() == CollectableType.Empty)
        {
            if (ladder.typeOfObject != iCollector.TypeOfPlayer) ladder.LadderUnregister();
            return;
        }

        GameObject pulledStack;
        
        if (!ladder.isOpened)
        {
            pulledStack = iCollector.PullStack(ladder.transform);
            ladder.UnStack(ladder.transform,pulledStack.GetComponent<BaseCollectable>().typeOfObject);
            return;
        }

        if (ladder.typeOfObject == iCollector.CheckPullableStack())
        {
            return;
        }
        
        pulledStack = iCollector.PullStack(ladder.transform);
        ladder.UnStack(ladder.transform,pulledStack.GetComponent<BaseCollectable>().typeOfObject);
    }
}

public interface ILadderController
{
    public void LadderOpenRequest(LadderStep ladder,ICollector iCollector);
}
