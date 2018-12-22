using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    private Vector3 direction;
    private float laser_time;
    private bool preparing = true;
    private Vector2 reset;
	// Use this for initialization
	void Start () {
        transform.localScale = new Vector3(0, 0.1f, 1);
        Destroy(transform.GetChild(0).GetComponent<Rigidbody2D>());
        reset = transform.GetChild(0).GetComponent<BoxCollider2D>().offset;
        transform.GetChild(0).GetComponent<BoxCollider2D>().offset = Vector2.one * -100;
    }
	
	// Update is called once per frame
	void Update () {
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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "HitPoint")
            col.transform.parent.GetComponent<PlayerController>().addHP(-1);
    }
}
