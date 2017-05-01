using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour {

    private Transform p;
    private float xDist;
    private float yDist;
    private float zDist;
	// Use this for initialization
	void Start () {
        p = GameObject.Find("PlayerHolder").transform;
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = p.position;
	}
}
