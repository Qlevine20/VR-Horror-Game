using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    public GameObject bullet;
    private Transform viewer;
    // Use this for initialization
    void Start () {
        viewer = GameObject.Find("Camera").transform;
	}

    // Update is called once per frame
    void Update()
    {
        if (GvrViewer.Instance.VRModeEnabled && GvrViewer.Instance.Triggered)
        {
            GameObject b = (GameObject)Instantiate(bullet, new Vector3(transform.position.x, transform.position.y - .1f, transform.position.z + 1), Quaternion.identity);
        }
        transform.rotation = viewer.rotation;
    }
}
