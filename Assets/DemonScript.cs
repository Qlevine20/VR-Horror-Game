using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonScript : MonoBehaviour {


    private Terrain terr;
    public float minDistToSpawn;
    public float maxDistToSee;
    private Renderer rend;
    private bool seen = false;
    private GameObject player;
	// Use this for initialization
	void Start () {
        terr = GameObject.Find("Terrain").GetComponent<Terrain>();
        rend = GetComponentInChildren<Renderer>();
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if(rend.isVisible && GvrViewer.Instance.enabled && !seen && Vector3.Distance(transform.position,player.transform.position) < maxDistToSee)
        {
            seen = true;
            StartCoroutine(WhenSeenByPlayer(5));
        }
	}


    public IEnumerator WhenSeenByPlayer(int waitTime)
    {
        seen = true;
        Debug.Log("Seen");
        yield return new WaitForSeconds(waitTime);
        Vector3 oldPos = transform.position;
        transform.position = new Vector3(Random.Range(0, terr.terrainData.size.x), 0, Random.Range(0, terr.terrainData.size.z));
        while(Vector3.Distance(transform.position,oldPos) < minDistToSpawn)
        {
            transform.position = new Vector3(Random.Range(0, terr.terrainData.size.x), 0, Random.Range(0, terr.terrainData.size.z));
        }
        seen = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            seen = true;
            StartCoroutine(WhenSeenByPlayer(0));
        }
    }

    


}
