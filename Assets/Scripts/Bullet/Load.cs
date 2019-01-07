using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour {

    public float initial_scale;
    private string bullet_type;
    private float speed, direction;
    public bool pause = false;

	// Use this for initialization
	void Start () {
        transform.localScale = Vector3.one * initial_scale;
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
    }

    // Update is called once per frame
    void Update () {
        //pause//
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = pause ? false : true;
        }
        if (pause) return;

        //load//
        transform.localScale -= Vector3.one * (initial_scale - 2) * 7 * Time.deltaTime;
        GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 8) * Time.deltaTime;
        if (transform.localScale.x <= 2)
        {
            GameObject bullet = Instantiate(Resources.Load("prefab/" + bullet_type) as GameObject);
            bullet.transform.position = transform.position;
            bullet.GetComponent<Shoot>().set_shoot(direction, speed);
            Destroy(gameObject);
        }
    }

    public void set_bullet(string _bullet_type, float _speed, float _direction)
    {
        bullet_type = _bullet_type;
        speed = _speed;
        direction = _direction;
    }
}
