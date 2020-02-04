using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RubbishMove : MonoBehaviour
{
    public float indexX = 0;
    public float CountDown = 0;
    public float indexY = 0;
    public float Speed = 10f;
    void Update()
    {
            CountDown -= Time.deltaTime;
            if (CountDown <= 0)
            {
                Move();
                CountDown = 4;
            }  
    }
    void Move()
    {
        indexX = Random.Range(-16f, 6.54f);
        indexY = Random.Range(-14.52f, 1.56f);
        Tweener fish = this.transform.DOMove(new Vector3(indexX, indexY, -2), Speed);
        fish.SetEase(Ease.Linear);
    }
  
}
