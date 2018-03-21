using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{

    private AudioSource audioSource;
    bool Select;
    private List<GameObject> targetList = new List<GameObject>();
    public GameObject target;
    private float distance;
    private bool inRange = false;
    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Debug.Log("Touch detected");

                var test = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                RaycastHit2D hit = Physics2D.Raycast(test, (Input.GetTouch(i).position));

                // Add hitcollider's GameObject to List       
                if (hit.collider.gameObject != null)
                {
                    targetList.Add(hit.collider.gameObject);
                    if (targetList.Count > 1)
                    {
                        Debug.Log(targetList[0] + " and " + targetList[1]);
                    }
                }

                if (targetList[0].tag == "enemy" || targetList[1].tag == "Player")
                {
                    targetList.Clear();
                }
                else
                {

                    attackTouch();
                }

            }
        }
    }

    /// <summary>
    /// When two GameObjects have been added to the list check if their tags are player and enemy.
    /// If this is true send message from the "Player" tagged gameobject 
    /// </summary>
    void attackTouch()
    {

        if (targetList.Count == 2)
            target = targetList[1];
        {
            CheckRange();
            if (inRange == true)
            {
                doAttack();
            }
            targetList.Clear();
        }
    }

    /// <summary>
    /// Checks the range between the player unit attacking and the target
    /// </summary>
    /// <returns name="inRange"></returns>
    bool CheckRange()
    {
        float dist = Vector2.Distance(targetList[0].transform.position, targetList[1].transform.position);
        if(Math.Abs(dist) <= Math.Abs(targetList[0].GetComponent<warScript>().range))
        {
            inRange = true;
            Debug.Log("Within Range");
            Debug.Log("The distance between the player and the target is: " + dist);
        }
        else
        {
            inRange = false;
            Debug.Log("Not in range");
            Debug.Log("The distance between the player and the target is: " + dist);
        }
        return inRange;
    }

    /// <summary>
    /// Function to set target and send message to the target.
    /// </summary>
    void doAttack()
    {
        if (targetList[0].tag == "Player" && targetList[1].tag == "enemy")
        {
            this.target = targetList[1];
            targetList[1].SendMessage("DealDmg", targetList[0].GetComponent<warScript>().attack);
            audioSource.Play();
            targetList.Clear();
        }
    }
}




