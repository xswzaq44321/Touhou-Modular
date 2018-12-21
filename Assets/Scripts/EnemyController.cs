using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public string item = "";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(GetComponent<Health>().HP <= 0)
        {
            if (item != "")
            {
                GameObject powerup = Instantiate(Resources.Load("prefab/" + item) as GameObject);
                powerup.transform.position = transform.position;
            }
            Destroy(gameObject);
        }
    }
}
