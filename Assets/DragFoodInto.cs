using Unity.VisualScripting;
using UnityEngine;

public class DragFoodInto : MonoBehaviour
{
    [SerializeField] private LayerMask targetLayer;
    public void AddItem(InventoryItem item)
    {
        item.transform.SetParent(transform, false);
    }
}
