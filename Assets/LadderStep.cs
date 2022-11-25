using Collectable.Base;
using UnityEngine;

public class LadderStep : MonoBehaviour,IStackResponser
{
    public bool isOpened;
    public ILadderController iLadderController;
    public GameObject ladderModel, collision;
    [SerializeField] private CollectableType type = CollectableType.Empty;

    #region IStackResponser

    public CollectableType typeOfObject => type;

    public void OnStack<T>(CollectableType typeOfPlayer, T relatedScript)
    {
        if(relatedScript is not ICollector iCollector) return;
        iLadderController.LadderOpenRequest(this,iCollector);
    }

    public void UnStack(Transform target,CollectableType type)
    {
        isOpened = true;
        this.type = type;
        ladderModel.GetComponent<MeshRenderer>().material.color = StackColorGetter(type);
        ladderModel.SetActive(true);
        collision.SetActive(false);
    }

    #endregion

    public void LadderUnregister()
    {
        collision.SetActive(true);
    }

    private Color StackColorGetter(CollectableType type)
    {
        switch (type)
        {
            case CollectableType.Blue:
                return Color.blue;
            case CollectableType.Green:
                return Color.green;
            case CollectableType.Red:
                return Color.red;
            case CollectableType.Yellow:
                return Color.yellow;
            default:
                return Color.black;
        }
    }
}
