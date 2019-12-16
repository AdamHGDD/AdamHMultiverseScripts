using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemForItem : MonoBehaviour
{
    [SerializeField]
    private int inventoryID;
    [SerializeField]
    private GameObject newItem;
    [SerializeField]
    private Vector3 newItemLocation;

    private Inventory inventory;

    void Start()
    {
        inventory = HFPS_GameManager.Instance.GetComponent<Inventory>();
    }

    public void CallScript()
    {
        if(inventory.CheckItemInventory(inventoryID))
        {
            inventory.RemoveItem(inventoryID);
            GameObject.Instantiate(newItem, transform.position + newItemLocation, Quaternion.identity);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + newItemLocation, 0.2f);
    }
}
