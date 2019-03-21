using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFish : MonoBehaviour
{
    public GameObject[] FishArray;
    private float Left = -28;
    private float Right = 28;
    private float high = 0.13f;
    private float low = -5.98f;
    public float CountDown = 3;

    public int Num = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Num >= 0)
        {
            CountDown -= Time.deltaTime;
            if (CountDown <= 0)
            {
                Create();
                Num--;
                CountDown = 5;
            }
        }
    }

    public void Create()
    {
        int indexX = Random.Range(-1, 1);

        float indexY = Random.Range(low, high);
        int index = Random.Range(0,FishArray.Length);
        if (indexX >= 0)
        {
            GameObject go = GameObject.Instantiate(FishArray[index], new Vector3(Right, indexY, -2), Quaternion.identity) as GameObject;
           
           
        }
        else
        {
            GameObject go = GameObject.Instantiate(FishArray[index], new Vector3(Left, indexY, -2), Quaternion.identity) as GameObject;
           
           
        }


    }
    public void InitializeFish(int num)
    {
        Num = num;
       
    }

}
