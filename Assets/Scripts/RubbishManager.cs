using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RubbishManager : MonoBehaviour
{

    public int rows = 10;
    public int cols = 10;
    public GameObject[] RubbishArray;
    private List<Vector2> positionList = new List<Vector2>();
    private Transform RubbishHolder;

    public float CountDown = 10;

    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CountDown -= Time.deltaTime;
        if (CountDown <=0)
        {
            CreateRubbish();
            CountDown = 10;
            return;
        }
    }

    public void CreateRubbish()
    {
        int indexX = Random.Range(0, cols);
        int indexY = Random.Range(0, rows);
        int index = Random.Range(0, RubbishArray.Length);
        GameObject go = GameObject.Instantiate(RubbishArray[index], new Vector3(indexX, indexY, 0), Quaternion.identity) as GameObject;
        go.transform.SetParent(RubbishHolder);
        Rigidbody rigidbody = go.GetComponent<Rigidbody>();
        rigidbody.velocity=new Vector3(10,0,0);
        Destroy(go.gameObject,8f);
    }
}

