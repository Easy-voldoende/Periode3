using Oculus.Interaction.GrabAPI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToHolder : MonoBehaviour
{
    
    public bool grabbed;
    public bool snapped;
    public bool rotated;


    
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Holder" && grabbed == false && snapped == false)
        {
            
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            float yOffset = collision.gameObject.transform.localScale.y / 2;
            //Quaternion desiredRot = new Quaternion(0, 0, 0, 0);
            //gameObject.transform.rotation = desiredRot;
            Vector3 snapPos = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y,collision.gameObject.transform.position.z);
            Vector3 offset = new Vector3(0, yOffset, 0);
            
            gameObject.transform.position = snapPos + offset;
            snapped = true;
            Quaternion desiredRot = new Quaternion(0, 0, 0, 0);
            gameObject.transform.rotation = desiredRot;

        }
    }
    public void RotateToDesired()
    {
        rotated = true;
        



    }
}
