using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;

public class EnemyController : MonoBehaviour {

    public string item = "", die;
    public int max_HP, HP, item_num = 1;
	public Table luaGameObject;
	public LuaConsole console;
    private Vector3 direction, pivot;
    private float speed, distance, angle, angular_speed;
    private bool moving = false, turning = false;
    public bool pause = false;
	public event System.EventHandler death;
	// Use this for initialization
	void Start () {
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
        if (pause)  return;

        //health//
        if (HP <= 0)
        {
			death.Invoke(this, null);
            if (item != "")
            {
                for(int i = 0; i < item_num; i++)
                {
                    GameObject powerup = Instantiate(Resources.Load("prefab/" + item) as GameObject);
                    powerup.transform.position = transform.position;
                    if (i > 0)
                        powerup.transform.position += Vector3.right * Random.Range(-2f, 2f);
                }
            }
            GameObject explode = Instantiate(Resources.Load("prefab/" + die) as GameObject);
            explode.transform.position = transform.position;
            Destroy(gameObject);
        }

        //moving
        if (moving)
        {
            transform.position += direction * speed * Time.deltaTime;
            distance -= speed * Time.deltaTime;
            if (distance <= 0) moving = false;
        }

        if (Input.GetKeyDown(KeyCode.Y))
            turn(3, 90, 90, -45);

        //turning
        if (turning)
        {
            transform.RotateAround(pivot, Vector3.forward, angular_speed * Time.deltaTime);
            transform.Rotate(Vector3.back, angular_speed * Time.deltaTime);
            angle -= Mathf.Abs(angular_speed) * Time.deltaTime;
            if (angle <= 0) turning = false;
        }
            
    }

    //move to specific distance//
    public void move_straight(float angle, float _distance, float _speed)
    {
        moving = true;
        angle *= Mathf.Deg2Rad;
        direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle));
        distance = _distance;
        speed = _speed;
    }

    public void turn(float radius, float start_angle, float end_angle, float _angular_speed)
    {
        turning = true;
        start_angle = (start_angle + 180) * Mathf.Deg2Rad;
        pivot = transform.position + new Vector3(Mathf.Cos(start_angle), Mathf.Sin(start_angle)) * radius;
        angle = end_angle;
        angular_speed = _angular_speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "HitPoint")
            col.transform.parent.GetComponent<PlayerController>().addHP(-1);
        if (col.name == "bomb(Clone)")
            HP -= 600;
    }
}
