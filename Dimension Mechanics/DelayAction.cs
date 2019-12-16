using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DelayAction : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float time;
    [SerializeField]
    private UnityEvent action;

    private float startTime;
    private float currentTime;

    void Start()
    {
        startTime = float.MaxValue - time;
    }

     public bool happened = false;

    // Update is called once per frame
    void Update()
    {
        if(!happened)
        {
            currentTime = Time.time;

            if (startTime + time < currentTime)
            {
                action.Invoke();
                happened = true;
            }
        }
    }

    public void StartTimer()
    {
        startTime = Time.time;
    }
}
