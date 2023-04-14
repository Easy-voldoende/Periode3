using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveElevator : MonoBehaviour
{
    public bool canMove;
    public Transform destination;
    public Transform destination2;
    public GameObject waypointObject;
    public Transform final;
    public Waypoint waypoint;
    private void Start()
    {
        waypoint = GameObject.Find("Waypoints").GetComponent<Waypoint>();
        waypointObject = GameObject.Find("Waypoints").gameObject;
        destination = waypointObject.transform.GetChild(8);
        destination2 = waypointObject.transform.GetChild(7);
        final = destination2;
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, final.position, 0.5f * Time.deltaTime);
    }
}
