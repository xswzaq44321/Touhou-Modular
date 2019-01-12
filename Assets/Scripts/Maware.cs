using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maware : MonoBehaviour {

    public float speed;
    public float expand;
    private float init_size;

	// Use this for initialization
	void Start () {
        init_size = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {

        //mare mare mare mare mare mare mare mare maware//
        transform.Rotate(Vector3.back * speed * Time.deltaTime);
        if ((Mathf.Abs(transform.localScale.x - init_size) >= 0.3f))
            expand *= -1;
        transform.localScale += Vector3.one * expand * Time.deltaTime;
	}
}
