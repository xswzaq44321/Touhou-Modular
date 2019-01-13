using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    private int state = 0;

	// Use this for initialization
	void Start () {
        transform.GetChild(0).GetComponent<Image>().color = new Color(39f/ 255f, 38f/ 255f, 53f / 255f, 0.8f);
        transform.GetChild(1).GetComponent<Image>().color = new Color(1, 1, 1, 1);
        transform.GetChild(2).GetComponent<Image>().color = new Color(1, 113f / 255f, 113f / 255f, 1);
        transform.GetChild(3).GetComponent<Image>().color = new Color(96f / 255f, 96f / 255f, 96f / 255f, 1);

        for (int i = 1; i < transform.childCount; i++)
            transform.GetChild(i).GetComponent<RectTransform>().localScale = new Vector3(2.25f, 0, 0);
    }

    // Update is called once per frame
    void Update () {
        if (transform.GetChild(1).GetComponent<RectTransform>().localScale.y < 2.25f)
        {
            for(int i = 1; i < transform.childCount; i++)
                transform.GetChild(i).GetComponent<RectTransform>().localScale += Vector3.up * 4.5f * Time.deltaTime;
            return;
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

        if (Input.GetKeyDown(KeyCode.Z))
        {
            switch (state)
            {
                case 0:
                    SceneManager.LoadScene(0);
                    break;
                case 1:
                    Application.Quit();
                    break;
            }
        }
    }
}
