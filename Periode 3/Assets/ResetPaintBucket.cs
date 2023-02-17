using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPaintBucket : MonoBehaviour
{
    public GameObject objectToReset;
    public string tagName;
    public void ResetPaintBucketRigidBody()
    {
        
        if(objectToReset != null)
        {
            tagName = objectToReset.tag;
            objectToReset.tag = "Grabbed";
            objectToReset.GetComponent<SnapToHolder>().grabbed = true;
            objectToReset.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
    public void RigidReset()
    {
        
        if(objectToReset != null)
        {
            objectToReset.tag = tagName;
            objectToReset.GetComponent<SnapToHolder>().grabbed = false;
            objectToReset.GetComponent<Rigidbody>().isKinematic = false;
            objectToReset.GetComponent<SnapToHolder>().snapped = false;
            objectToReset = null;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Paint") 
        {
            objectToReset = other.gameObject;
        }
        
    }
}
