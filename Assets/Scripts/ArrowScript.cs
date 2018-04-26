using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowScript : MonoBehaviour {

    public GameObject arrowPrefab;

    private List<GameObject> Projectiles = new List<GameObject>();

    private float projectileVelocity;

    [SerializeField]
    private Image content;


    // Use this for initialization
    void Start () {
        projectileVelocity = 3.0f;
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    public void shootArrow()
    {
        GameObject arrow = (GameObject)Instantiate(arrowPrefab, transform.position, Quaternion.identity);
        Projectiles.Add(arrow);
        for (int i = 0; i < Projectiles.Count; i++)
        {
            GameObject goArrow = Projectiles[i];
            if (goArrow != null)
            {
                goArrow.transform.Translate(new Vector2(0, 1) * Time.deltaTime * projectileVelocity);

                Vector2 arrowScreenPos = Camera.main.WorldToScreenPoint(goArrow.transform.position);
                if (arrowScreenPos.y >= Screen.height || arrowScreenPos.y <= 0)
                {
                    DestroyObject(goArrow);
                    Projectiles.Remove(goArrow);
                }
            }
        }
    }
}
