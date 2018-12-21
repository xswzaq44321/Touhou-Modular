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
        float min = range;
        Vector3 endPoint = Vector3.zero;
        //Transform locked = null;
        for(int i = 0; i < target.transform.childCount; i++)
        {
            float dis = Vector2.Distance(target.transform.GetChild(i).transform.position, transform.position);
            if (dis < min && target.transform.GetChild(i).transform.position.y > transform.position.y)
            {
                min = dis;
                locked = true;
                endPoint = target.transform.GetChild(i).transform.position - transform.position;
            }
        }
        if(locked)
            GetComponent<Shoot>().direction += endPoint * Time.deltaTime * 10;
    }

}
