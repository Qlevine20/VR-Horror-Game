using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static bool gameOver;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameOver)
        {
            if (OVRInput.Get(OVRInput.Button.Two) || Input.GetKey(KeyCode.R))
            {
                EndGame();
            }
        }
	}

    public static void EndGame()
    {

        SceneManager.LoadScene("Scene1");
    }
}
