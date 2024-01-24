using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballLogic : MonoBehaviour
{
    public MoveComponent mover;
    public Vector3 direction;
    
    void Start()
    {
        mover = GetComponent<MoveComponent>();
    }

    void Update()
    {
        mover.MoveAngularly(direction);
    }
}
