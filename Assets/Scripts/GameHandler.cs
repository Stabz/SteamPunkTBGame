using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {

    //gameobjektet character
    private GameObject character;
    public static GameHandler instance = null;
    public BoardManager boardscript;

    //bool for character select.
    private bool characterSelected;

    //tæller antallet af runder
    private float roundCount;

    //skifter spillets tilstand
    private enum GameState
    {
        playerTurn, enemyTurn, finishedGame
    }

    private GameState stateOfTheGame;

    //Awake method for initialization
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        boardscript = GetComponent<BoardManager>();
        initGame();
    }

    // Use this for initialization
    void Start () {
        roundCount = 0;
		stateOfTheGame = GameState.playerTurn;

	}
	
	// Update is called once per frame
	void Update () {


        switch (stateOfTheGame)
        {

            case GameState.playerTurn:

                for (int i = 0; i < Input.touchCount; i++)
                {
                    if (Input.GetTouch(i).phase == TouchPhase.Began)
                    {
                        var ray = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                        RaycastHit2D hit = Physics2D.Raycast(ray, (Input.GetTouch(i).position));


                        if (hit.collider.gameObject && hit.collider.tag == "Player")
                        {

                            Debug.Log("player hit");
                            character = hit.collider.gameObject;
                            this.character.GetComponent<warScript>().isSelected = true;

                        }

                    }
                }


                break;

            case GameState.enemyTurn:

                break;

            case GameState.finishedGame:

                break;
        }



	}

    void initGame()
    {
        boardscript.SetupScene();
    }
}
