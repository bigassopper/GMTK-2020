﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursosPlace : MonoBehaviour
{
    private SpriteRenderer opacity;
    public GameObject pointer;
    public LayerMask button;
    private Vector2 cursorPos;


    public void Start()
    {
        opacity = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (gameStates.noControl == false)
        {

            opacity.color = new Color(0f, 0f, 0f, 0f);

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, button);

            if (hit)
            {
                if (hit.collider.tag == "Button")
                {
                    opacity.color = new Color(1f, 1f, 1f, 1f);

                    cursorPos = hit.collider.gameObject.transform.position;
                    pointer.transform.position = new Vector2(cursorPos.x, cursorPos.y);

                    if (Input.GetButton("Fire1"))
                    {
                        gameStates.noW = true;
                        gameStates.noControl = true;
                    }
                }

                if (hit.collider.tag == "A")
                {
                    opacity.color = new Color(1f, 1f, 1f, 1f);

                    cursorPos = hit.collider.gameObject.transform.position;
                    pointer.transform.position = new Vector2(cursorPos.x, cursorPos.y);

                    if (Input.GetButton("Fire1"))
                    {
                        gameStates.noA = true;
                        gameStates.noControl = true;
                    }
                }

                if (hit.collider.tag == "S")
                {
                    opacity.color = new Color(1f, 1f, 1f, 1f);

                    cursorPos = hit.collider.gameObject.transform.position;
                    pointer.transform.position = new Vector2(cursorPos.x, cursorPos.y);

                    if (Input.GetButton("Fire1"))
                    {
                        gameStates.noS = true;
                        gameStates.noControl = true;
                    }
                }

                if (hit.collider.tag == "D")
                {
                    opacity.color = new Color(1f, 1f, 1f, 1f);

                    cursorPos = hit.collider.gameObject.transform.position;
                    pointer.transform.position = new Vector2(cursorPos.x, cursorPos.y);

                    if (Input.GetButton("Fire1"))
                    {
                        gameStates.noD = true;
                        gameStates.noControl = true;
                    }
                }

                if (hit.collider.tag == "E")
                {
                    opacity.color = new Color(1f, 1f, 1f, 1f);

                    cursorPos = hit.collider.gameObject.transform.position;
                    pointer.transform.position = new Vector2(cursorPos.x, cursorPos.y);

                    if (Input.GetButton("Fire1"))
                    {
                        gameStates.noE = true;
                        gameStates.noControl = true;
                    }
                }

                if (hit.collider.tag == "F")
                {
                    opacity.color = new Color(1f, 1f, 1f, 1f);

                    cursorPos = hit.collider.gameObject.transform.position;
                    pointer.transform.position = new Vector2(cursorPos.x, cursorPos.y);

                    if (Input.GetButton("Fire1"))
                    {
                        gameStates.noF = true;
                        gameStates.noControl = true;
                    }
                }
            }

            if(gameStates.noControl == true)
            {
                opacity.color = new Color(0f, 0f, 0f, 0f);
            }
        }
    }
}
