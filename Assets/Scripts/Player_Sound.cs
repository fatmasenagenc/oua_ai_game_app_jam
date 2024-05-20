using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Sound : MonoBehaviour
{
    // Start is called before the first frame update
   public AudioSource run_sound, jump_sound, death_sound;
    private Animator anim;
    private bool isJump = false;
    void Start()
    {
       anim= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetInteger("state")==1) 
        {
            if(!run_sound.isPlaying)
            {
                run_sound.Play();
            }
        }
        else
        {
            run_sound.Stop();
        }

        if (anim.GetInteger("state")==2) 
        {
            if (!isJump)
            {
                jump_sound.Play();
                isJump= true;
            }
        }
        else
        {
            isJump= false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water")) 
        {
            death_sound.Play();
        }
    }
}
