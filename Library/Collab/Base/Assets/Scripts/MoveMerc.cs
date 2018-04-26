using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMerc : MonoBehaviour {

    // variables
    private Vector3 targetPosition;

    GameObject[] MovementArray;
    GameObject[] pawns;


    private GameObject playerObject;


    public float allowedDistance = 6;

    

    // enum used to tell the game which step to take, first set a position and a move state.
    private enum GameSteps
    {
        setPos,Move,standby
    }
        


    private GameSteps proggression;



    private int energy =3;
    public float speed = 10f;
    private GameObject enemyInstance3;
    private GameObject enemyInstance2;


    // Use this for initialization
    void Start () {


        pawns = GameObject.FindGameObjectsWithTag("Player");

        proggression = GameSteps.standby;

        /*targetPosition.x = 2;
        targetPosition.y = 5;*/
        
    }
	
	// Update is called once per frame
	void Update () {


        for ( int i = 0; i< pawns.Length; i++)
        {
            if (pawns[i].GetComponent<warScript>().isSelected == true)
            {
                playerObject = pawns[i];
                proggression = GameSteps.setPos;
            }
        }

        /*Debug.Log("our game step is " + proggression);*/

        if (proggression==GameSteps.setPos)
        {

           DrawMovementIndicator();

            

            SetTargetPosition();





            if (targetPosition.x != playerObject.transform.position.x && targetPosition.y != playerObject.transform.position.y)
            {

                MovementArray = GameObject.FindGameObjectsWithTag("movementIndicator");

                if (gameObject != null)
                {
                    foreach (GameObject target in MovementArray)
                    {
                        GameObject.Destroy(target);
                    }
                }


                proggression = GameSteps.Move;
                

            }




        }


        if (proggression == GameSteps.Move)
        {



            
           



            Move();

            Debug.Log("getting ready to move");
            Debug.Log("targetpos: " + targetPosition);
            Debug.Log("playerpos: " + playerObject.transform.position);


            /* if (targetPosition.x == pawn.transform.position.x && targetPosition.y == pawn.transform.position.y)
             {
                 proggression = GameSteps.setPos;
             }
             */

            for (int i = 0; i < pawns.Length; i++)
            {
                if (pawns[i].GetComponent<warScript>().isSelected == true)
                {
                    pawns[i].GetComponent<warScript>().isSelected = false;
                }
            }

            proggression = GameSteps.standby;

        }

        if(proggression == GameSteps.standby)
        {


        }

    }

    private void Move()
    {
        float x = playerObject.transform.position.x;
        float y = playerObject.transform.position.y;


        var xDifference = x - targetPosition.x;
        var yDifference = y - targetPosition.y;

        float absXD = Math.Abs(xDifference);
        float absYD = Math.Abs(yDifference);

        //if(absXD+absYD < allowedDistance)
        //{


        Debug.Log("target moving: " + playerObject.transform.position);
            playerObject.transform.position = Vector3.MoveTowards(playerObject.transform.position, targetPosition, speed * Time.deltaTime);

           
            
       // }
    }



    private void SetTargetPosition()
    {



        int roundedValY;
        int roundedValX;

        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                var ray = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                RaycastHit2D hit = Physics2D.Raycast(ray, (Input.GetTouch(i).position));
        
        
        if (hit.collider && hit.collider.tag == "movementIndicator")
        {
                           


            targetPosition = hit.point;

            roundedValX = (int) targetPosition.x;
            roundedValY = (int) targetPosition.y;

            


            targetPosition.x = roundedValX;
            targetPosition.y = roundedValY;


            Debug.Log("you hit movement indicator at " + targetPosition);

        }

            }
        }



    }


    private void DrawMovementIndicator()
    {

        int yFix = -4;

        for (int i = -4; i < 5; i++)
        {
            float x = playerObject.transform.position.x;
            float y = playerObject.transform.position.y;


            for (int j = 0; j < 5 + yFix; j++)
            {

                enemyInstance2 = Instantiate(Resources.Load("movementIndicator")) as GameObject;


                enemyInstance2.transform.Translate(new Vector3(x + i, y + j, 0));

                enemyInstance2.transform.parent = transform;



                enemyInstance3 = Instantiate(Resources.Load("movementIndicator")) as GameObject;


                enemyInstance3.transform.Translate(new Vector3(x + i, y - j, 0));

                enemyInstance3.transform.parent = transform;

                



            }
            if (i < 0)
            {
                yFix++;

            }
            else
            {
                yFix--;
            }
        }

    }

      

}
