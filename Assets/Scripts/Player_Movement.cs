using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public static Player_Movement Instance;
    // Start is called before the first frame update
    [SerializeField] private float horizontal_speed;
    [SerializeField] private float jump_speed;
    protected ground_check is_grounded;
    private Rigidbody2D rig2d;
    private float dirX;
    public BoxCollider2D ground_check;
    public LayerMask jumpableGround;

    private enum STATES { IDLE,RUN,JUMP,FALL};
    private Animator ch_anim;
    STATES current_state;
    private SpriteRenderer spr2d;

    void Start()
    {
        Instance = this;
        rig2d = GetComponent<Rigidbody2D>();
        spr2d= GetComponent<SpriteRenderer>();
        ch_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX=Input.GetAxisRaw("Horizontal");
        rig2d.velocity = new Vector2(horizontal_speed*dirX, rig2d.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            
                rig2d.velocity = new Vector2(rig2d.velocity.x, jump_speed);

            
        }

        if (Input.GetButtonUp("Jump") && rig2d.velocity.y > 0f)
        {
            rig2d.velocity = new Vector2(rig2d.velocity.x, rig2d.velocity.y * 0.5f);
        }
        update_animation();
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(ground_check.bounds.center, ground_check.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void update_animation() 
    {
        if (rig2d.velocity.x > 0) 
        {
            current_state = STATES.RUN;
            spr2d.flipX= false;
        }
        else if (rig2d.velocity.x < 0) 
        {
        current_state= STATES.RUN;
            spr2d.flipX= true;
        }
        if (rig2d.velocity.y > 0.2f) 
        {
        current_state= STATES.JUMP;
        }
        else if (rig2d.velocity.y < -0.2f) 
        {
        current_state= STATES.FALL;
        }

        else if((rig2d.velocity.y>-0.2f && rig2d.velocity.y<0.2f) && rig2d.velocity.x == 0) 
        {
            current_state = STATES.IDLE;
        }
        ch_anim.SetInteger("state", (int)current_state);
        //switch(current_state)
        //{ 
        
        //case STATES.RUN:
        //    ch_anim.SetInteger("state",)
        //    break;
        //case STATES.JUMP:
        //    break;
        //case STATES.FALL:
        //    break;
        //case STATES.IDLE:
        //    break;
        //}

    
    }



}
