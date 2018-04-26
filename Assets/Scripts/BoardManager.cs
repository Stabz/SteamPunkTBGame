using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class should contain functionality to setup board, player and enemy characters.
/// Made on the basis of the Roguelike tutorial
/// https://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial/writing-board-manager
/// Some assets are from OpenGameArt.org
/// </summary>
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
    public float increment = 1.5f;
    /* Write here the amount of possible objects to be initialised
     * Write it as following:
     * public Count wallCount = new Count(5,9); */

    /* Counters for player and enemy characters, game should end if either list contains no objects
     * Make sure to test for empty arrays AFTER these have been initialised, otherwise the game will end prematurely.
     * */
    public GameObject[] playerCharacterList;
    public GameObject[] enemyCharacterList;

    /* Arrays containing variables of x (e.g. x = floortiles)
     * User this to create lists of GameObjects for the game */

    public GameObject[] floorTiles;         // floor tiles for the map
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

     /// <summary>
     /// Function which should setup the game, floor tiles and outerwall.
     /// </summary>
    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;

        for (float x = -1.0f; x < (columns/2) + 1; x+= increment)
        {
            for (float y = -1.0f; y < rows +1; y+= increment)
            {
                // Initialise a variable to choose a random floor tile within the floor tile array.
                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];

                if (x == -1 || x <= columns || y == -1 || y <= rows)
                {
                    // instantiates outerWallTiles, use tombstones etc.
                    //toInstantiate = outerWallTiles[Random.Range(0, outerWallTiles.Length)];
                    GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;

                    instance.transform.SetParent(boardHolder);
                }
            }
        }
    }

    /// <summary>
    /// SetupPlayer should intialise and place the player's characters at fixed points
    /// https://docs.unity3d.com/ScriptReference/Object.Instantiate.html
    /// </summary>
    public void SetupPlayer()
    {
        int j = 0;
        foreach (var GameObject in playerCharacterList)
        {
            Instantiate(playerCharacterList[j].gameObject, new Vector3 ( j * 0.2f, 0, 0 ), Quaternion.identity );
            j++;
        }
    }

    /// <summary>
    /// SetupEnemies should initialise and place the enemy characters (at fixed points?)
    /// https://docs.unity3d.com/ScriptReference/Object.Instantiate.html
    /// </summary>
    public void SetupEnemies()
    {
        int i = 0;
        foreach (var GameObject in enemyCharacterList)
        {
            Instantiate(enemyCharacterList[i].gameObject, new Vector3 ( i * 0.2f, 0, 0 ), Quaternion.identity );
            i++;
        }
    }

    /// <summary>
    /// This function should call all functions neccesary to generate the level itself.
    /// The parameter level might not be used as we're only crafting one level, but it could technically be used for future projects
    /// </summary>
    /// <param name="level"></param>
    public void SetupScene()
    {
        BoardSetup();
        initialiseList();

    }

	
}
