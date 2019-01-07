﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpItem : MonoBehaviour {

    public float init_speed;
    public int effect = 1;
    public bool pause = false;

	// Use this for initialization
	void Start () {
        init_speed += Random.Range(-2, 2);
	}
	
	// Update is called once per frame
	void Update () {
        //pause//
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = pause ? false : true;
        }
        if (pause) return;

        //falling//
        init_speed += (-9.8f - init_speed * 1.5f) * Time.deltaTime;
        transform.position += Vector3.up * init_speed * Time.deltaTime;
        if (transform.position.y > 100) Destroy(gameObject);//need to change after the UI is completed
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if (gameObject.tag == "Point")
                col.GetComponent<PlayerController>().point += effect;
            else if (gameObject.tag == "Power")
                col.GetComponent<PlayerController>().power += effect;
            Destroy(gameObject);
        }
    }
}
