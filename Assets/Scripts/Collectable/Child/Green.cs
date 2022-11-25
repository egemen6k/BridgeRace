using Collectable.Base;
using UnityEngine;

namespace Collectable.Child
{
    public class Green : BaseCollectable
    {
        [SerializeField] private CollectableType typeOfCollectable;
        public override CollectableType typeOfObject => typeOfCollectable;
    }
}
