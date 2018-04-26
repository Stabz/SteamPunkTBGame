using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class warScript : MonoBehaviour {

    [SerializeField]
    private float FillAmount;


    [SerializeField]
    private Image Content;

   

    

    public bool isSelected = false;
    public float health = 10.0f;
    public float attack = 3.0f;
    public float defence = 2.0f;
    public float range = 0.0f;
    private float Maxhealth = 10.0f;
    Animator anim;


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
            HandleBar();

            if (health <= 0) {
                anim = this.gameObject.GetComponent<Animator>();
                anim.SetInteger("State",2);
                Destroy(this.gameObject,5);
            }

        } else
        {
            Debug.Log("No damage was dealt");
        }
        
    }

    private void HandleBar()
    {
        
            Content.fillAmount = Map(health, 0, Maxhealth, 0, 1);
        



    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        // (currentvalue = 80 - ingameminimum= 0) * (outMax= 1 - outMin = 0) / (ingameMax = 100 - 0) + 0
        // 80 * 1 / 100 = 0.8

    }

}

