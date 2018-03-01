using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warScript : MonoBehaviour {

    public int health = 10;

    public GameObject target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void DealDmg()
    {
        target.SendMessage("RecieveDmg");
    }

    void RecieveDmg()
    {
        Debug.Log("Av for helvede");
        health--;
        if (health == 0) Destroy(this.gameObject);
    }

}

