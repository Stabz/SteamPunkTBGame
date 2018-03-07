using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warScript : MonoBehaviour {

    public int health = 10;
    public int attack = 3;
    public int defence = 2;

    public GameObject target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void DealDmg()
    {
        if (target != null)
        {
            target.SendMessage("RecieveDmg", attack);
        }
    }

    void RecieveDmg(int attack)
    {
        Debug.Log("Av for helvede");
        int penetration = attack - defence;
        if(penetration > 0)
        {
            Debug.Log("Defense was penetrated");
            health = health - penetration;
            Debug.Log("Damage dealt: " + penetration);
            Debug.Log("Health left: " + health);
            if (target != null)
            {
                if (health == 0) Destroy(this.gameObject);
            }
        } else
        {
            Debug.Log("No damage was dealt");
        }
        
    }

}

