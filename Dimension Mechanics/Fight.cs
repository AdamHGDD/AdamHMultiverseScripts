using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Camera mainCamera = ScriptManager.Instance.MainCamera;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.O))
        {

            Ray playerAim = ScriptManager.Instance.MainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

            if(Physics.Raycast(playerAim, out RaycastHit hit, 3))
            {

                GameObject hitObject = hit.collider.gameObject;

                if (hitObject.tag == "Attackable")
                {
                    //Debug.Log("Correct Collision");
                    hitObject.GetComponent<Animator>().enabled = false;
                    Rigidbody hitBody = hitObject.GetComponent<Rigidbody>();
                    hitBody.freezeRotation = false;

                    hitBody.AddTorque(playerAim.direction.z * 1200, 0, -playerAim.direction.x * 1200);
                    hitBody.AddForce(playerAim.direction.x * 180, 30, playerAim.direction.z * 180);

                    Mug mugging = hitObject.GetComponent<Mug>();
                    if (mugging != null)
                    {
                        Vector3 pos = hitObject.transform.position;
                        pos += new Vector3(-playerAim.direction.x * 1f, 0, -playerAim.direction.z * 1f);
                        pos.y = 3.5f;
                        mugging.Drop(pos, Quaternion.Euler(new Vector3(1, 1, 1)));
                    }
                }
            }

        }
    }
}
