using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	// Use this for initialization
	void Start () {


    }
	
	// Update is called once per frame
	void Update () {
        
        //if (Input.GetKey(KeyCode.Escape))
        {
            stopAllChild(transform);
            /*
            foreach (string tag in UnityEditorInternal.InternalEditorUtility.tags)
            {
                if (tag == "Control") continue;
                GameObject[] all = GameObject.FindGameObjectsWithTag(tag);
                foreach (GameObject item in all)
                {
                    //item.SetActive(false);
                    stopAllChild(item);
                }

            }*/

        }

    }

    void stopAllChild(Transform t)
    {/*
        if(t.tag != "Control")
        {
            int a = 0;
            foreach (MonoBehaviour script in t.GetComponents<MonoBehaviour>())
            {
                script.enabled = false;
            }
        }
        for (int i = 0; i < t.childCount; i++)
            stopAllChild(t.GetChild(i));*/
    }
}
