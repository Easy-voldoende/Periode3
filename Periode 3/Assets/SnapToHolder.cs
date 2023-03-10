using Oculus.Interaction.GrabAPI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToHolder : MonoBehaviour
{
    
    public bool inHand;
    public bool snapped;
    public bool canisterIsFull;
    public string assignedRefillColor;
    public float refills;
    public GameObject myHolder;
    public Color newColor;

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
        if(collision.gameObject.tag == "Holder" && inHand == false && snapped == false)
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
