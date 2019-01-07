using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour {

    public float speed, mist_speed;
    public bool pause = false;
	// Use this for initialization
	void Start () {
        //Debug.Log(transform.GetChild(1).GetComponent<Image>().sprite.rect.height);
        transform.GetChild(1).position = transform.GetChild(0).position + Vector3.up * 19.988f;
        transform.GetChild(3).position = transform.GetChild(2).position + Vector3.up * 19.988f;
    }

    // Update is called once per frame
    void Update () {
        //pause//
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = pause ? false : true;
        }
        if (pause) return;

        //move the background//
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
