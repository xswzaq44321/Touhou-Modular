using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.localScale = Vector3.zero;
        transform.Rotate(0, 0, Random.Range(0, 360));
    }

    // Update is called once per frame
    void Update () {
        if (transform.GetComponent<SpriteRenderer>().color.a > 0)
        {
            transform.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 3) * Time.deltaTime;
            transform.localScale += Vector3.one * 15 * Time.deltaTime;
        }
        else Destroy(gameObject);
    }
}
