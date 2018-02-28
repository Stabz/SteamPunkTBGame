using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {

    public float health = 20;
    public float strength = 5;
    public float accuracy = 5;
    public float defence = 5;
    public float agility = 5;
    public bool selected = false;
    public bool target = false;

    private GameObject pawn;
    private GameObject pawn2;
    
	void Start () {

        pawn = GameObject.FindGameObjectWithTag("sup");
        pawn2 = GameObject.FindGameObjectWithTag("enemy");

    }
	
	// Update is called once per frame
	void Update () {

        //DealDmg(this.strength, 5f);
        //ReceiveDmg(5f);
	}



    private void DealDmg()
    {
        
        this.accuracy = accuracy;
        //the returning dmg
        float dmg = 0;

        //random number, use accuracy.
        float hitChance = Random.Range(0,101);
        hitChance = hitChance + accuracy;


        if (hitChance>20)
        {
            dmg = strength * 1.1f;
        }

        //pawn.SendMessage("ReceiveDmg", dmg);

        Debug.Log("hit");


    }

    private void ReceiveDmg(float incDmg)
    {


        float dmg = incDmg*(1-(this.defence/100));

        health = health - dmg;

        Debug.Log("health: " + health);

        if (health <= 0)
        {
            Destroy(pawn2);
        }
    }

}
