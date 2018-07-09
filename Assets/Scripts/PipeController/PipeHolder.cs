﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeHolder : MonoBehaviour {
    public float speed;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(BirdController.instance.flag != null){
            if(BirdController.instance.flag ==1){
                Destroy(GetComponent<PipeHolder>());
            }
        }
        _PipeMovement();
	}
    void _PipeMovement() {
        Vector3 temp = transform.position; //lay vi tri hien tai cua pipe holder
        temp.x -= speed * Time.deltaTime; // Time.deltaTime cho muot hon
        transform.position = temp;
    }

	private void OnTriggerEnter2D(Collider2D target)
	{
        if(target.tag == "Destroy"){
            Destroy(gameObject);
        }
		
	}
}
