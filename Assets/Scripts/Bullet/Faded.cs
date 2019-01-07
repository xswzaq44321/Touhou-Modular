using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faded : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<SpriteRenderer>().color.a > 0)
            GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 2) * Time.deltaTime;
	}
}
