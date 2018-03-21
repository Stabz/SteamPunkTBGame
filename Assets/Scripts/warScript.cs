using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warScript : MonoBehaviour {

    public int health = 10;
    public int attack = 3;
    public int defence = 2;

    //public GameObject target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// A function to easily call the RecieveDmg function, takes a int dmg variable.
    /// </summary>
    /// <param name="damage"></param>
    void DealDmg(int damage)
    {
            SendMessage("RecieveDmg", damage);
    }
    
    /// <summary>
    /// RecieveDmg function, takes int attack variable
    /// Function is used to calculate penetration calculates health after a hit.
    /// </summary>
    /// <param name="attack"></param>
    public void RecieveDmg(int attack)
    {
        Debug.Log("Av for helvede");
        int penetration = attack - defence;
        if(penetration > 0)
        {

            Debug.Log("Defense was penetrated");
            health = health - penetration;
            Debug.Log("Damage dealt: " + penetration);
            Debug.Log("Health left: " + health);

            if (health <= 0) { 
                Destroy(this.gameObject);
            }

        } else
        {
            Debug.Log("No damage was dealt");
        }
        
    }

}

