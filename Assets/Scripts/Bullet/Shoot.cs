using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public Vector3 direction;
    public float speed, rotation = 0;
    public int atk;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += direction.normalized * speed * Time.deltaTime;
        transform.Rotate(0, 0, rotation);
        //Debug.Log(transform.position);
        if (transform.position.y > 10) Destroy(gameObject);
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (tag == "PlayerBullet" && col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Health>().HP -= atk;
            Destroy(gameObject);
        }
        else if(tag == "EnemyBullet" && col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Health>().HP -= atk;
            Destroy(gameObject);
        }
    }

}
