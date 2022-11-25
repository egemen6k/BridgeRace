using Collectable.Base;
using UnityEngine;

namespace Collectable.Child
{
    public class Yellow : BaseCollectable
    {
        [SerializeField] private CollectableType typeOfCollectable;
        public override CollectableType typeOfObject => typeOfCollectable;
    }
}
