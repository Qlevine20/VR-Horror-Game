using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerBehaviour : MonoBehaviour
{

    public GameObject bullet;
    private Transform viewer;
    public bool safe = true;
    public Transform currLight;
    public AICharacterControl nav;
    // Use this for initialization
    void Start()
    {
        //viewer = GameObject.Find("Camera").transform;
        nav = GameObject.FindGameObjectWithTag("Demon").GetComponentInChildren<AICharacterControl>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (GvrViewer.Instance.VRModeEnabled && GvrViewer.Instance.Triggered)
        //{
        //    GameObject b = (GameObject)Instantiate(bullet, new Vector3(transform.position.x, transform.position.y - .1f, transform.position.z + 1), Quaternion.identity);
        //}
        //transform.rotation = viewer.rotation;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Light")
        {
            safe = true;
            nav.SetTarget(other.transform.FindChild("Plane").FindChild("lightTarget"));
            currLight = other.gameObject.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Light")
        {
            currLight = null;
            nav.SetTarget(transform);
            safe = false;
        }

    }


}

