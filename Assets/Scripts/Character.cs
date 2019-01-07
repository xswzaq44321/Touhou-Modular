using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using MoonSharp.Interpreter;

public class Character
{
	public GameObject body;
	// explain each function's functionality
	public Dictionary<string, string> explain = new Dictionary<string, string>
	{
		{
			"evenN_way",
			"<color=yellow>" +
			"summary: shoot even number danmaku\r\n" +
			"evenN_way(string load_type, string bullet_type, int even_N, float interval, float speed, float degree = -90, float initial_radius = 0, float direction = 0)\r\n" +
			"load_type: type of visual effect, usually ends with _load\r\n" +
			"bullet_type: type of bullet\r\n" +
			"interval: the angle(deg) between every bullet\r\n" +
			"speed: speed of bullet\r\n" +
			"degree: angle(deg) of the middle bullet\r\n" +
			"initial_radius: the danmaku circle's radius\r\n" +
			"</color>"
		},
		{
			"oddN_way",
			"<color=yellow>" +
			"shoot odd number danmaku, the middle bullet will automatically track player\r\n" +
			"oddN_way(string load_type, string bullet_type, int odd_N, float interval, float speed, float initial_radius = 0)\r\n" +
			"load_type: type of visual effect, usually ends with _load\r\n" +
			"bullet_type: type of bullet\r\n" +
			"odd_N: how many bullets per circle (odd num)\r\n" +
			"interval: the angle(deg) between every bullet\r\n" +
			"speed: speed of bullet\r\n" +
			"initial_radius: the danmaku circle's radius\r\n" +
			"</color>"
		},
		{
			"radiate",
			"<color=yellow>" +
			"radiate danmaku\r\n" +
			"radiate(string load_type, string bullet_type, int N, float speed, float degree = -90, float initial_radius = 0)\r\n" +
			"load_type: type of visual effect, usually ends with _load\r\n" +
			"bullet_type: type of bullet\r\n" +
			"N: how many bullets per circle\r\n" +
			"speed: speed of bullet\r\n" +
			"degree: angle(deg) of the first bullet\r\n" +
			"initial_radius: the danmaku circle's radius\r\n" +
			"</color>"
		},
		{
			"shoot",
			"<color=yellow>" +
			"for single bullet\r\n" +
			"shoot(string load_type, string bullet_type, float posx, float posy, float speed, float degree)" +
			"load_type: type of visual effect, usually ends with _load\r\n" +
			"bullet_type: type of bullet\r\n" +
			"posx, posy: initial position of bullet\r\n" +
			"speed: speed of bullet\r\n" +
			"degree: the direction bullet flys (deg)\r\n" +
			"</color>"
		},
		{
			"laser",
			"<color=yellow>" +
			"for laser that sticks with the transform\r\n" +
			"laser(string laser_type, float str_pointx, float str_pointy, float str_pointz, float str_angle, float time, float angle = 0, float angular_speed = 0)" +
			"laser_type: type of laser\r\n" +
			"str_pointx, str_pointy, str_pointz: where the laser starts\r\n" +
			"str_angle: initial angle(deg) of the laser\r\n" +
			"time: how long will the laser last(doesn't include the time it generates or rotates\r\n" +
			"angle: how much will you want to rotate (deg)\r\n" +
			"angular_speed: rotate at speed (deg/sec), counterclockwise as positive\r\n" +
			"</color>"
		},
		{
			"player_direction",
			"<color=yellow>" +
			"return the angle(deg) between pos and player\r\n" +
			"player_direction()\r\n" +
			"</color>"
		},
		{
			"my_position",
			"<color=yellow>" +
			"return three number representing obj position in x, y, z\r\n" +
			"my_position()" +
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
		"player_direction()\r\n" + 
		"my_position()\r\n" + 
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
	public float player_direction()
	{
		return body.GetComponent<Danmaku>().player_direction(body.transform);
	}
	public DynValue my_position()
	{
		return DynValue.NewTuple(DynValue.NewNumber(body.transform.position.x), DynValue.NewNumber(body.transform.position.y), DynValue.NewNumber(body.transform.position.z));
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
