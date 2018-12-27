using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Character
{
	public GameObject body;
	// explain each function's functionality
	public Dictionary<string, string> explain = new Dictionary<string, string>
	{
		{
			"evenN_way",
			"<color=yellow>" + 
			"evenN_way(string load_type, string bullet_type, int even_N, float interval, float speed, float degree = -90, float initial_radius = 0, float direction = 0)\r\n" + 
			"1. use as even number danmaku, cannot track\r\n" + 
			"2. use as single bullet, ex: evenN_way(\"load_type\", \"bullet_type\", 1, 0, speed, degree);\r\n" + 
			"3. use as circle, ex: evenN_way(\"load_type\", \"bullet_type\", evenN, 360 / evenN, speed, 0, 3, angle);" + 
			"</color>"
		},
		{
			"oddN_way",
			"<color=yellow>" +
			"oddN_way(string load_type, string bullet_type, int odd_N, float interval, float speed, float initial_radius = 0)\r\n" +
			"odd number danmaku, automaticly track" +
			"</color>"
		},
		{
			"radiate",
			"<color=yellow>" +
			"radiate(string load_type, string bullet_type, int N, float speed, float degree = -90, float initial_radius = 0)\r\n" +
			"radiate danmaku" +
			"</color>"
		},
		{
			"shoot",
			"<color=yellow>" +
			"shoot(string load_type, string bullet_type, float posx, float posy, float speed, float degree)" +
			"</color>"
		},
		{
			"laser",
			"<color=yellow>" +
			"laser(string laser_type, float str_pointx, float str_pointy, float str_pointz, float str_angle, float time, float angle = 0, float angular_speed = 0)" +
			"</color>"
		},
		{
			"move_straight",
			"<color=yellow>" +
			"move_straight(float angle, float _distance, float _speed)\r\n" +
			"move to specific distance" +
			"</color>"
		},
		{
			"turn",
			"<color=yellow>" +
			"turn(float radius, float start_angle, float end_angle, float _angular_speed)" +
			"</color>"
		}
	};
	public string help =
		"<color=yellow>" +
		"evenN_way()\r\n" +
		"oddN_way()\r\n" +
		"radiate()\r\n" +
		"shoot()\r\n" +
		"laser()\r\n" +
		"move_straight()\r\n" +
		"turn()\r\n" +
		"</color>";

	public Character(GameObject body)
	{
		this.body = body;
	}

	public void evenN_way(string load_type, string bullet_type, int even_N, float interval, float speed, float degree = -90, float initial_radius = 0, float direction = 0)
	{
		body.GetComponent<Danmaku>().evenN_way(load_type, bullet_type, even_N, interval, speed, degree, initial_radius, direction);
	}
	public void oddN_way(string load_type, string bullet_type, int odd_N, float interval, float speed, float initial_radius = 0)
	{
		body.GetComponent<Danmaku>().oddN_way(load_type, bullet_type, odd_N, interval, speed, initial_radius);
	}
	public void radiate(string load_type, string bullet_type, int N, float speed, float degree = -90, float initial_radius = 0)
	{
		body.GetComponent<Danmaku>().radiate(load_type, bullet_type, N, speed, degree, initial_radius);
	}
	public void shoot(string load_type, string bullet_type, float posx, float posy, float speed, float degree)
	{
		body.GetComponent<Danmaku>().shoot(load_type, bullet_type, new Vector2(posx, posy), speed, degree);
	}
	public void laser(string laser_type, float str_pointx, float str_pointy, float str_pointz, float str_angle, float time, float angle = 0, float angular_speed = 0)
	{
		body.GetComponent<Danmaku>().laser(laser_type, new Vector3(str_pointx, str_pointy, str_pointz), str_angle, time, angle = 0, angular_speed);
	}
	public void move_straight(float angle, float _distance, float _speed)
	{
		body.GetComponent<EnemyController>().move_straight(angle, _distance, _speed);
	}
	public void turn(float radius, float start_angle, float end_angle, float _angular_speed)
	{
		body.GetComponent<EnemyController>().turn(radius, start_angle, end_angle, _angular_speed);
	}
}
