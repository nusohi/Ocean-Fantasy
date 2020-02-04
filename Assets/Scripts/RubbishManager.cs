using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RubbishManager : MonoBehaviour
{
   
    public float Left = -17;
    public float Right =17 ;
    public float high = 0.13f;
    public float low = -5.98f;
    public GameObject[] RubbishArray;
    private List<Vector2> positionList = new List<Vector2>();
    private Transform RubbishHolder;
    public float CountDown = 0;
    public float Num = 4;
    private float Speed = 3;
    void Update()
    {
        if(Num>0)
        {
            CountDown -= Time.deltaTime;
            if (CountDown <=0)
        {
            CreateRubbish();
            Num--;
            CountDown = Speed;
            return;
        }

        }
    }

    public void CreateRubbish()
    {
        int indexX = Random.Range(-1, 1);
        float indexY = Random.Range(low, high);
        int index = Random.Range(0, RubbishArray.Length);
        if (indexX >= 0)
        {
            GameObject go = GameObject.Instantiate(RubbishArray[index], new Vector3(Right, indexY, -2), Quaternion.identity) as GameObject;
        }
        else
        {
            GameObject go = GameObject.Instantiate(RubbishArray[index], new Vector3(Left, indexY, -2), Quaternion.identity) as GameObject; 
        }
         

    }

    public void Initialize(int num)
    {
        Num = num;
      
    }
}

