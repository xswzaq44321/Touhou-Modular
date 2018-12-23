using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danmaku : MonoBehaviour {

    // Use this for initialization
    GameObject bullet;
	void Start () {
		
	}

    private float a = 0;
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.M))
        {
            //for testing
            radiate("blue_load", "blue_seed", 1, 6, a, 2);
            radiate("blue_load", "blue_seed", 1, 6, a + 11, 2);
            radiate("blue_load", "blue_seed", 1, 6, a + 22, 2);
            a += 33;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            laser("yellow_laser", transform.position, player_direction(transform), 1);
            //laser("red_laser", transform.position, -60, 3, 300, 300);
            //laser("blue_laser", transform.position, 240, 3, 300, -300);
        }

    }

    /* 1. use as even number danmaku, cannot track
     * 2. use as single bullet, ex: evenN_way("load_type", "bullet_type", 1, 0, speed, degree);
     * 3. use as circle, ex: evenN_way("load_type", "bullet_type", evenN, 360 / evenN, speed, 0, 3, angle); */
    public void evenN_way(string load_type, string bullet_type, int even_N, float interval, float speed, float degree = -90, float initial_radius = 0, float direction = 0)
    {
        direction *= Mathf.Deg2Rad;
        for (int i = 0; i < even_N; i++)
        {
            float deg = (degree - interval * (i - even_N / 2 + 1) + interval / 2);
            float rad = deg * Mathf.Deg2Rad;
            bullet = Instantiate(Resources.Load("prefab/" + load_type) as GameObject);
            bullet.transform.position = transform.position + new Vector3(Mathf.Cos(rad), Mathf.Sin(rad)) * initial_radius;
            bullet.GetComponent<Load>().set_bullet(bullet_type, speed, deg);
        }
    }

    //odd number danmaku, automaticly track//
    public void oddN_way(string load_type, string bullet_type, int odd_N, float interval, float speed, float initial_radius = 0)
    {
        for (int i = 0; i < odd_N; i++)
        {
            float deg = ((i - odd_N / 2) * interval + player_direction(transform));
            float rad = deg * Mathf.Deg2Rad;
            bullet = Instantiate(Resources.Load("prefab/" + load_type) as GameObject);
            bullet.transform.position = transform.position + new Vector3(Mathf.Cos(rad), Mathf.Sin(rad)) * initial_radius;
            bullet.GetComponent<Load>().set_bullet(bullet_type, speed, deg);
        }
    }

    //radiate danmaku//
    public void radiate(string load_type, string bullet_type, int N, float speed, float degree = -90, float initial_radius = 0)
    {
        for(int i = 0; i < N; i++)
        {
            float deg = (i * 360 / N + degree);
            float rad = deg * Mathf.Deg2Rad;
            bullet = Instantiate(Resources.Load("prefab/" + load_type) as GameObject);
            bullet.transform.position = transform.position + new Vector3(Mathf.Cos(rad), Mathf.Sin(rad)) * initial_radius;
            bullet.GetComponent<Load>().set_bullet(bullet_type, speed, deg);
        }
    }

    //laser//
    public void laser(string laser_type, Vector3 str_point, float str_angle, float time, float angle = 0, float angular_speed = 0)
    {
        bullet = Instantiate(Resources.Load("prefab/" + laser_type) as GameObject);
        bullet.transform.position = str_point;
        bullet.GetComponent<Laser>().set_laser(str_angle, time);
        if (angle != 0 && angular_speed != 0)
            bullet.GetComponent<Laser>().set_rotate(angle, angular_speed);
    }

    //return the angle between pos and player//
    public float player_direction(Transform pos)
    {
        Vector2 direction = transform.parent.GetComponent<Player>().sprite.transform.GetChild(0).position - pos.position;
        float angle = Vector2.Angle(direction, transform.right);
        return (Vector2.Dot(direction, transform.up) >= 0) ? angle : -angle; 
    }
}
