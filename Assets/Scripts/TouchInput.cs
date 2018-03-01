using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour {

<<<<<<< HEAD
=======

    bool Select;

>>>>>>> 8251ba052f715cad9bb503f8f3120f22217bb30a
	// Use this for initialization
	void Start () {
		
	}
<<<<<<< HEAD
	
	// Update is called once per frame
	void Update () {
=======

    // Update is called once per frame
    void Update()
    {

>>>>>>> 8251ba052f715cad9bb503f8f3120f22217bb30a
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Debug.Log("Touch detected");

                var test = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                RaycastHit2D hit = Physics2D.Raycast(test, (Input.GetTouch(i).position));
<<<<<<< HEAD
                if (hit.collider && hit.collider.tag == "Player")
                {
                    hit.collider.SendMessage("DealDmg");
                    Debug.Log("btn?");
                }
            }
        }
    }
}
=======
                if (hit.collider && hit.collider.tag == "sup")
                {
                    hit.collider.SendMessage("ReceiveDmg");
                    Debug.Log("Dmg?");
                }
            }

        }
    }
    }
>>>>>>> 8251ba052f715cad9bb503f8f3120f22217bb30a
