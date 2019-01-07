using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    private Vector3 direction;
    private float laser_time, angle = 0, angular_speed = 0;
    private bool preparing = true;
    private Vector2 reset;
    public bool pause = false;

	// Use this for initialization
	void Start () {
        transform.localScale = new Vector3(0, 0.1f, 1);
        Destroy(transform.GetChild(0).GetComponent<Rigidbody2D>());
        reset = transform.GetChild(0).GetComponent<BoxCollider2D>().offset;
        transform.GetChild(0).GetComponent<BoxCollider2D>().offset = Vector2.one * -100;
    }
	
	// Update is called once per frame
	void Update () {
        //pause//
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = pause ? false : true;
        }
        if (pause) return;

        //laser//
        if (preparing)
        {
            if (transform.localScale.x < 3)
                transform.localScale += new Vector3(6, 0, 0) * Time.deltaTime;
            else if (transform.localScale.y < 1)
                transform.localScale += new Vector3(0, 3, 0) * Time.deltaTime;
            else
            {
                preparing = false;
                gameObject.AddComponent<Rigidbody2D>();
                GetComponent<Rigidbody2D>().isKinematic = true;
                transform.GetChild(0).GetComponent<BoxCollider2D>().offset = reset;
            }
        }
        else
        {
            if(angle > 0)
            {
                transform.Rotate(new Vector3(0, 0, angular_speed * Time.deltaTime));
                angle -= Mathf.Abs(angular_speed) * Time.deltaTime;
            }
            else
                laser_time -= Time.deltaTime;
            if (laser_time <= 0)
            {
                if(transform.localScale.x > 0)
                    transform.localScale -= new Vector3(12, 6, 0) * Time.deltaTime;
                else
                    Destroy(gameObject);
            }
        }
    }

    public void set_laser(float direction, float time)
    {
        transform.Rotate(new Vector3(0, 0, direction));
        laser_time = time;
    }

    public void set_rotate(float _angle, float _angular_speed)
    {
        angle = _angle;
        angular_speed = _angular_speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "HitPoint")
            col.transform.parent.GetComponent<PlayerController>().addHP(-1);
    }
}
