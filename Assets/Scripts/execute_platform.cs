using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class execute_platform : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject platform;
    private bool canActive;
    private bool petInside;
    void Start()
    {
        if(platform==null) canActive= false;
        else canActive= true;
    }

    // Update is called once per frame
    void Update()
    {
        var dir = transform.position - Player_Movement.Instance.transform.position;
        //var dir2=transform.position-pet_control_movement.Instance.transform.position;

        if (petInside)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                platform.gameObject.GetComponent<WaypointFollower>().isActive = !platform.gameObject.GetComponent<WaypointFollower>().isActive;
                platform.gameObject.GetComponent<WaypointFollower>().changed_waypoints= true;

            }
        }
        if (dir.magnitude >= MaxDistance)
        {
            return;
        }




        if(canActive)
        {
            if(Input.GetKeyDown(KeyCode.E)) {
                platform.gameObject.GetComponent<WaypointFollower>().isActive = !platform.gameObject.GetComponent<WaypointFollower>().isActive;
                platform.gameObject.GetComponent<WaypointFollower>().changed_waypoints = true;

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Pet"))
        {
            petInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pet"))
        {
            petInside = false;
        }
    }
    public float MaxDistance;
}
