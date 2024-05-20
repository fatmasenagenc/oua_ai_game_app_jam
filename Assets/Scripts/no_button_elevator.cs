using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class no_button_elevator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] waypoints;
    int currentWayPointIndex;
    public float speed;
    void Start()
    {
        currentWayPointIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int nextWaypointIndex = (currentWayPointIndex + 1) % waypoints.Length;
        transform.position = Vector2.MoveTowards(transform.position, waypoints[nextWaypointIndex].transform.position, Time.deltaTime * speed);

        float distanceToWaypoint = Vector2.Distance(transform.position, waypoints[nextWaypointIndex].transform.position);
        if (distanceToWaypoint < 0.01f) // adjust the tolerance value as needed
        {
            currentWayPointIndex = nextWaypointIndex;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) collision.gameObject.transform.SetParent(this.transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) collision.gameObject.transform.SetParent(null);

    }
}
