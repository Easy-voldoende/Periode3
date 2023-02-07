using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearTurning : MonoBehaviour
{
    public bool turnLeft;
    public float turnSpeed;
    
    void Start()
    {
        turnSpeed = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if(turnLeft == true)
        {
            gameObject.transform.Rotate(0, 0, -turnSpeed * Time.deltaTime);
        }
        else
        {
            gameObject.transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
        }
    }
}
