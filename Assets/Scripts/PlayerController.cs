using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed, shoot_delay_short, shoot_delay_long;
    public GameObject normal_bullet, trace_bullet, enemy;
    private GameObject bullet;
    private Vector3 direction;
    private float delay_time_short = 0, delay_time_long = 0, delay_bomb_time = 0;
    public int power = 15, point = 0, graze = 0, max_HP, HP, score, bomb = 3;
    private int bomb_count = 0;
    public bool pause = false;
	// Use this for initialization
	void Start () {
        gameObject.AddComponent<Invinsible>().invinsible_time = 5;
    }

    // Update is called once per frame
    void Update () {
        //pause//
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause)
            {
                pause = false;
                GetComponent<Animator>().speed = 1;
            }
            else
            {
                pause = true;
                GetComponent<Animator>().speed = 0;
            }
        }
        if (pause) return;

        //move//
        direction = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow))
            direction += Vector3.up;
        else if (Input.GetKey(KeyCode.DownArrow))
            direction += Vector3.down;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction += Vector3.right;
            GetComponent<Animator>().SetFloat("speedX", 10);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction += Vector3.left;
            GetComponent<Animator>().SetFloat("speedX", -10);
        }
        else
            GetComponent<Animator>().SetFloat("speedX", 0);
        if (Input.GetKey(KeyCode.LeftShift))
            transform.position += direction.normalized * speed * 0.5f * Time.deltaTime;
        else
            transform.position += direction.normalized * speed * Time.deltaTime;

        //out of game//
        if (transform.position.x > 2.086536f)
            transform.position = new Vector2(2.086536f, transform.position.y);
        if (transform.position.x < -7.032539f)
            transform.position = new Vector2(-7.032539f, transform.position.y);
        if (transform.position.y < -5.189061f)
            transform.position = new Vector2(transform.position.x, -5.189061f);
        if (transform.position.y > 5.241774f)
            transform.position = new Vector2(transform.position.x, 5.241774f);

        //normal bullet//
        delay_time_short += Time.deltaTime;
        if (delay_time_short >= shoot_delay_short && Input.GetKey(KeyCode.Z))
        {
            delay_time_short = 0;
            if (power < 16)
            {
                bullet = Instantiate(normal_bullet);
                bullet.GetComponent<Shoot>().direction = Vector3.up;
                bullet.GetComponent<Shoot>().atk = power;
                bullet.transform.position = transform.position;
            }
            else if(power >= 16 && power < 32)
            {
                //left bullet//
                bullet = Instantiate(normal_bullet);
                bullet.GetComponent<Shoot>().direction = new Vector3(-1, 70, 0);
                bullet.GetComponent<Shoot>().atk = power;
                bullet.transform.position = transform.position + Vector3.left * 0.2f;

                //right bullet//
                bullet = Instantiate(normal_bullet);
                bullet.GetComponent<Shoot>().direction = new Vector3(1, 70, 0);
                bullet.GetComponent<Shoot>().atk = power;
                bullet.transform.position = transform.position + Vector3.right * 0.2f;
            }
            else if (power >= 32)
            {
                //left bullet//
                bullet = Instantiate(normal_bullet);
                bullet.GetComponent<Shoot>().direction = new Vector3(-1, 11.43f, 0);
                bullet.GetComponent<Shoot>().atk = power;
                bullet.transform.position = transform.position + Vector3.left * 0.37f;

                //mid bullet//
                bullet = Instantiate(normal_bullet);
                bullet.GetComponent<Shoot>().direction = Vector3.up;
                bullet.GetComponent<Shoot>().atk = power;
                bullet.transform.position = transform.position;

                //right bullet//
                bullet = Instantiate(normal_bullet);
                bullet.GetComponent<Shoot>().direction = new Vector3(1, 11.43f, 0);
                bullet.GetComponent<Shoot>().atk = power;
                bullet.transform.position = transform.position + Vector3.right * 0.37f;
            }
        }

        //trace bullet, over power 8//   
        delay_time_long += Time.deltaTime;
        if (delay_time_long >= shoot_delay_long && Input.GetKey(KeyCode.Z) && power >= 8)
        {
            delay_time_long = 0;

            //left side//
            bullet = Instantiate(trace_bullet);
            bullet.transform.position = transform.GetChild(1).position;
            bullet.GetComponent<Shoot>().direction = new Vector3(-1, 1.732f, 0);
            bullet.GetComponent<Shoot>().atk = power;
            bullet.GetComponent<Trace>().target = enemy;

            //right side//
            bullet = Instantiate(trace_bullet);
            bullet.transform.position = transform.GetChild(2).position;
            bullet.GetComponent<Shoot>().direction = new Vector3(1, 1.732f, 0);
            bullet.GetComponent<Shoot>().atk = power;
            bullet.GetComponent<Trace>().target = enemy;
        }

        //bomb//
        if (Input.GetKeyDown(KeyCode.X) && bomb > 0)
        {
            bomb--;
            bomb_count = 30;
        }
        delay_bomb_time += Time.deltaTime;
        if (bomb_count > 0 && delay_bomb_time > 0.05f)
        {
            delay_bomb_time = 0;
            bomb_count--;
            GameObject explode = Instantiate(Resources.Load("prefab/bomb") as GameObject);
            explode.transform.position = new Vector2(Random.Range(-7f, 2f), Random.Range(-5f, 5f));
            explode.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "EnemyBullet") graze++;
    }

    public void addHP(int deltaHP)
    {
        HP += deltaHP;
        if (HP > max_HP) HP = max_HP;
        if (deltaHP < 0)
        {
            for(int i = 0; i < 10 && power > 100; i++)
            {
                power--;
                GameObject powerup = Instantiate(Resources.Load("prefab/power") as GameObject);
                powerup.transform.position = transform.position + new Vector3(Random.Range(-2f, 2f), 1, 0);
            }
            GameObject explode = Instantiate(Resources.Load("prefab/die") as GameObject);
            explode.transform.position = transform.position;
            GetComponent<AudioSource>().Play();
            gameObject.AddComponent<Invinsible>().invinsible_time = 5;
        }
    }
}