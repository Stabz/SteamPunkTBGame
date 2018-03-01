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
    
	void Start () {


    }
	
	// Update is called once per frame
	void Update () {

	}

    /// <summary>
    /// Lowers health
    /// </summary>
    /// <param name="dmg"> The calculated damage from attacker </param>
    /// <returns></returns>
    public float Wound(float dmg)
    {
        dmg = dmg - defence;

        health = health - dmg;

        return health;
    }

    

}
