using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameManager instance;
    float countdown = 10;
    public float Life = 100;

    public float Oxygen = -1;

    public float AddOxygen = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
        
        if (Life <= 0)
            GameManager.Instance.isDead = true;
        else
        {
            if (countdown <= 0)
            {
                countdown = 10;
                Life += Oxygen;
            }
            else
                countdown -= Time.deltaTime;
        }
	}


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rubbish")
        {  Debug.Log("sdasda");
           // GameManager.Instance.AddScore();
            Destroy(collision.gameObject);
        }
        else
        {
            if (collision.gameObject.tag == "Oxygen")
            {
                Oxygen = AddOxygen;
            }
        }
    }
}
