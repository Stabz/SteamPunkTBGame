using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour {
    [SerializeField]
    private float FillAmount;


    [SerializeField]
    private Image Content;

    public float MaxValue { get;  set; }

    public float Value
    {
        set
        {
            FillAmount = Map(value, 0, MaxValue, 0, 1);
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void HandleBar ()
    {
        if(FillAmount != Content.fillAmount)
        {
            Content.fillAmount = FillAmount;
        }

        

    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        // (currentvalue = 80 - ingameminimum= 0) * (outMax= 1 - outMin = 0) / (ingameMax = 100 - 0) + 0
        // 80 * 1 / 100 = 0.8

    }
}
