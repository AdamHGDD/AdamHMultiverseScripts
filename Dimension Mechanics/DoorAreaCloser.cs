using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAreaCloser : MonoBehaviour
{
    public DynamicObject door;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8 || other.gameObject.tag == "Player")//player
        {
            Debug.Log("Player Left");
            if (door.isOpened)
            {
                Debug.Log("Closing Door");
                //door.isOpened = false;
                door.CloseDoor(true);
            }
        }
    }
}
