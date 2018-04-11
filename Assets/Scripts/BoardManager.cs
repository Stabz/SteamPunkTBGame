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

    /* Arrays containing variables of x (e.g. x = floortiles)
     * User this to create lists of GameObjects for the game */

    public GameObject[] floorTiles; // floor tiles for the map
    public GameObject[] outerWallTiles; // outer wall tiles, i.e. bounds.

    private Transform boardHolder;
    private List<Vector3> gridPositions = new List<Vector3>();

    // Initialise gridPositions List that takes an x and y coordinate
    void initialiseList()
    {
        gridPositions.Clear();

        for (int x = 1; x < columns; x++)
        {
            for (int y = 1; y < rows; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0.0f));
            }
        }
    }

    /* BoardSetup() method should intiialise a variable 
     *  at a random floor tile within the floor tile array */
    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;
        for (int x = -1; x < columns + 1; x++)
        {
            for (int y = -1; y < rows; y++)
            {
                // Initialise a variable to choose a random floor tile within the floor tile array.
            }
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
