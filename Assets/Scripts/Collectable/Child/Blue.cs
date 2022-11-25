using System;
using Collectable.Base;
using UnityEngine;

namespace Collectable.Child
{
    public class Blue : BaseCollectable
    {
        [SerializeField] private CollectableType typeOfCollectable;
        public override CollectableType typeOfObject => typeOfCollectable;
    }
}
