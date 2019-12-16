using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mug : MonoBehaviour
{
    // Item to drop on hit
    [SerializeField]
    private GameObject item;
    [SerializeField]
    private UnityEvent muggingAction;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Drop(Vector3 pos, Quaternion rot)
    {
        Instantiate(item, pos, rot);
        muggingAction.Invoke();
    }
}
