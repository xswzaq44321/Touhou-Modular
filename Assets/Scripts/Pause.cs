using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

    private int state = 0;
    private bool pause = false;

	// Use this for initialization
	void Start () {
        for(int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).GetComponent<Image>().color = new Color(255, 255, 255, 0);

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

    // Update is called once per frame
    void Update () {
        //pause//
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause)
            {
                pause = false;
                for (int i = 0; i < transform.childCount; i++)
                    transform.GetChild(i).GetComponent<Image>().color = new Color(1, 1, 1, 0);
            }
            else
            {
                pause = true;
                state = 0;
                transform.GetChild(0).GetComponent<Image>().color = new Color(46f / 255f, 43f / 255f, 64f / 255f, 138f / 255f);
                transform.GetChild(1).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                transform.GetChild(2).GetComponent<Image>().color = new Color(1, 113f / 255f, 113f / 255f, 1);
                transform.GetChild(3).GetComponent<Image>().color = new Color(96f / 255f, 96f / 255f, 96f / 255f, 1);
            }
        }
        if (!pause) return;

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.GetChild(state + 2).GetComponent<Image>().color = new Color(96f / 255f, 96f / 255f, 96f / 255f, 1);
            transform.GetChild(state + 2).GetComponent<RectTransform>().localScale = Vector2.one * 2.25f;
            state = (state + 1) % 2;
            transform.GetChild(state + 2).GetComponent<Image>().color = new Color(255, 113f / 255f, 113f / 255f, 255);
            transform.GetChild(state + 2).GetComponent<RectTransform>().localScale *= 1.1f;
        }

    }

}
