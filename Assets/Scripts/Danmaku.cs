using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danmaku : MonoBehaviour {

    // Use this for initialization
    GameObject bullet;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.M))
            radiate("red_load", "red_circle_small", 10, 10, 0, 0.5f);
        if (Input.GetKeyDown(KeyCode.N))
            evenN_way("red_load", "red_circle_small", 6, 10, 10, -90, 1);
    }

    //even number danmaku, cannot track//
    void evenN_way(string load_type, string bullet_type, int even_N, float interval, float speed, float degree = -90, float initial_radius = 0)
    {
        for (int i = 0; i < even_N; i++)
        {
            float rad = (degree - interval * (i - even_N / 2 + 1) + interval / 2) * Mathf.Deg2Rad;
            bullet = Instantiate(Resources.Load("prefab/" + load_type) as GameObject);
            bullet.transform.position = transform.position + new Vector3(Mathf.Cos(rad), Mathf.Sin(rad)) * initial_radius;
            bullet.GetComponent<Load>().set_bullet(bullet_type, speed, new Vector3(Mathf.Cos(rad), Mathf.Sin(rad)));
        }
    }

    //odd number danmaku, automaticly track//
    void oddN_way(string load_type, string bullet_type, int odd_N, float interval, float speed, float initial_radius = 0)
    {
        Vector2 player_direction = transform.parent.GetComponent<Player>().sprite.transform.GetChild(0).position - transform.position;
        float angle = Vector2.Angle(player_direction, transform.right);
        if (Vector2.Dot(player_direction, transform.up) < 0)
            angle *= -1;
        for (int i = 0; i < odd_N; i++)
        {
            float rad = ((i - odd_N / 2) * interval + angle) * Mathf.Deg2Rad;
            bullet = Instantiate(Resources.Load("prefab/" + load_type) as GameObject);
            bullet.transform.position = transform.position + new Vector3(Mathf.Cos(rad), Mathf.Sin(rad)) * initial_radius;
            bullet.GetComponent<Load>().set_bullet(bullet_type, speed, new Vector3(Mathf.Cos(rad), Mathf.Sin(rad)));
        }
    }

    //radiate danmaku//
    void radiate(string load_type, string bullet_type, int N, float speed, float degree = -90, float initial_radius = 0)
    {
        for(int i = 0; i < N; i++)
        {
            float rad = (i * 360 / N + degree) * Mathf.Deg2Rad;
            bullet = Instantiate(Resources.Load("prefab/" + load_type) as GameObject);
            bullet.transform.position = transform.position + new Vector3(Mathf.Cos(rad), Mathf.Sin(rad)) * initial_radius;
            bullet.GetComponent<Load>().set_bullet(bullet_type, 10, new Vector3(Mathf.Cos(rad), Mathf.Sin(rad)));
        }
    }
}
