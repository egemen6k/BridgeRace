using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Collectable.Base
{
    public abstract class BaseCollectable : MonoBehaviour,IStackResponser
    {
        private Tweener _tweener;

        private Collider _col;
        private void Awake()
        {
            _col = GetComponent<Collider>();
        }

        public abstract CollectableType typeOfObject { get; }

        public void OnStack<T>(CollectableType typeOfPlayer,T relatedScript)
        {
            if (typeOfPlayer == typeOfObject)
            {
                _col.enabled = false;

                if(relatedScript is not ICollector iCollector) return;
                
                int index = iCollector.PushStack(this.gameObject);
                float duration = 0.5f;

                _tweener = transform.DOLocalMove(new Vector3(0f,(index * iCollector.yDifference),0f) , duration)
                    .SetEase(Ease.InQuad).SetLink(gameObject, LinkBehaviour.KillOnDestroy);
                
                _tweener.OnStart(() =>
                {
                    transform.DOLocalRotate(Vector3.zero, duration).SetEase(Ease.InQuad).SetLink(gameObject, LinkBehaviour.KillOnDestroy);
                    transform.GetChild(0).DOLocalJump(Vector3.zero,20f,1,duration).SetEase(Ease.InQuad).SetLink(gameObject, LinkBehaviour.KillOnDestroy);
                });
            }
        }

        public void UnStack(Transform target,CollectableType type)
        {
            transform.SetParent(target);
            
            float duration = 0.5f;

            _tweener = transform.DOLocalMove(new Vector3(0f,0f,0f) , duration).SetEase(Ease.InQuad).SetLink(gameObject, LinkBehaviour.KillOnDestroy);
            _tweener.OnStart(() =>
            {
                transform.DOLocalRotate(Vector3.zero, duration).SetEase(Ease.InQuad).SetLink(gameObject, LinkBehaviour.KillOnDestroy);
                transform.GetChild(0).DOLocalJump(Vector3.zero,20f,1,duration).SetEase(Ease.InQuad).SetLink(gameObject, LinkBehaviour.KillOnDestroy);
            });

            _tweener.OnComplete(() => gameObject.SetActive(false));
        }
    }

    public enum CollectableType
    {
        Empty,
        Blue,
        Green,
        Red,
        Yellow
    }

    public interface IStackResponser
    {
        public CollectableType typeOfObject { get; }
        public void OnStack<T>(CollectableType typeOfPlayer,T relatedScript);
        public void UnStack(Transform target,CollectableType type);
    }
}