using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnTrigger : MonoBehaviour
{
    [SerializeField]
    private UnityEvent eventOnTrigger;
    bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if(!triggered && other.tag == "Player")
        {
            eventOnTrigger.Invoke();
            triggered = true;
        }
    }
}
