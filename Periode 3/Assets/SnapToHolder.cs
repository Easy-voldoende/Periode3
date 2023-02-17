using Oculus.Interaction.GrabAPI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToHolder : MonoBehaviour
{
    
    public bool grabbed;
    public string assignedRefillColor;
    public bool snapped;
    public float refills;
    public bool canisterIsFull;
    public GameObject myHolder;
    private void Start()
    {
        canisterIsFull = true;
        refills = 10;
    }
    public void Update()
    {
        if(refills > 0)
        {
            canisterIsFull = true;
        }
        else
        {
            canisterIsFull=false;
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Holder" && grabbed == false && snapped == false)
        {
            if(collision.gameObject.GetComponent<PaintLevel>().assignedColor == assignedRefillColor)
            {
                myHolder = collision.gameObject;
                collision.gameObject.GetComponent<PaintLevel>().canisterOnHolder = gameObject;
                collision.gameObject.GetComponent<PaintLevel>().occupied = true;
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                float yOffset = collision.gameObject.transform.localScale.y / 2;
                Quaternion desiredRot = new Quaternion(0, 0, 0, 0);
                gameObject.transform.rotation = desiredRot;
                Vector3 snapPos = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z);
                Vector3 offset = new Vector3(0, yOffset, 0);

                gameObject.transform.position = snapPos + offset;
                snapped = true;
                
            }

            

        }
        
    }
    
}
