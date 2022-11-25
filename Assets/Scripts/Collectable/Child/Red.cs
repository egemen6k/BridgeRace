using Collectable.Base;
using UnityEngine;

namespace Collectable.Child
{
    public class Red : BaseCollectable
    {
        [SerializeField] private CollectableType typeOfCollectable;
        public override CollectableType typeOfObject => typeOfCollectable;
    }
}
