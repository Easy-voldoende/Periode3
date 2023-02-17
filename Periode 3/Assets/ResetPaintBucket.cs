using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ResetPaintBucket : MonoBehaviour
{
    public GameObject objectToReset;
    
    public string tagName;
    
    public void ResetPaintBucketRigidBody()
    {
        
        if(objectToReset != null)
        {
            if (objectToReset.GetComponent<SnapToHolder>().myHolder != null)
            {
                objectToReset.GetComponent<SnapToHolder>().myHolder.GetComponent<PaintLevel>().refills = 0;
                objectToReset.GetComponent<SnapToHolder>().myHolder.GetComponent<PaintLevel>().canisterOnHolder = null;
            }


            objectToReset.GetComponent<SnapToHolder>().myHolder = null;
            tagName = objectToReset.tag;
            objectToReset.GetComponent<SnapToHolder>().grabbed = true;
            objectToReset.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
    public void RigidReset()
    {
        
        if(objectToReset != null)
        {
            if (objectToReset.GetComponent<SnapToHolder>().myHolder != null)
            {
                objectToReset.GetComponent<SnapToHolder>().myHolder.GetComponent<PaintLevel>().refills = 0;
                objectToReset.GetComponent<SnapToHolder>().myHolder.GetComponent<PaintLevel>().canisterOnHolder = null;
            }
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
