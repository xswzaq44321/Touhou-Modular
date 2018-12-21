using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    public float speed;
	// Use this for initialization
	void Start () {
        transform.GetChild(1).position = transform.GetChild(0).position + Vector3.up * 19.9f;
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(transform.GetChild(0).position.y);
        transform.GetChild(0).position += Vector3.down * speed * Time.deltaTime;
        transform.GetChild(1).position += Vector3.down * speed * Time.deltaTime;
        if(transform.GetChild(0).position.y < -20)
        {
            transform.GetChild(0).position = transform.GetChild(1).position + Vector3.up * 19.9f;
        }
        else if (transform.GetChild(1).position.y < -20)
        {
            transform.GetChild(1).position = transform.GetChild(0).position + Vector3.up * 19.9f;
        }

    }
}
