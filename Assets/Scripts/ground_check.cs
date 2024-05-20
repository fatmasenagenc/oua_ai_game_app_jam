using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class ground_check : MonoBehaviour
{
    // Start is called before the first frame update,
    private bool isJump;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
        isJump= true;
        
        }
        else { isJump= false; }
    }
    public bool return_jump() 
    { 
    return isJump;
    }
}
