using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DefaultEventMethods : MonoBehaviour
{
    [SerializeField]
    private bool lookForInventory;
    [SerializeField]
    private int inventoryID;
    [SerializeField]
    private int objectiveID;
    [SerializeField]
    private UnityEvent inventoryEvent;
    [SerializeField]
    private bool objectiveRequirement;

    private Inventory inventory;
    private ObjectiveManager objectiveManager;

    // Start is called before the first frame update
    void Start()
    {
        inventory = HFPS_GameManager.Instance.GetComponent<Inventory>();
        objectiveManager = HFPS_GameManager.Instance.GetComponent<ObjectiveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lookForInventory)
        {
            if(inventory.CheckItemInventory(inventoryID))
            {
                if(!objectiveRequirement || objectiveManager.ContainsObjective(objectiveID))
                {
                    inventoryEvent.Invoke();
                    lookForInventory = false;
                }
            }
        }
    }

    public void MoveObject()
    {
        transform.position += new Vector3(0,0,-12); 
    }

    public void RemoveFromInventory()
    {
        if (inventory.CheckItemInventory(inventoryID))
        {
            inventory.RemoveItem(inventoryID);
        }
    }
}
