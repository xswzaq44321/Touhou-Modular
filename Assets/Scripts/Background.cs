using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    public float speed, mist_speed;
	// Use this for initialization
	void Start () {
        transform.GetChild(1).position = transform.GetChild(0).position + Vector3.up * 19.988f;
        transform.GetChild(3).position = transform.GetChild(2).position + Vector3.up * 19.988f;
    }

    // Update is called once per frame
    void Update () {
        transform.GetChild(0).position += Vector3.down * speed * Time.deltaTime;
        transform.GetChild(1).position += Vector3.down * speed * Time.deltaTime;
        transform.GetChild(2).position += Vector3.down * mist_speed * 1.5f * Time.deltaTime;
        transform.GetChild(3).position += Vector3.down * mist_speed * 1.5f * Time.deltaTime;
        if (transform.GetChild(0).position.y < -20)
            transform.GetChild(0).position = transform.GetChild(1).position + Vector3.up * 19.988f;
        else if (transform.GetChild(1).position.y < -20)
            transform.GetChild(1).position = transform.GetChild(0).position + Vector3.up * 19.988f;
        if (transform.GetChild(2).position.y < -20)
            transform.GetChild(2).position = transform.GetChild(3).position + Vector3.up * 19.988f;
        else if (transform.GetChild(3).position.y < -20)
            transform.GetChild(3).position = transform.GetChild(2).position + Vector3.up * 19.988f;

    }
}
