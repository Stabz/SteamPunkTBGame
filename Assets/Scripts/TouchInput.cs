using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
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
                    Debug.Log("btn?");
                }
            }
        }
    }
}
