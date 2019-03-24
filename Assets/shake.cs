using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class shake : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void doshake()
    {
        transform.DOShakePosition(5, new Vector3(0.05f, 0.05f, 0));
    }
}
