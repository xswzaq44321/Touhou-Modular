using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed, shoot_delay_short, shoot_delay_long;
    public GameObject normal_bullet, trace_bullet, enemy;
    private GameObject bullet;
    private Vector3 direction;
    private float delay_time_short, delay_time_long;
    public int power = 15, point = 0, graze = 0, max_HP, HP;
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
        {
            direction += Vector3.right;
            GetComponent<Animator>().SetFloat("speedX", 10);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction += Vector3.left;
            GetComponent<Animator>().SetFloat("speedX", -10);
        }
        else
            GetComponent<Animator>().SetFloat("speedX", 0);
        if (Input.GetKey(KeyCode.LeftShift))
            transform.position += direction.normalized * speed * 0.7f * Time.deltaTime;
        else
            transform.position += direction.normalized * speed * Time.deltaTime;

        //normal bullet//
        delay_time_short += Time.deltaTime;
        if (delay_time_short >= shoot_delay_short && Input.GetKey(KeyCode.Z))
        {
            delay_time_short = 0;
            if (power < 16)
            {
                bullet = Instantiate(normal_bullet);
                bullet.GetComponent<Shoot>().direction = Vector3.up;
                bullet.transform.position = transform.position;
            }
            else if(power >= 16 && power < 32)
            {
                //left bullet//
                bullet = Instantiate(normal_bullet);
                bullet.GetComponent<Shoot>().direction = new Vector3(-1, 19.43f, 0);
                bullet.transform.position = transform.position + Vector3.left * 0.2f;

                //right bullet//
                bullet = Instantiate(normal_bullet);
                bullet.GetComponent<Shoot>().direction = new Vector3(1, 19.43f, 0);
                bullet.transform.position = transform.position + Vector3.right * 0.2f;
            }
            else if (power >= 32)
            {
                //left bullet//
                bullet = Instantiate(normal_bullet);
                bullet.GetComponent<Shoot>().direction = new Vector3(-1, 11.43f, 0);
                bullet.transform.position = transform.position + Vector3.left * 0.37f;

                //mid bullet//
                bullet = Instantiate(normal_bullet);
                bullet.GetComponent<Shoot>().direction = Vector3.up;
                bullet.transform.position = transform.position;

                //right bullet//
                bullet = Instantiate(normal_bullet);
                bullet.GetComponent<Shoot>().direction = new Vector3(1, 11.43f, 0);
                bullet.transform.position = transform.position + Vector3.right * 0.37f;
            }
        }

        //trace bullet, over power 8//   
        delay_time_long += Time.deltaTime;
        if (delay_time_long >= shoot_delay_long && Input.GetKey(KeyCode.Z) && power >= 8)
        {
            delay_time_long = 0;

            //left side//
            bullet = Instantiate(trace_bullet);
            bullet.transform.position = transform.GetChild(0).position;
            bullet.GetComponent<Shoot>().direction = new Vector3(-1, 1.732f, 0);
            bullet.GetComponent<Trace>().target = enemy;

            //right side//
            bullet = Instantiate(trace_bullet);
            bullet.transform.position = transform.GetChild(1).position;
            bullet.GetComponent<Shoot>().direction = new Vector3(1, 1.732f, 0);
            bullet.GetComponent<Trace>().target = enemy;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "EnemyBullet") graze++;
    }

}