using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ResetPaintBucket : MonoBehaviour
{
    public GameObject objectToReset;
    public LayerMask layerMask;
    public GameObject lid, lid2;
    
    public string tagName;
    
    public void ResetPaintBucketRigidBody()
    {
        if(objectToReset == null)
        {
            Collider[] collider = Physics.OverlapSphere(transform.position, 0.06f,layerMask);
            objectToReset = collider[0].transform.gameObject;
            
        }
        
        if (objectToReset != null)
        {
            if (objectToReset.GetComponent<SnapToHolder>() != null)
            {
                objectToReset.GetComponent<SnapToHolder>().myHolder.GetComponent<PaintLevel>().refills = 0;
                objectToReset.GetComponent<SnapToHolder>().myHolder.GetComponent<PaintLevel>().canisterOnHolder = null;
                objectToReset.GetComponent<SnapToHolder>().myHolder = null;
                objectToReset.GetComponent<SnapToHolder>().inHand = true;
                objectToReset.GetComponent<SnapToHolder>().snapped = false;
            }
                                             
            objectToReset.GetComponent<Rigidbody>().isKinematic = false;
            
            if(objectToReset.GetComponent<WaypointMover>()!=null)
            {
                objectToReset.GetComponent<WaypointMover>().grabbed = true;
            }
        }
    }
    
    public void RigidReset()
    {
        
        if (objectToReset != null)
        {
            if (objectToReset.GetComponent<SnapToHolder>().myHolder != null)
            {
                objectToReset.GetComponent<SnapToHolder>().myHolder.GetComponent<PaintLevel>().refills = 0;
                objectToReset.GetComponent<SnapToHolder>().myHolder.GetComponent<PaintLevel>().canisterOnHolder = null;
                objectToReset.GetComponent<SnapToHolder>().inHand = false;
                objectToReset.GetComponent<SnapToHolder>().snapped = false;
            }
            
            objectToReset.GetComponent<Rigidbody>().isKinematic = false;
            
            if (objectToReset.GetComponent<WaypointMover>() != null)
            {
                objectToReset.GetComponent<WaypointMover>().grabbed = false;
            }
            objectToReset = null;
        }
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Paint" && other.gameObject.tag =="Body") 
        {
            objectToReset = other.gameObject;
        }
        
    }
}
