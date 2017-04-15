using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour {

    Rigidbody rb;
    private float bulletSpeed = 100;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate() {
        rb.AddForce(transform.forward * bulletSpeed);
    }
}
