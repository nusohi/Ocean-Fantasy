﻿using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FishMove : MonoBehaviour
{
    public int indexX = 0;
    public float CountDown = 4;
    public float indexY = 0;
    private int Switch = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Switch > 0)
        {
            CountDown -= Time.deltaTime;
            if (CountDown <= 0)
            {
                Move();
                CountDown = 4;
            }
        }
    }

    void Move()
    {
         indexX = Random.Range(-5,4);


         indexY = Random.Range(0.4f, -5.8f);
        Tweener fish= this.transform.DOMove(new Vector3(indexX, indexY, -2), 4f);
        fish.SetEase(Ease.Linear);

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rubbish")
        {
            Switch = -1;
            Debug.Log("dsdas");
            Tweener fish = this.transform.DOMove(new Vector3(21.42f, -0.08f, -2), 10f);
            fish.OnComplete(Destroy);
            Destroy(collision.gameObject);
           
        }
    }

    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
