using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ResetPaintBucket : MonoBehaviour
{
    public GameObject objectToReset;
    public LayerMask layerMask;
    
    public string tagName;
    
    public void ResetPaintBucketRigidBody()
    {
        if(objectToReset == null)
        {
            Collider[] collider = Physics.OverlapSphere(transform.position, 0.2f,layerMask);
            objectToReset = collider[0].gameObject;
            
        }
        if(objectToReset != null)
        {
            if (objectToReset.GetComponent<SnapToHolder>().myHolder != null)
            {
                objectToReset.GetComponent<SnapToHolder>().myHolder.GetComponent<PaintLevel>().refills = 0;
                objectToReset.GetComponent<SnapToHolder>().myHolder.GetComponent<PaintLevel>().canisterOnHolder = null;
            }


            objectToReset.GetComponent<SnapToHolder>().myHolder = null;
            tagName = objectToReset.tag;
            objectToReset.GetComponent<SnapToHolder>().inHand = true;
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
            objectToReset.GetComponent<SnapToHolder>().inHand = false;
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
