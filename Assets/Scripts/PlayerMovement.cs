﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {




    private Rigidbody rb;
    public float speed;
    private Transform playerBehav;
    private bool isGrounded = true;
    private Ray r;
    public float GroundCheckDist;
    private bool jump = false;
    public LayerMask layerMask;
    private bool canJump = true;
	// Use this for initialization
	void Start () {
        playerBehav = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
        r = new Ray(transform.position, -transform.up * GroundCheckDist);
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (h != 0 || v != 0)
        {
            transform.Translate(playerBehav.right * h * Time.deltaTime * speed);
            transform.Translate(playerBehav.forward * v * Time.deltaTime * speed);
        }

        if(GvrViewer.Instance.VRModeEnabled && GvrViewer.Instance.BackButtonPressed && isGrounded && canJump|| Input.GetKeyDown(KeyCode.Space) && isGrounded && canJump)
        {

            isGrounded = false;
            StartCoroutine(CanJumpEnumerator());
            jump = true;
        }
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        if (!isGrounded && Physics.Raycast(r, out hit, GroundCheckDist) && canJump)
        {
            isGrounded = true;
        }

        if (jump)
        {
            jump = false;
            rb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
        }
    }

    IEnumerator CanJumpEnumerator()
    {
        canJump = false;
        yield return new WaitForSeconds(1f);
        canJump = true;
    }

    
}
