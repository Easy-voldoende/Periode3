using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ResetPaintBucket : MonoBehaviour
{
    public GameObject objectToReset;
    public GameObject drawer;
    public LayerMask layerMask;
    public GameObject lid, lid2;
    
    public string tagName;
    
    public void ResetPaintBucketRigidBody()
    {
        if(objectToReset == null)
        {
            Collider[] collider = Physics.OverlapSphere(transform.position, 0.04f,layerMask);
            if (collider.Length >= 1)
            {
                objectToReset = collider[0].transform.gameObject;
            }
            
        }
        
        if (objectToReset != null)
        {
            ActivateAnim drawer = objectToReset.GetComponent<ActivateAnim>();
            if (drawer != null)
            {
                if (drawer.open == true)
                {
                    drawer.open = false;
                }
                else if (drawer.open == false)
                {
                    drawer.open = true;
                    drawer.StartCoroutine(drawer.CanisterCycle());
                }
            }

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
                    if(snap.myHolder.GetComponent<PaintLevel>()!= null)
                    {
                        snap.myHolder.GetComponent<PaintLevel>().refills = 0;
                        snap.myHolder.GetComponent<PaintLevel>().canisterOnHolder = null;
                    }
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

            //ActivateAnim drawer = objectToReset.GetComponent<ActivateAnim>();
            //if (drawer != null)
            //{
            //    if (drawer.open == true)
            //    {
            //        drawer.open = false;
            //    }
            //    else if (drawer.open == false)
            //    {
            //        drawer.open = true;
            //    }
            //}
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
