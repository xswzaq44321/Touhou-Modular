using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour {

    public float initial_scale;
    private string bullet_type;
    private float speed;
    private Vector3 direction;
	// Use this for initialization
	void Start () {
        transform.localScale = Vector3.one * initial_scale;
        GetComponent<SpriteRenderer>().color += new Color(255, 255, 255, 0);
    }

    // Update is called once per frame
    void Update () {
        transform.localScale -= Vector3.one * (initial_scale - 2) * 6 * Time.deltaTime;
        GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 1530) * Time.deltaTime;
        if (transform.localScale.x <= 2)
        {
            GameObject bullet = Instantiate(Resources.Load("prefab/" + bullet_type) as GameObject);
            bullet.transform.position = transform.position;
            bullet.GetComponent<Shoot>().speed = speed;
            bullet.GetComponent<Shoot>().direction = direction;
            Destroy(gameObject);
        }
    }

    public void set_bullet(string _bullet_type, float _speed, Vector3 _direction)
    {
        bullet_type = _bullet_type;
        speed = _speed;
        direction = _direction;
    }
}
