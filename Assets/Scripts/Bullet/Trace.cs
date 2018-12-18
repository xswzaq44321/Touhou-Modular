using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trace : MonoBehaviour {

    // Use this for initialization
    public string target;
    private float range;
    void Start () {

	}

    void Update() {

    }

    //trace//
    private void OnTriggerStay2D(Collider2D collider)
    {
        Debug.Log(collider.gameObject.tag);
        if(collider.gameObject.tag == target)
            transform.GetComponent<Shoot>().direction = collider.transform.position - transform.position;
    }

    public void set_range(float radius)
    {
        range = radius;
        GetComponent<CircleCollider2D>().radius = radius;
    }

}
