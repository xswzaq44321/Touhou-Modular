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
            radiate("pink_load", "pink_circle_small", 1, 6, a, 2);
            a += 11;
        }
        if (Input.GetKeyDown(KeyCode.N))
            laser("red_laser", transform.position, player_direction(transform), 1);
    }

    /* 1. use as even number danmaku, cannot track
     * 2. use as single bullet, ex: evenN_way("load_type", "bullet_type", 1, 0, speed, degree);
     * 3. use as circle, ex: evenN_way("load_type", "bullet_type", evenN, 360 / evenN, speed, 0, 3, angle); */
    public void evenN_way(string load_type, string bullet_type, int even_N, float interval, float speed, float degree = -90, float initial_radius = 0, float direction = 0)
    {
        direction *= Mathf.Deg2Rad;
        for (int i = 0; i < even_N; i++)
        {
            float rad = (degree - interval * (i - even_N / 2 + 1) + interval / 2) * Mathf.Deg2Rad;
            bullet = Instantiate(Resources.Load("prefab/" + load_type) as GameObject);
            bullet.transform.position = transform.position + new Vector3(Mathf.Cos(rad), Mathf.Sin(rad)) * initial_radius;
            bullet.GetComponent<Load>().set_bullet(bullet_type, speed, new Vector3(Mathf.Cos(rad + direction), Mathf.Sin(rad + direction)));
        }
    }

    //odd number danmaku, automaticly track//
    public void oddN_way(string load_type, string bullet_type, int odd_N, float interval, float speed, float initial_radius = 0)
    {
        for (int i = 0; i < odd_N; i++)
        {
            float rad = ((i - odd_N / 2) * interval + player_direction(transform)) * Mathf.Deg2Rad;
            bullet = Instantiate(Resources.Load("prefab/" + load_type) as GameObject);
            bullet.transform.position = transform.position + new Vector3(Mathf.Cos(rad), Mathf.Sin(rad)) * initial_radius;
            bullet.GetComponent<Load>().set_bullet(bullet_type, speed, new Vector3(Mathf.Cos(rad), Mathf.Sin(rad)));
        }
    }

    //radiate danmaku//
    public void radiate(string load_type, string bullet_type, int N, float speed, float degree = -90, float initial_radius = 0)
    {
        for(int i = 0; i < N; i++)
        {
            float rad = (i * 360 / N + degree) * Mathf.Deg2Rad;
            bullet = Instantiate(Resources.Load("prefab/" + load_type) as GameObject);
            bullet.transform.position = transform.position + new Vector3(Mathf.Cos(rad), Mathf.Sin(rad)) * initial_radius;
            bullet.GetComponent<Load>().set_bullet(bullet_type, speed, new Vector3(Mathf.Cos(rad), Mathf.Sin(rad)));
        }
    }

    //laser//
    public void laser(string laser_type, Vector3 str_point, float angle, float time)
    {
        bullet = Instantiate(Resources.Load("prefab/" + laser_type) as GameObject);
        bullet.transform.position = str_point;
        bullet.GetComponent<Laser>().set_laser(angle, time);
    }

    //return the angle between pos and player//
    public float player_direction(Transform pos)
    {
        Vector2 direction = transform.parent.GetComponent<Player>().sprite.transform.GetChild(0).position - pos.position;
        float angle = Vector2.Angle(direction, transform.right);
        return (Vector2.Dot(direction, transform.up) >= 0) ? angle : -angle; 
    }
}
