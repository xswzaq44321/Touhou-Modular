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
            radiate("red_circle_small", 10, 10, 0);
    }

    //even number danmaku, cannot track//
    void N_way(string type, int even_N, float interval, float speed, float degree)
    {
        for (int i = 0; i < even_N; i++)
        {
            float rad = (degree - interval * (i - even_N / 2 + 1) + interval / 2) * Mathf.Deg2Rad;
            bullet = Instantiate(Resources.Load("prefab/" + type) as GameObject);
            bullet.transform.position = transform.position;
            bullet.GetComponent<Shoot>().direction = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad));
            bullet.GetComponent<Shoot>().speed = speed;
        }
    }

    //odd number danmaku, automaticly track//
    void N_way(string type, int odd_N, float interval, float speed)
    {

        for (int i = 0; i < odd_N; i++)
        {
            float rad = ((i - odd_N / 2) * interval + Vector2.Angle(transform.parent.GetComponent<Player>().sprite.transform.position, transform.right) * Vector2.Dot(transform.parent.GetComponent<Player>().sprite.transform.position, transform.up) / Mathf.Abs(Vector2.Dot(transform.parent.GetComponent<Player>().sprite.transform.position, transform.up))) * Mathf.Deg2Rad;
            bullet = Instantiate(Resources.Load("prefab/" + type) as GameObject);
            bullet.transform.position = transform.position;
            bullet.GetComponent<Shoot>().direction = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad));
            bullet.GetComponent<Shoot>().speed = speed;
        }
    }

    //radiate danmaku//
    void radiate(string type, int N, float speed, float degree)
    {
        for(int i = 0; i < N; i++)
        {
            float rad = (i * 360 / N + degree) * Mathf.Deg2Rad;
            bullet = Instantiate(Resources.Load("prefab/" + type) as GameObject);
            bullet.transform.position = transform.position;
            bullet.GetComponent<Shoot>().direction = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad));
            bullet.GetComponent<Shoot>().speed = speed;
        }
    }
}
