using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class pressure_plate : MonoBehaviour
{
    // Start is called before the first frame update

    public float maxDistance;
    public float go_down_multiplier;
    public float go_down_second_multiplier;
    public GameObject Platform;
    private float start_position;
    private bool isJump;
    void Start()
    {
        start_position = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Pet")||collision.gameObject.CompareTag("Box")||collision.gameObject.CompareTag("Player"))&&!isJump) 
        {
            collision.gameObject.transform.SetParent(transform);
            transform.position = new Vector3(transform.position.x, transform.position.y - maxDistance,transform.position.z);
            isJump= true;
            Platform.GetComponent<WaypointFollower>().change_index = true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Pet") || collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Player")) && isJump)
        {
            collision.gameObject.transform.SetParent(null);
            transform.position = new Vector3(transform.position.x, start_position, transform.position.z);
            isJump = false;
            Platform.GetComponent<WaypointFollower>().change_index = false;
        }
    }

    
}
