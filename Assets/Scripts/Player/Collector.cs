using System;
using System.Collections;
using System.Collections.Generic;
using Collectable.Base;
using UnityEngine;
using DG.Tweening;

public class Collector : MonoBehaviour,ICollector
{
    [SerializeField] private CollectableType typeOfPlayer;
    public CollectableType TypeOfPlayer => typeOfPlayer;
    public float yDifference { get; } = 0.11f;
    public Transform nest;
    public int stackCount = 0;

    private List<GameObject> _stacks = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IStackResponser>().OnStack(typeOfPlayer,this);
    }

    public int PushStack(GameObject pushed)
    {
        _stacks.Add(pushed);
        pushed.transform.SetParent(nest);
        stackCount = _stacks.Count;
        return _stacks.Count - 1;
    }

    public GameObject PullStack(Transform target)
    {
        if (_stacks.Count == 0) return null;
        
        GameObject pulledStack = _stacks[^1];
        _stacks.Remove(pulledStack);
        stackCount = _stacks.Count;
        
        pulledStack.GetComponent<IStackResponser>().UnStack(target,CollectableType.Empty);
        return pulledStack;
    }

    public CollectableType CheckPullableStack()
    {
        if (stackCount == 0)
        {
            return CollectableType.Empty;
        }


        return _stacks[^1].GetComponent<BaseCollectable>().typeOfObject;
    }
}

public interface ICollector
{
    public CollectableType TypeOfPlayer { get; }
    public float yDifference { get;}
    public int PushStack(GameObject pushed);
    public GameObject PullStack(Transform target);
    public CollectableType CheckPullableStack();
}
