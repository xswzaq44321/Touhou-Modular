﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

    private int state = 0;
    private float effect = 0;
    private bool pause = false;

	// Use this for initialization
	void Start () {
        for(int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).GetComponent<Image>().color = new Color(255, 255, 255, 0);
        for (int i = 1; i < transform.childCount; i++)
            transform.GetChild(i).GetComponent<RectTransform>().localScale = new Vector3(2.25f, 0, 0);

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
            }
            else
            {
                pause = true;
                state = 0;
                transform.GetChild(0).GetComponent<Image>().color = new Color(7f / 255f, 0, 56f / 255f, 141f / 255f);
                transform.GetChild(1).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                transform.GetChild(2).GetComponent<Image>().color = new Color(1, 113f / 255f, 113f / 255f, 1);
                transform.GetChild(3).GetComponent<Image>().color = new Color(96f / 255f, 96f / 255f, 96f / 255f, 1);
            }
        }

        //effect//
        if(pause && transform.GetChild(1).GetComponent<RectTransform>().localScale.y < 2.25f)
        {
            for(int i = 1; i < transform.childCount; i++)
                transform.GetChild(i).GetComponent<RectTransform>().localScale += Vector3.up * 4.5f * Time.deltaTime;
        }
        else if(!pause && transform.GetChild(1).GetComponent<RectTransform>().localScale.y > 0)
        {
            for (int i = 1; i < transform.childCount; i++)
                transform.GetChild(i).GetComponent<RectTransform>().localScale -= Vector3.up * 4.5f * Time.deltaTime;
            if(transform.GetChild(1).GetComponent<RectTransform>().localScale.y <= 0)
            {
                for (int i = 0; i < transform.childCount; i++)
                    transform.GetChild(i).GetComponent<Image>().color = new Color(1, 1, 1, 0);
            }
        }

        //select//
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.GetChild(state + 2).GetComponent<Image>().color = new Color(96f / 255f, 96f / 255f, 96f / 255f, 1);
            transform.GetChild(state + 2).GetComponent<RectTransform>().localScale = Vector2.one * 2.25f;
            state = (state + 1) % 2;
            transform.GetChild(state + 2).GetComponent<Image>().color = new Color(255, 113f / 255f, 113f / 255f, 255);
            transform.GetChild(state + 2).GetComponent<RectTransform>().localScale *= 1.1f;
        }
        if(Input.GetKeyDown(KeyCode.Z) && state == 0)
        {
            pause = false;
            for (int i = 0; i < transform.childCount; i++)
                transform.GetChild(i).GetComponent<Image>().color = new Color(1, 1, 1, 0);
        }


    }

}
