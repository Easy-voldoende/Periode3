using Oculus.Interaction.GrabAPI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToHolder : MonoBehaviour
{
    public Transform startPos;
    public MachineScript machine;
    public bool inHand;
    public bool snapped;
    public bool canisterIsFull;
    public string assignedRefillColor;
    
    public float refills;
    public GameObject myHolder;
    public float yOffset;
    public Color newColor;
    public int i;
    public float deathCooldown;
    public AudioManager aud;

    private void Start()
    {

        aud = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        deathCooldown = 3f;
        machine = GameObject.Find("MachineScreen").GetComponent<MachineScript>();
        canisterIsFull = true;
        refills = 1;
        if (assignedRefillColor == "Green")
        {
            i=0;
        }
        if (assignedRefillColor == "Red")
        {
            i = 1;
        }
        if (assignedRefillColor == "Blue")
        {
            i = 2;
        }
        if (assignedRefillColor == "Magenta")
        {
            i = 3;
        }
        if (assignedRefillColor == "Black")
        {
            i = 4;
        }
        if (assignedRefillColor == "Yellow")
        {
            i = 5;
        }
        if (assignedRefillColor == "Cyan")
        {
            i = 6;
        }
        if (assignedRefillColor == "Gray")
        {
            i = 7;
        }
        if (assignedRefillColor == "Orange")
        {
            i = 8;
        }
        if (assignedRefillColor == "Brown")
        {
            i = 9;
        }
        if (assignedRefillColor == "White")
        {
            i = 10;
        }
        if (assignedRefillColor == "Purple")
        {
            i = 11;
        }
        if (assignedRefillColor == "Olive")
        {
            i = 12;
        }
        if (assignedRefillColor == "Indigo")
        {
            i = 13;
        }
        if (assignedRefillColor == "Gold")
        {
            i = 14;
        }
        if (assignedRefillColor == "Silver")
        {
            i = 15;
        }


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
        if(!snapped&&refills <= 0)
        {
            deathCooldown -= 0.3f * Time.deltaTime;
        }
        if(deathCooldown <= 0)
        {
            Destroy(gameObject);
        }
    }
    //3.141
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Holder" && inHand == false && snapped == false)
        {
            if(assignedRefillColor == collision.gameObject.GetComponent<PaintLevel>().assignedColor)
            {
                
                myHolder = collision.gameObject;
                collision.gameObject.GetComponent<PaintLevel>().canisterOnHolder = gameObject;
                collision.gameObject.GetComponent<PaintLevel>().occupied = true;
                collision.gameObject.GetComponent<PaintLevel>().refills +=refills;
                refills -= 1;
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                yOffset = collision.gameObject.transform.localScale.y/10;
                gameObject.transform.parent = collision.gameObject.transform;
                Quaternion desiredRot = new Quaternion(0, 0, 0, 0);
                gameObject.transform.rotation = desiredRot;
                Vector3 snapPos = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z);
                Vector3 offset = new Vector3(0, yOffset, 0);
                
                gameObject.transform.position = snapPos+offset;
                
                snapped = true;
                
            }
            

        }
        if (collision.gameObject.tag == "Kast" && GetComponent<WaypointMover>().finished == true)
        {
            ShelfScript shelf = collision.gameObject.GetComponent<ShelfScript>();
            Quaternion desiredRot = new Quaternion(0, 90, 90, 0);
            gameObject.transform.rotation = desiredRot;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            
            gameObject.transform.position = shelf.snapPositions[shelf.i].transform.position;
            machine.objectToMove = null;
            GameObject child = gameObject.transform.GetChild(0).gameObject;
            Vector3 newPos = new Vector3(gameObject.transform.GetChild(0).transform.position.x, 5.5005f, gameObject.transform.GetChild(0).transform.position.z);
            
            gameObject.transform.GetChild(0).transform.parent = null;
            child.transform.position = newPos;
            Destroy(gameObject);
            
            shelf.i++;
            

        }
        
    }
    
}
