﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    [SerializeField] Vector2 playerInput;
    Rigidbody2D rb;
    public Animator anim;
    public float movSpeed;
    public enemyPatrol ep;
    public usableThings ut;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (gameStates.noControl)
        {

            if (Input.GetKeyDown(KeyCode.E) && gameStates.noE == false)
            {
                if (ut != null)
                {
                    if (ut.onDoor == true)
                    {
                        ut.Open();
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.F) && gameStates.noF == false)
            {
                anim.SetTrigger("Attack");
                
                if(ep != null){
                    if (ep.onGuard == true)
                    {
                        ep.Attack();
                    }
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (gameStates.noControl)
        {

            playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (gameStates.noA)
            {
                if (playerInput.x == -1)
                {
                    movSpeed = 0;
                    anim.SetBool("walk", true);
                }
                else
                {
                    movSpeed = 6;
                }
            }

            if (gameStates.noD)
            {
                if (playerInput.x == 1)
                {
                    movSpeed = 0;
                }
                else
                {
                    movSpeed = 6;
                }
            }

            if (gameStates.noW)
            {
                if (playerInput.y == 1)
                {
                    movSpeed = 0;
                }
                else
                {
                    movSpeed = 6;
                }
            }

            if (gameStates.noS)
            {
                if (playerInput.y == -1)
                {
                    movSpeed = 0;
                }
                else
                {
                    movSpeed = 6;
                }
            }

            if(playerInput.x == 1 || playerInput.x == -1 || playerInput.y == 1 || playerInput.y == -1)
            {
                anim.SetBool("walk", true);
            }
            else
            {
                anim.SetBool("walk", false);
            }

            rb.velocity = playerInput.normalized * movSpeed;
        }
    }
}

