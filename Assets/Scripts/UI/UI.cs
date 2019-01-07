using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    private PlayerController player_info;

	// Use this for initialization
	void Start () {
        player_info = GetComponent<Player>().sprite.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {

        //score//
        int i;
        int score = player_info.score;
        for (i = 0; i < 9 && score > 0; i++, score /= 10)
            transform.GetChild(0).GetChild(i).GetComponent<RawImage>().texture = Resources.Load("UI/" + (score % 10).ToString()) as Texture;
        if (i > 3)
            transform.GetChild(0).GetChild(9).GetComponent<RawImage>().texture = Resources.Load("UI/comma") as Texture;
        else
            transform.GetChild(0).GetChild(9).GetComponent<RawImage>().texture = Resources.Load("UI/blank_dot") as Texture;
        if (i > 6)
            transform.GetChild(0).GetChild(10).GetComponent<RawImage>().texture = Resources.Load("UI/comma") as Texture;
        else
            transform.GetChild(0).GetChild(10).GetComponent<RawImage>().texture = Resources.Load("UI/blank_dot") as Texture;
        for (; i < 9; i++)
            transform.GetChild(0).GetChild(i).GetComponent<RawImage>().texture = Resources.Load("UI/blank_num") as Texture;

        //HP//
        for (i = 0; i < player_info.HP; i++)
            transform.GetChild(1).GetChild(i).GetComponent<RawImage>().texture = Resources.Load("UI/full_star") as Texture;
        for(; i < 8; i++)
            transform.GetChild(1).GetChild(i).GetComponent<RawImage>().texture = Resources.Load("UI/hollow_star") as Texture;

        //bomb//
        for (i = 0; i < player_info.bomb; i++)
            transform.GetChild(2).GetChild(i).GetComponent<RawImage>().texture = Resources.Load("UI/full_star") as Texture;
        for (; i < 8; i++)
            transform.GetChild(2).GetChild(i).GetComponent<RawImage>().texture = Resources.Load("UI/hollow_star") as Texture;

        //power//
        int power = player_info.power;
        for (i = 0; i < 3 && power > 0; i++, power /= 10)
            transform.GetChild(3).GetChild(i).GetComponent<RawImage>().texture = Resources.Load("UI/" + (power % 10).ToString()) as Texture;

        //point//
        int point = player_info.point;
        for (i = 0; i < 6 && point > 0; i++, point /= 10)
            transform.GetChild(4).GetChild(i).GetComponent<RawImage>().texture = Resources.Load("UI/" + (point % 10).ToString()) as Texture;
        if (i > 3)
            transform.GetChild(4).GetChild(6).GetComponent<RawImage>().texture = Resources.Load("UI/comma") as Texture;
        else
            transform.GetChild(4).GetChild(6).GetComponent<RawImage>().texture = Resources.Load("UI/blank_dot") as Texture;
        for (; i < 6; i++)
            transform.GetChild(4).GetChild(i).GetComponent<RawImage>().texture = Resources.Load("UI/blank_num") as Texture;
    }
}
