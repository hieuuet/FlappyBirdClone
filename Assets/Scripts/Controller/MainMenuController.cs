using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    public void _PlayButton (){
        Application.LoadLevel("GamePlay");
        //SceneManager.LoadScene("GamePlay");
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
