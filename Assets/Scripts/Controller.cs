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
    public GameObject scratch;
    public scrathBreak sb;
    private GameObject[] scrathL;
    private GameObject[] doorL;
    private GameObject[] policeL;

    public GameObject walko;
    public GameObject swingo;
    public GameObject hito;
    public GameObject brako;
    public GameObject openo;


    public AudioSource walk;
    public AudioSource swing;
    public AudioSource hit;
    public AudioSource brak;
    public AudioSource open;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        scrathL = GameObject.FindGameObjectsWithTag("Scratch");
        doorL = GameObject.FindGameObjectsWithTag("Door");
        policeL = GameObject.FindGameObjectsWithTag("Police");

        walko = GameObject.Find("Walk");
        swingo = GameObject.Find("Swing");
        hito = GameObject.Find("Hit");
        brako = GameObject.Find("Door");
        openo = GameObject.Find("Break");

        walk = walko.GetComponent<AudioSource>();
        swing = swingo.GetComponent<AudioSource>();
        hit = hito.GetComponent<AudioSource>();
        brak = brako.GetComponent<AudioSource>();
        open = openo.GetComponent<AudioSource>();
        if(brak == null)
        {
            brak = brako.GetComponent<AudioSource>();
        }

        foreach (GameObject police in policeL)
        {
            if (Vector2.Distance(police.transform.position, transform.position) < 1)
            {
                ep = police.GetComponent<enemyPatrol>();
            }
        }

        foreach (GameObject scrat in scrathL)
        {
            if (Vector2.Distance(scrat.transform.position, transform.position) < 1)
            {
                sb = scrat.GetComponent<scrathBreak>();
            }
        }

        foreach (GameObject door in doorL)
        {
            if (Vector2.Distance(door.transform.position, transform.position) < 1)
            {
                ut = door.GetComponent<usableThings>();
            }
        }


        if (gameStates.noControl)
        {

            if (Input.GetKeyDown(KeyCode.E) && gameStates.noE == false)
            {
                if (ut != null)
                {
                    if (ut.onDoor == true)
                    {
                        open.Play();
                        ut.Open();
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.F) && gameStates.noF == false)
            {
                anim.SetTrigger("Attack");
                swing.Play();

                if(ep != null){
                    if (ep.onGuard == true)
                    { 
                        hit.Play();
                        ep.Attack();                      
                    }
                }

                if(sb != null)
                {
                    if(sb.onScratch == true)
                    {
                        if (brak != null)
                        {
                            brak.Play();
                        }
                        sb.Break();
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
                walk.Play();
            }
            else
            {
                anim.SetBool("walk", false);
            }

            rb.velocity = playerInput.normalized * movSpeed;
        }
    }
}

