using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public string item = "";
    public int max_HP, HP, item_num = 1;
    private Vector3 direction, pivot;
    private float speed, distance, angle, angular_speed;
    private bool moving = false, turning = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //health
        if(HP <= 0)
        {
            if (item != "")
            {
                GameObject powerup = Instantiate(Resources.Load("prefab/" + item) as GameObject);
                powerup.transform.position = transform.position;
            }
            GameObject explode = Instantiate(Resources.Load("prefab/explode_blue") as GameObject);
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
            turn(3, 0, 90, 45);

        //turning
        if (turning)
        {
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
        pivot = transform.position - new Vector3(Mathf.Cos(start_angle), Mathf.Sin(start_angle)) * radius;
        angle = end_angle;
        angular_speed = _angular_speed;
    }
}
