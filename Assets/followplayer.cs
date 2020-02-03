using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followplayer : MonoBehaviour
{
    public Transform follow;
    private Vector3 m_TargetPosition;
    void Start()
    {
       
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(follow.position.x,follow.position.y,transform.position.z);
        transform.LookAt(follow);
    }

 
}
