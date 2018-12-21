using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpItem : MonoBehaviour {

    public float init_speed;
    private float start_time;
	// Use this for initialization
	void Start () {
        start_time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        init_speed += (-9.8f - init_speed) * Time.deltaTime;
        transform.position += Vector3.up * init_speed * Time.deltaTime;
	}
}
