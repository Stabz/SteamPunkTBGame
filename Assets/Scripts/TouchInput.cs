using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{

    private AudioSource audioSource;
    bool Select;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame

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

                if (hit.collider && hit.collider.tag == "Player")
                {
                    hit.collider.SendMessage("DealDmg");
                    audioSource.Play();
                    Debug.Log("btn?");
                }



                /*

                    if (hit.collider && hit.collider.tag == "sup")
                    {
                        hit.collider.SendMessage("ReceiveDmg");
                        Debug.Log("Dmg?");
                    }
                }

            }
        }*/
            }
        }
    }
}
