using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Slider OxygenSlider;
    private float countdown = 10;
    public float Life = 100;
    private AudioSource audio;
    public float DeOxygen = -5;

    public float AddOxygen = 5;

   
	// Use this for initialization
	void Start ()
	{
	    audio = this.GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update() {

        if (Life <= 0)
            GameManager.Instance.isDead = true;
        else {
            if (countdown <= 0) {
                countdown = 10;
                Life += DeOxygen;
            }
            else
                countdown -= Time.deltaTime;
        }

        // 氧气值显示
        if (OxygenSlider != null) {
            OxygenSlider.value = Life / 100;
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
       
            if (collision.gameObject.tag == "Rubbish")
            {
                audio.Play();
            GameManager.Instance.AddScore();
                Destroy(collision.gameObject);
        }
            else
            {
                if (collision.gameObject.tag == "Sea")
                {
                    DeOxygen = -5;
                }
            }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Oxygen")
        {
            DeOxygen = AddOxygen;
           
        }
    }
}
