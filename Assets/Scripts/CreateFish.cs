using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFish : MonoBehaviour
{
    public GameObject[] FishArray;
    public float Left = -20;
    public float Right = 10;
    public float CountDown = 0;
    public int Num = 1;
    void Update()
    {
        if (Num >0)
        {
            CountDown -= Time.deltaTime;
            if (CountDown <= 0)
            {
                Create();
                Num--;
                CountDown = 3;
            }
        }
    }

    public void Create()
    {
        int indexX = (int)Random.Range(Left, Right);
        int index = Random.Range(0,FishArray.Length);
        GameObject go = GameObject.Instantiate(FishArray[index], new Vector3(indexX, -20, -2), Quaternion.identity) as GameObject;
    }
    public void InitializeFish(int num)
    {
        Num = num;
    }

}
