using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWayPointIndex = 0;
    public bool isActive = true;
    [SerializeField] private float speed = 2f;
    public bool isDoor;
    public bool change_index;
    public bool changed_waypoints;
    // Update is called once per frame
    private void Start()
    {
        
        change_index = false;      
        changed_waypoints= false;
    }
    private void Update()
    {
        if (!isDoor)
        {
            if (changed_waypoints)
            {
                int nextWaypointIndex = (currentWayPointIndex + 1) % waypoints.Length;
                transform.position = Vector2.MoveTowards(transform.position, waypoints[nextWaypointIndex].transform.position, Time.deltaTime * speed);

                float distanceToWaypoint = Vector2.Distance(transform.position, waypoints[nextWaypointIndex].transform.position);
                if (distanceToWaypoint < 0.01f) // adjust the tolerance value as needed
                {
                    currentWayPointIndex = nextWaypointIndex;
                    changed_waypoints = false;
                }
            }



        }

        if (isActive)
        {

            if(isDoor)
            {

                if (change_index)
                {
                   transform.position = Vector2.MoveTowards(transform.position, waypoints[0].transform.position, Time.deltaTime * speed);
                }
                else transform.position = Vector2.MoveTowards(transform.position, waypoints[1].transform.position, Time.deltaTime * speed);


            }

        }

    }
    





}
