using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Life = 100;

    public float Oxygen = -1;

    public float AddOxygen = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Life += Oxygen;
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Rubbish")
        {
            GameObject.Find("GameManager").SendMessage("AddScore");
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
