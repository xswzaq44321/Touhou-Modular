using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {

    public bool pause = false;
    public float faded_speed, expand_speed;

	// Use this for initialization
	void Start () {
        transform.localScale = Vector3.zero;
        transform.Rotate(0, 0, Random.Range(0, 360));
    }

    // Update is called once per frame
    void Update () {
        //pause//
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = pause ? false : true;
        }
        if (pause) return;

        //explode//
        if (transform.GetComponent<SpriteRenderer>().color.a > 0)
        {
            transform.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, faded_speed / 255f) * Time.deltaTime;
            transform.localScale += Vector3.one * expand_speed * Time.deltaTime;
        }
        else Destroy(gameObject);
    }
}
