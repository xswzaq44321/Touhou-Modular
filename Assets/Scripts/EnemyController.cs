using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public string item = "";
    public int max_HP, HP, item_num = 1;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(HP <= 0)
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
