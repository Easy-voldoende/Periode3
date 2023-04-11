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
            if (collider.Length >= 1)
            {
                objectToReset = collider[0].transform.gameObject;
            }
            
        }
        
        if (objectToReset != null)
        {
            SnapToHolder snap = objectToReset.GetComponent<SnapToHolder>();
            if (snap != null)
            {
                if(snap.myHolder != null)
                {
                    snap.myHolder.GetComponent<PaintLevel>().refills = 0;
                    snap.myHolder.GetComponent<PaintLevel>().canisterOnHolder = null;
                    snap.myHolder = null;
                }
                snap.inHand = true;
                snap.snapped = false;
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
            SnapToHolder snap = objectToReset.GetComponent<SnapToHolder>();
            if (snap != null)
            {
                if(snap.myHolder != null)
                {
                    snap.myHolder.GetComponent<PaintLevel>().refills = 0;
                    snap.myHolder.GetComponent<PaintLevel>().canisterOnHolder = null;
                }
                snap.inHand = false;
                snap.snapped = false;
            }
            
            objectToReset.GetComponent<Rigidbody>().isKinematic = false;

            WaypointMover mover = objectToReset.GetComponent<WaypointMover>();
            if (mover != null)
            {
                mover.grabbed = false;
            }
            objectToReset = null;
        }
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Paint" || other.gameObject.tag == "Body") 
        {
            objectToReset = other.gameObject;
        }
        
    }
}
