using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpItem : MonoBehaviour {

    public float init_speed;
    public int effect = 1;
	// Use this for initialization
	void Start () {
        init_speed += Random.Range(-2, 2);
	}
	
	// Update is called once per frame
	void Update () {
        init_speed += (-9.8f - init_speed) * Time.deltaTime;
        transform.position += Vector3.up * init_speed * Time.deltaTime;
        if (transform.position.y > 100) Destroy(gameObject);//need to change after the UI is completed
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if (gameObject.tag == "Point")
                col.GetComponent<PlayerController>().point += effect;
            else if (gameObject.tag == "Power")
                col.GetComponent<PlayerController>().power += effect;
            Destroy(gameObject);
        }
    }
}
