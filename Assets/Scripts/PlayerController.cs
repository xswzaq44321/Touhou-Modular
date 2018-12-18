using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed, shoot_delay_short, shoot_delay_long;
    public GameObject normal_bullet, trace_bullet;
    private Vector3 direction;
    private float delay_time_short, delay_time_long;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //move//
        direction = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow))
            direction += Vector3.up;
        else if (Input.GetKey(KeyCode.DownArrow))
            direction += Vector3.down;
        if (Input.GetKey(KeyCode.RightArrow))
            direction += Vector3.right;
        else if (Input.GetKey(KeyCode.LeftArrow))
            direction += Vector3.left;
        if(Input.GetKey(KeyCode.LeftShift))
            transform.position += direction.normalized * speed * 0.7f * Time.deltaTime;
        else
            transform.position += direction.normalized * speed * Time.deltaTime;

        //normal bullet//
        delay_time_short += Time.deltaTime;
        if (delay_time_short >= shoot_delay_short && Input.GetKey(KeyCode.Z))
        {
            delay_time_short = 0;
            GameObject bullet = Instantiate(normal_bullet);
            bullet.GetComponent<Shoot>().direction = Vector3.up;
            bullet.transform.position = transform.position;
        }

        //trace bullet//
        delay_time_long += Time.deltaTime;
        if (delay_time_long >= shoot_delay_short && Input.GetKey(KeyCode.Z))
        {
            delay_time_long = 0;
            GameObject bullet = Instantiate(trace_bullet);
            bullet.GetComponent<Shoot>().direction = new Vector3(1, 1.732f, 0);
            //bullet.GetComponent<Trace>().set_range(30);
            bullet.transform.position = transform.position;
        }

    }
}
