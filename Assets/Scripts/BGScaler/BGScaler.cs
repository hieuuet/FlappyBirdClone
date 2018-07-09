using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //height bug
        SpriteRenderer sr = GetComponent<SpriteRenderer>    ();
        Vector3 tempScale = transform.localScale; //lay scale hien tai

        float height = sr.bounds.size.y; //lay gioi han chieu 
        float width = sr.bounds.size.x;

        float worldHeight = Camera.main.orthographicSize * 2f; //scale height
        float worldWidth = worldHeight * Screen.width / Screen.height; //scale width

        tempScale.y = worldHeight / height;
        tempScale.x = worldWidth / width;

        transform.localScale = tempScale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
