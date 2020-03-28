﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{

  float rotationSpeed = 50;
  float rotation = 0f;
  public float jumpForce = 100;
  public LayerMask whatIsGround;
  public float groundDistance = 0.3f;

  public float moveSpeed = 0.0f;


  Animator anim;
  Rigidbody rigidBody;

    void Start()
    {
      anim = GetComponent<Animator>();
      rigidBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {


       float moveVertical = Input.GetAxis ("Vertical");
       float moveHorizontal = Input.GetAxis("Horizontal");

      if(Input.GetKey(KeyCode.LeftShift)){
        moveSpeed = 1f;
      } else {
        moveSpeed = 0.5f;
      }


       print(Input.GetAxis ("Vertical"));


        anim.SetFloat("vertical", moveVertical*moveSpeed);
        anim.SetFloat("horizontal", moveHorizontal);


        if(Input.GetKeyDown("space")) {
          rigidBody.AddForce(Vector3.up * jumpForce);
          anim.SetTrigger("Jump");
        }

        if(Physics.Raycast(transform.position + (Vector3.up* 0.1f), Vector3.down, groundDistance, whatIsGround)){
          anim.SetBool("grounded", true);
         anim.applyRootMotion = true;
       } else {
         anim.SetBool("grounded", false);
       }

        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        // if(Input.GetKeyDown(KeyCode.Space) && stateInfo.nameHash == runStateHash)
        // {
        //     anim.SetTrigger (jumpHash);
        // }



       // rotation += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
       // if(moveVertical == 0){
       //   transform.eulerAngles = new Vector3(0,rotation,0);
       // }

    }
}