using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Slider OxygenSlider;
    private float countdown = 5;
    public float Life = 100;
    private AudioSource audio;
    public float DeOxygen = -5;
    public int test = 2;
    public float AddOxygen = 5;

    
    void Start() {
        audio = this.GetComponent<AudioSource>();
        Life = 100;
    }
    

    void Update() {
        if (Life <= 20) {
            GameObject.Find("Main Camera").SendMessage("doshake");
        }
        if (Life > 100) {
            Life = 100;
        }
        if (Life <= 0)
            GameManager.Instance.isDead = true;
        else {
            if (countdown <= 0) {
                countdown = test;
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


    void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.tag == "Rubbish") {
            audio.Play();
            GameManager.Instance.AddScore();
            collision.gameObject.transform.DOScale(0f, 0.5f);
            Destroy(collision.gameObject, 0.5f);
        }
        else {
            if (collision.gameObject.tag == "Sea") {
                DeOxygen = -3;
            }
        }

    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Oxygen") {
            DeOxygen = AddOxygen;

        }
    }


}
