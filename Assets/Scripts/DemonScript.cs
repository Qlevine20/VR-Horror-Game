using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class DemonScript : MonoBehaviour {


    private Terrain terr;
    public float minDistToSpawn;
    public float maxDistToSee;
    private Renderer rend;
    private bool seen = false;
    private PlayerBehaviour player;
    private NavMeshAgent navAgent;
    private AICharacterControl nav;
    private bool waiting = false;
    public GameObject GameOverCanvas;
	// Use this for initialization
	void Start () {
        terr = GameObject.Find("Terrain").GetComponent<Terrain>();
        rend = GetComponentInChildren<Renderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerBehaviour>();
        navAgent = GetComponent<NavMeshAgent>();
        nav = GetComponentInChildren<AICharacterControl>();
        if(nav.target != null)
        {
            if (player.safe)
            {
                if(player.currLight != null)
                {
                    Transform t = player.currLight.FindChild("Plane").FindChild("lightTarget");
                    nav.SetTarget(t);
                }

            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	}

    public IEnumerator PlayerSafe(int waitTime)
    {
        navAgent.isStopped = true;
        transform.LookAt(player.transform);
        yield return new WaitForSeconds(waitTime);
        Vector3 oldPos = transform.position;
        MoveDemon(oldPos);
        waiting = false;


    }

    public IEnumerator WhenSeenByPlayer(int waitTime)
    {
        seen = true;
        yield return new WaitForSeconds(waitTime);
        Vector3 oldPos = transform.position;
        MoveDemon(oldPos);
        seen = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameManager.gameOver = true;
            GameOverCanvas.SetActive(true);
            navAgent.isStopped = true;

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "lightSource")
        {
            if (!waiting)
            {
                waiting = true;
                Debug.Log("Wait");
                StartCoroutine(PlayerSafe(3));
            }

        }
    }


    void MoveDemon(Vector3 oldPos)
    {
        while(Vector3.Distance(transform.position,oldPos) < minDistToSpawn)
        {
            Vector3 loc = new Vector3(Random.Range(0, terr.terrainData.size.z), 0, Random.Range(0, terr.terrainData.size.z));
            NavMeshHit hit;
            NavMesh.SamplePosition(loc, out hit, 100, -1);
            if (hit.position != new Vector3(Mathf.Infinity, Mathf.Infinity, Mathf.Infinity))
                transform.position = new Vector3(hit.position.x, transform.position.y, hit.position.z);
        }


        navAgent.isStopped = false;
    }

    


}
