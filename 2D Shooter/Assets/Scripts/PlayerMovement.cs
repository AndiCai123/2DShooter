using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;
    public CharacterController2D controller;
    public float HM = 0f;
    public float runSpeed = 40f;
    bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        HM = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump")){
            jump = true;
        }
        if (Input.GetButtonUp("Jump"))
        {
            jump = false;

        }
        if (Input.GetKeyDown("a") || Input.GetKeyDown("d"))
        {
            anim.SetTrigger("Walking");
        }
        if (Input.GetKeyUp("a") || Input.GetKeyUp("d"))
        {
            anim.SetTrigger("Stopping");
        }*/
    }

    void FixedUpdate()
    {
        //controller.Move(HM * Time.fixedDeltaTime, false, jump);
        //jump = false;
    }

}
