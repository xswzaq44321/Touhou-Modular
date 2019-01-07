using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public Vector3 direction;
    public float speed;
    public int atk = 1;
    public bool pause = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //pause//
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = pause ? false : true;
        }
        if (pause) return;

        transform.position += direction.normalized * speed * Time.deltaTime;
        /*only destroy the one that surpass the upper screen,
        haven't done the ones that surpass the other sides of the screen.*/
        if (transform.position.y > 10 || transform.position.y < -20) Destroy(gameObject);
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (tag == "PlayerBullet" && col.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyController>().HP -= atk;
            Destroy(gameObject);
        }
        else if (tag == "EnemyBullet" && col.tag == "HitPoint")
        {
            col.transform.parent.GetComponent<PlayerController>().addHP(-1);
            Destroy(gameObject);
        }
        else if (tag == "EnemyBullet" && (col.name == "die(Clone)" || col.name == "bomb(Clone)"))
            Destroy(gameObject);
    }

    public void set_shoot(float _direction, float _speed = -1)
    {
        transform.Rotate(new Vector3(0, 0 ,_direction));
        _direction *= Mathf.Deg2Rad;
        direction = new Vector3(Mathf.Cos(_direction), Mathf.Sin(_direction));
        if(_speed > 0) speed = _speed;
    }

	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}

}
