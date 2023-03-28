using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckForMissionComplete : MonoBehaviour
{
    // Start is called before the first frame update
    public bool canCheck;
    public MachineScript machine;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(canCheck == true)
        {
            if(machine.isMatching == true)
            {
                if (collision.transform.gameObject.tag == "Body")
                {
                    Destroy(collision.transform.gameObject);
                    machine.missionCompleted = true;
                    machine.colorMatchup = 10000;
                }
            }
        }
    }
}
