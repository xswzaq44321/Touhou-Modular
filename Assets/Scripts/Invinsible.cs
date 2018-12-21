using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invinsible : MonoBehaviour {

    private float start_time, flash_time = 0;
    public float invinsible_time;
	// Use this for initialization
	void Start () {
        start_time = Time.time;
        Destroy(GetComponent<Rigidbody2D>());
	}
	
	// Update is called once per frame
	void Update () {
        flash_time += Time.deltaTime;
        if (flash_time >= 0.5f && flash_time < 1) ;
        //gameObject.SetActive(false);
        else if (flash_time >= 1)
        {
            flash_time = 0;
            //gameObject.SetActive(true);
        }

        if(Time.time - start_time >= invinsible_time)
        {
            gameObject.AddComponent<Rigidbody2D>();
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            Destroy(this);
        }
	}
}
