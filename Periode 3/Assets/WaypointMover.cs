using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    private Waypoint waypoints;
    public GameObject waypointObject;
    public float moveSpeed;
    public float cooldown;
    public int checkPoints;
    public bool started, finished;
    public bool grabbed;

    private float distanceThreshold = 0.01f;
    private enum ObjectState
    {
        GRABBED,
        INMACHINE,
    }
    ObjectState state;

    public float distanceToNextWaypoint;

    private Transform currentWaypoint;
    // Start is called before the first frame update
    void Start()
    {
        
        waypoints = GameObject.Find("Waypoints").GetComponent<Waypoint>();
        waypointObject = GameObject.Find("Waypoints").gameObject;

        currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);

    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if(cooldown <= 0f && grabbed == false)
        {
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

            if (Vector3.Distance(transform.position, waypointObject.transform.GetChild(9).transform.position) < distanceThreshold && checkPoints == 4)
            {
                started = false;
                finished = true;
                checkPoints = 0;
                moveSpeed = 0f;
                cooldown = 3f;
                
            }

            if (cooldown <= 0 && started == true)
            {
                moveSpeed = 0.5f;
            }
            else
            {
                moveSpeed = 0f;
            }
            distanceToNextWaypoint = Vector3.Distance(transform.position, currentWaypoint.position);
        }
        

        
    }
}
