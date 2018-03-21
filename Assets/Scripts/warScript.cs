using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class warScript : MonoBehaviour {

    public float health = 10.0f;
    public float attack = 3.0f;
    public float defence = 2.0f;
    public float range = 0.0f;

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
    void DealDmg(float damage)
    {
            SendMessage("RecieveDmg", damage);
    }
    
    /// <summary>
    /// RecieveDmg function, takes int attack variable
    /// Function is used to calculate penetration calculates health after a hit.
    /// </summary>
    /// <param name="attack"></param>
    public void RecieveDmg(float attack)
    {
        Debug.Log("Av for helvede");
        float penetration = attack - defence;
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

