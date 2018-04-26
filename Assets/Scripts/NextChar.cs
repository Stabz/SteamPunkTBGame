using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextChar : MonoBehaviour {


    private int NoClicks;
    public Button button1;
    GameObject[] pawns;

    private GameObject playerObject;
    private int numberOfCharacters = 2;

    // Use this for initialization
    void Start () {

        NoClicks = 0;
        pawns = GameObject.FindGameObjectsWithTag("Player");
        Button btn = button1.GetComponent<Button>();
        btn.onClick.AddListener(BtnPressed);
       

    }
	
	// Update is called once per frame
	void Update () {


        

    }


    void BtnPressed()
    {

        Debug.Log("trykket på knap");


        for (int i = 0; i < pawns.Length; i++)
        {
            pawns[i].GetComponent<warScript>().isSelected = false;
        }


        pawns[NoClicks].GetComponent<warScript>().isSelected = true;

      
        NoClicks++;

        if (NoClicks == numberOfCharacters+1)
        {
            NoClicks = 0;
        }


        
    }
}
