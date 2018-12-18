using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trace : MonoBehaviour {

    // Use this for initialization
    public string target;
    void Start () {

	}

    void Update() {

    }

    //trace//
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == target)
            transform.GetComponent<Shoot>().direction = col.transform.position - transform.position;
    }

    public void set_range(float radius)
    {
        GetComponents<CircleCollider2D>()[1].radius = radius;
    }

}
