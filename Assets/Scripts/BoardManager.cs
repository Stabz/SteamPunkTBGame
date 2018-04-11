using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {

    /* Used to count the generation of specific objects, background tiles, walls, etc.
    https://answers.unity.com/questions/852115/using-systemserializable.html
        Serializable allows unity to delve into the variables of classes within classes*/
    [System.Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count (int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    public float columns = 20.0f;
    public float rows = 10.0f;
    /* Write here the amount of possible objects to be initialised
     * Write it as following:
     * public Count wallCount = new Count(5,9); */

    // Counters for player and enemy characters, game should end if either list reaches no objects
    public GameObject[] playerCharacterList;
    public GameObject[] enemyCharacterList;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
