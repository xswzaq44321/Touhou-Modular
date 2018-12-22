﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invinsible : MonoBehaviour {

    private float start_time, flash_time = 0, collider_radius;
    public float invinsible_time = 5;

	// Use this for initialization
	void Start () {
        start_time = Time.time;
        Destroy(transform.GetChild(0).GetComponent<Rigidbody2D>());
        transform.GetChild(0).GetComponent<CircleCollider2D>().isTrigger = false;
    }

    // Update is called once per frame
    void Update () {
        flash_time += Time.deltaTime;
        if (flash_time >= 0.075f && flash_time < 0.15f)
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        else if (flash_time >= 0.15f)
        {
            flash_time = 0;
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        }

        if (Time.time - start_time >= invinsible_time)
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            transform.GetChild(0).gameObject.AddComponent<Rigidbody2D>();
            transform.GetChild(0).GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            transform.GetChild(0).GetComponent<CircleCollider2D>().isTrigger = true;
            Destroy(this);
        }
	}
}