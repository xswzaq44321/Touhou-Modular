using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {

    public GameObject sprite;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    /// <summary>
    /// dynamically generate enemy int the game
    /// </summary>
    /// <param name="name">type of enemy(need to exist in prefab)</param>
    /// <param name="pos">initiate position of enemy</param>
    /// <param name="HP">Max_HP and of the enemy(the enemy always be full_Hp when generated)</param>
    /// <param name="item_type">whether enemy will drop item after dying</param>
    /// <param name="item_num">the number of item enemy will drop after dying</param>
    public void spawn(string name, Vector2 pos, int HP, string item_type = "", int item_num = 0)
    {
        GameObject minion = Instantiate(Resources.Load("prefab/" + name) as GameObject);
        minion.transform.parent = transform;
        minion.transform.position = pos;
        minion.GetComponent<EnemyController>().HP = HP;
        minion.GetComponent<EnemyController>().max_HP = HP;
        minion.GetComponent<EnemyController>().item = item_type;
        minion.GetComponent<EnemyController>().item_num = item_num;
    }
}
