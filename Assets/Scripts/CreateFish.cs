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

    public int Num = 1;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if (Num >0)
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
        int indexX = Random.Range(-6, 6);

        
        int index = Random.Range(0,FishArray.Length);
       
            GameObject go = GameObject.Instantiate(FishArray[index], new Vector3(indexX, -8.5F, -2), Quaternion.identity) as GameObject;
           
           
      


    }
    public void InitializeFish(int num)
    {
        Num = num;
       Debug.Log("666");
    }

}
