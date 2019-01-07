using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale = new Vector3(4.6f * transform.parent.GetComponent<EnemyController>().HP / transform.parent.GetComponent<EnemyController>().max_HP, 0.3187497f, 1);
    }
}
