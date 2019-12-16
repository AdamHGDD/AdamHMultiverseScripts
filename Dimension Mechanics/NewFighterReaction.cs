using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFighterReaction : MonoBehaviour
{

    private bool happened;
    private ObjectiveManager gameManager;

    [SerializeField]
    private GameObject fighter;

    // Start is called before the first frame update
    void Start()
    {
        happened = false;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ObjectiveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!happened)
        {
            if(!fighter.activeSelf && gameManager.triggeredObjectives.Contains(GetComponent<TriggerObjective>().objective))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -25);
                GetComponent<TriggerObjective>().DoEvent();
                happened = true;
            }
        }
    }
}
