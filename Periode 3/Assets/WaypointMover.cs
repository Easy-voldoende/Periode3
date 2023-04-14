using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WaypointMover : MonoBehaviour
{
    public Waypoint waypoints;
    public MissionSystem missionSystem;
    public GameObject waypointObject;
    public float moveSpeed;
    public float cooldown;
    public int checkPoints;
    public bool started, finished;
    public bool grabbed;
    public Color color;
    public bool isMixing;
    public int i;
    public Transform elevatorDestination;
    public bool elevatorCanMove;
    public float elevatorMoveSpeed;
    public GameObject elevator;
    public Vector3 elevatorStartPos;

    private float distanceThreshold = 0.01f;    

    public float distanceToNextWaypoint;

    public Transform currentWaypoint;
    // Start is called before the first frame update
    void Start()
    {

        elevatorMoveSpeed = 0.5f;
        elevatorStartPos = elevator.transform.position;
        waypoints = GameObject.Find("Waypoints").GetComponent<Waypoint>();
        waypointObject = GameObject.Find("Waypoints").gameObject;
        
        isMixing = false;
        currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);
        transform.position = currentWaypoint.position;
        elevator = missionSystem.elevator;
        currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);

    }

    // Update is called once per frame
    void Update()
    {
        
        if(elevatorDestination != null)
        {
            var newpos = Vector3.MoveTowards(elevator.transform.position, elevatorDestination.position, elevatorMoveSpeed * Time.deltaTime);
            elevator.transform.position = newpos;
        }


        cooldown -= Time.deltaTime;
        if(cooldown <= 0f && grabbed == false && started == true)
        {
            Quaternion q = new Quaternion(0, 90, 90, 0);
            gameObject.transform.rotation = q;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
            {
                currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);

            }
            if(Vector3.Distance(transform.position, waypointObject.transform.GetChild(1).transform.position) < distanceThreshold && checkPoints ==0)
            {
                checkPoints++;  
                moveSpeed = 0f;
                cooldown = 3f;
            }

            if (Vector3.Distance(transform.position, waypointObject.transform.GetChild(2).transform.position) < distanceThreshold && checkPoints == 1)
            {
                checkPoints++;
                moveSpeed = 0f;
                cooldown = 3f;
            }
            if (Vector3.Distance(transform.position, waypointObject.transform.GetChild(5).transform.position) < distanceThreshold && checkPoints == 2)
            {
                checkPoints++;
                moveSpeed = 0f;
                cooldown = 3f;
            }
            if (Vector3.Distance(transform.position, waypointObject.transform.GetChild(6).transform.position) < distanceThreshold && checkPoints == 3)
            {
                checkPoints++;
                moveSpeed = 0f;
                cooldown = 3f;
            }
            if (Vector3.Distance(transform.position, waypointObject.transform.GetChild(7).transform.position) < distanceThreshold && checkPoints == 3)
            {


                elevator.GetComponent<MoveElevator>().final = elevator.GetComponent<MoveElevator>().destination;
                moveSpeed = 0f;
                cooldown = 3f;
            }
            if (Vector3.Distance(transform.position, waypointObject.transform.GetChild(8).transform.position) < distanceThreshold && checkPoints == 3)
            {
                elevator.GetComponent<MoveElevator>().final = elevator.GetComponent<MoveElevator>().destination2;

                moveSpeed = 0f;
                cooldown = 3f;
            }

            if (Vector3.Distance(transform.position, waypointObject.transform.GetChild(9).transform.position) < distanceThreshold && checkPoints == 4)
            {
                started = false;
                finished = true;
                checkPoints = 0;
                moveSpeed = 0f;
                cooldown = 3f;
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                isMixing = false;
                gameObject.GetComponent<BoxCollider>().enabled = false;
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.GetComponent<CapsuleCollider>().enabled = false;
                gameObject.GetComponent<XRGrabInteractable>().enabled = false;
                
                

            }
            
            if (cooldown <= 0 && started == true)
            {
                moveSpeed = 0.5f;
                if(elevatorCanMove == true)
                {
                    elevator.GetComponent<MoveElevator>().canMove = true;
                }
            }
            else
            {
                moveSpeed = 0f;
            }
            distanceToNextWaypoint = Vector3.Distance(transform.position, currentWaypoint.position);
        }
        if(cooldown > 0)
        {
            Renderer rend = gameObject.transform.GetChild(0).GetComponent<Renderer>();
            Color newColor = Color.Lerp(rend.material.color, color, Time.deltaTime*0.15f);
            rend.material.color = newColor;
        }
        if (grabbed == true && isMixing == true)
        {
            checkPoints = 0;
            
            isMixing = false;
            finished = false;
            started = false;
        }

    }
}
