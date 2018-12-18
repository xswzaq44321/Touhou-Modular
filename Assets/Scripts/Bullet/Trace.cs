using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trace : MonoBehaviour {

    // Use this for initialization
    public GameObject target;
    public float range;
    private bool locked = false;
    void Start () {

	}

    void Update() {
        for(int i = 0; i < target.transform.childCount; i++)
        {
            if (!locked && Vector2.Distance(target.transform.GetChild(i).transform.position, transform.position) <= range)
            {
                GetComponent<Shoot>().direction = target.transform.GetChild(i).transform.position - transform.position;
                locked = true;
                break;
            }
        }
        
    }

}
