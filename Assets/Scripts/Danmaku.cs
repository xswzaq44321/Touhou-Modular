using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danmaku : MonoBehaviour {
    GameObject bullet;
    private float a = 0;
    private int way = 1;
    private float delay;

    // Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
        delay += Time.deltaTime;
        if (Input.GetKey(KeyCode.M))
        {
            if(gameObject.name == "flandre" && delay >= 0.025f)
            {
                delay = 0;
                a++;
                radiate("pink_load", "pink_circle_small", 1, 4.4f, a * 11, 2 - a * 0.01f);
                radiate("pink_load", "pink_circle_small", 1, 5.0f, a * 11, 2 - a * 0.01f);
                radiate("pink_load", "pink_circle_small", 1, 5.6f, a * 11, 2 - a * 0.01f);
                radiate("pink_load", "pink_circle_small", 1, 6.2f, a * 11, 2 - a * 0.01f);
                radiate("pink_load", "pink_circle_small", 1, 4.4f, -a * 11, 2 - a * 0.01f);
                radiate("pink_load", "pink_circle_small", 1, 5.0f, -a * 11, 2 - a * 0.01f);
                radiate("pink_load", "pink_circle_small", 1, 5.6f, -a * 11, 2 - a * 0.01f);
                radiate("pink_load", "pink_circle_small", 1, 6.2f, -a * 11, 2 - a * 0.01f);

                if(a < 50)
                {
                    radiate("cyan_load", "cyan_seed", 1, 1.4f, a * 11 + 180, 1.5f - a * 0.02f);
                    radiate("cyan_load", "cyan_seed", 1, 2.0f, a * 11 + 180, 1.5f - a * 0.02f);
                    radiate("cyan_load", "cyan_seed", 1, 2.6f, a * 11 + 180, 1.5f - a * 0.02f);
                    radiate("cyan_load", "cyan_seed", 1, 3.2f, a * 11 + 180, 1.5f - a * 0.02f);
                    radiate("cyan_load", "cyan_seed", 1, 1.4f, -a * 11 + 180, 1.5f - a * 0.02f);
                    radiate("cyan_load", "cyan_seed", 1, 2.0f, -a * 11 + 180, 1.5f - a * 0.02f);
                    radiate("cyan_load", "cyan_seed", 1, 2.6f, -a * 11 + 180, 1.5f - a * 0.02f);
                    radiate("cyan_load", "cyan_seed", 1, 3.2f, -a * 11 + 180, 1.5f - a * 0.02f);
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.M)) a = 0;

        if (Input.GetKey(KeyCode.N))
        {
            if (delay >= 0.2f)
            {
                laser("red_laser", transform.position, player_direction(transform) + Random.Range(-15, 15), 1);
                delay = 0;
            }
        }

        if (gameObject.name == "flandre" && Input.GetKey(KeyCode.B))
        {
            if (delay >= 0.015f)
            {
                a++;
                float b = a;
                if (b > 15) b = 15;
                radiate("yellow_load", "yellow_circle_small", 12, 2 + b * 0.1f, a * 35f, 5 - a * 0.05f);
                delay = 0;
            }
        }
        if (gameObject.name == "flandre" && Input.GetKeyUp(KeyCode.B)) a = 0;

        if (gameObject.name == "flandre" && Input.GetKeyDown(KeyCode.V))
        {
            GetComponent<EnemyController>().move_straight(way += 180, 5, 2);
            laser("blue_laser", transform.position, -60, 3, 315, 300);
            laser("blue_laser", transform.position, 240, 3, 315, -300);
        }
        if (gameObject.name == "flandre" && Input.GetKey(KeyCode.C))
        {
            string[] col = new string[6] { "red", "yellow", "blue", "green", "pink", "white" };
            int ccc = Random.Range(0, 6);
            if (delay >= 0.5f)
                for(int i = 0; i < 2; i++)
                    shoot(col[ccc] + "_load", col[ccc] + "_seed", new Vector2(Random.Range(-7, 5.0f), transform.position.y + 1), 7, -90);
        }

        if (gameObject.name == "flandre" && Input.GetKeyDown(KeyCode.P))
            GetComponent<EnemyController>().move_straight(0, 1, 3);
        if (gameObject.name == "flandre" && Input.GetKeyDown(KeyCode.O))
            GetComponent<EnemyController>().move_straight(180, 1, 3);

        if (gameObject.name == "flandre" && Input.GetKeyDown(KeyCode.L))
        {
            for(int i = 0; i < 2; i++)
            {
                laser("green_laser", transform.position + Vector3.right * 2 + Vector3.down * 3, 0 + 180 * i, 1, 180, -30);
                laser("green_laser", transform.position + Vector3.left * 2 + Vector3.down * 6, 90 + 180 * i, 1, 180, -30);
            }
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

    public void shoot(string load_type, string bullet_type, Vector2 pos, float speed, float degree)
    {
        bullet = Instantiate(Resources.Load("prefab/" + load_type) as GameObject);
        bullet.transform.position = pos;
        bullet.GetComponent<Load>().set_bullet(bullet_type, speed, degree);
    }


    //laser//
    public void laser(string laser_type, Vector3 str_point, float str_angle, float time, float angle = 0, float angular_speed = 0)
    {
        bullet = Instantiate(Resources.Load("prefab/" + laser_type) as GameObject);
        bullet.transform.parent = transform;
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
