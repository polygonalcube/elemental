using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GustLogic : MonoBehaviour
{
    public MoveComponent mover;
    public Vector3 direction;
    
    void Start()
    {
        mover = GetComponent<MoveComponent>();
        transform.rotation = Quaternion.LookRotation(direction);
        Debug.Log(transform.rotation);
    }

    void Update()
    {
        mover.MoveAngularly(direction);
    }
}
