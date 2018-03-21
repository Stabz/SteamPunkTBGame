using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{

    private AudioSource audioSource;
    bool Select;
    private List<GameObject> targetList = new List<GameObject>();
    public GameObject target;
    Animator anim;
    



    // Use this for initialization
    void Start()
    {
        target = GameObject.Find("Player_Skeleton");
        anim = target.GetComponent<Animator>();
        

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

                if (targetList[0].tag == "enemy")
                {
                    targetList.Clear();
                }
                else
                {
                    
                    attackTouch();
                    // anim.SetInteger("State", 1);
                    



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


                if (targetList[0].tag == "Player" && targetList[1].tag == "enemy")
                {
                    this.target = targetList[1];
                    targetList[1].SendMessage("DealDmg", targetList[0].GetComponent<warScript>().attack);
                anim.SetInteger("State", 1);
                audioSource.Play();               

                targetList.Clear();
                
            }
                targetList.Clear();
            
        }
        }
    }


