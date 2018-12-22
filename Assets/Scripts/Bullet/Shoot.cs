using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public Vector3 direction;
    public float speed;
    public int atk = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += direction.normalized * speed * Time.deltaTime;
        /*only destroy the one that surpass the upper screen,
        haven't done the ones that surpass the other sides of the screen.*/
        if (transform.position.y > 10) Destroy(gameObject);
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (tag == "PlayerBullet" && col.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyController>().HP -= atk;
            Destroy(gameObject);
        }
        else if(tag == "EnemyBullet" && col.tag == "HitPoint")
        {
            col.transform.parent.GetComponent<PlayerController>().addHP(-1);
            Destroy(gameObject);
        }
    }

}
