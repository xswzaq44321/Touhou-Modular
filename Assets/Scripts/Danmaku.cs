using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danmaku : MonoBehaviour
{
	GameObject bullet;
	private float a = 0;
	private int way = 1;
	private float delay;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
	}

	/// <summary>
	/// shoot even number danmaku
	/// </summary>
	/// <param name="load_type">type of visual effect, usually ends with _load</param>
	/// <param name="bullet_type">type of bullet</param>
	/// <param name="even_N">how many bullets per circle (odd num)</param>
	/// <param name="interval">the angle(deg) between every bullet</param>
	/// <param name="speed">speed of bullet</param>
	/// <param name="degree">angle(deg) of the middle bullet</param>
	/// <param name="initial_radius">the danmaku circle's radius</param>
	public void evenN_way(string load_type, string bullet_type, int even_N, float interval, float speed, float degree = -90, float initial_radius = 0, float direction = 0)
	{
		direction *= Mathf.Deg2Rad;
		for (int i = 0; i < even_N; i++)
		{
			float deg = (degree - interval * (i - even_N / 2 + 1) + interval / 2);
			float rad = deg * Mathf.Deg2Rad;
			bullet = Instantiate(Resources.Load("prefab/" + load_type) as GameObject);
			bullet.transform.position = transform.position + new Vector3(Mathf.Cos(rad), Mathf.Sin(rad)) * initial_radius;
			bullet.GetComponent<Load>().set_bullet(bullet_type, speed, deg);
		}
	}

	/// <summary>
	/// shoot odd number danmaku, the middle bullet will automatically track player
	/// </summary>
	/// <param name="load_type">type of visual effect, usually ends with _load</param>
	/// <param name="bullet_type">type of bullet</param>
	/// <param name="odd_N">how many bullets per circle (odd num)</param>
	/// <param name="interval">the angle(deg) between every bullet</param>
	/// <param name="speed">speed of bullet</param>
	/// <param name="initial_radius">the danmaku circle's radius</param>
	public void oddN_way(string load_type, string bullet_type, int odd_N, float interval, float speed, float initial_radius = 0)
	{
		for (int i = 0; i < odd_N; i++)
		{
			float deg = ((i - odd_N / 2) * interval + player_direction(transform));
			float rad = deg * Mathf.Deg2Rad;
			bullet = Instantiate(Resources.Load("prefab/" + load_type) as GameObject);
			bullet.transform.position = transform.position + new Vector3(Mathf.Cos(rad), Mathf.Sin(rad)) * initial_radius;
			bullet.GetComponent<Load>().set_bullet(bullet_type, speed, deg);
		}
	}

	/// <summary>
	/// radiate danmaku
	/// </summary>
	/// <param name="load_type">type of visual effect, usually ends with _load</param>
	/// <param name="bullet_type">type of bullet</param>
	/// <param name="N">how many bullets per circle</param>
	/// <param name="speed">speed of bullet</param>
	/// <param name="degree">angle(deg) of the first bullet</param>
	/// <param name="initial_radius">the danmaku circle's radius</param>
	public void radiate(string load_type, string bullet_type, int N, float speed, float degree = -90, float initial_radius = 0)
	{
		for (int i = 0; i < N; i++)
		{
			float deg = (i * 360 / N + degree);
			float rad = deg * Mathf.Deg2Rad;
			bullet = Instantiate(Resources.Load("prefab/" + load_type) as GameObject);
			bullet.transform.position = transform.position + new Vector3(Mathf.Cos(rad), Mathf.Sin(rad)) * initial_radius;
			bullet.GetComponent<Load>().set_bullet(bullet_type, speed, deg);
		}
	}

	/// <summary>
	/// for single bullet
	/// </summary>
	/// <param name="load_type">type of visual effect, usually ends with _load</param>
	/// <param name="bullet_type">type of bullet</param>
	/// <param name="pos">initial position of bullet</param>
	/// <param name="speed">speed of bullet</param>
	/// <param name="degree">the direction bullet flys (deg)</param>
	public void shoot(string load_type, string bullet_type, Vector2 pos, float speed, float degree)
	{
		bullet = Instantiate(Resources.Load("prefab/" + load_type) as GameObject);
		bullet.transform.position = pos;
		bullet.GetComponent<Load>().set_bullet(bullet_type, speed, degree);
	}

	/// <summary>
	/// for laser that sticks with the transform
	/// </summary>
	/// <param name="laser_type">type of laser</param>
	/// <param name="str_point">where the laser starts</param>
	/// <param name="str_angle">initial angle(deg) of the laser</param>
	/// <param name="time">how long will the laser last(doesn't include the time it generates or rotates</param>
	/// <param name="angle">how much will you want to rotate (deg)</param>
	/// <param name="angular_speed">rotate at speed (deg/sec), counterclockwise as positive</param>
	public void laser(string laser_type, Vector3 str_point, float str_angle, float time, float angle = 0, float angular_speed = 0)
	{
		bullet = Instantiate(Resources.Load("prefab/" + laser_type) as GameObject);
		bullet.transform.parent = transform;
		bullet.transform.position = str_point;
		bullet.GetComponent<Laser>().set_laser(str_angle, time);
		if (angle != 0 && angular_speed != 0)
			bullet.GetComponent<Laser>().set_rotate(angle, angular_speed);
	}

	/// <summary>
	/// return the angle(deg) between pos and player
	/// </summary>
	/// <returns></returns>
	public float player_direction(Transform pos)
	{
		Vector2 direction = transform.parent.GetComponent<Control>().sprite.transform.GetChild(0).position - pos.position;
		float angle = Vector2.Angle(direction, transform.right);
		return (Vector2.Dot(direction, transform.up) >= 0) ? angle : -angle;
	}
}
