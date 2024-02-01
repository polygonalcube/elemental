using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarLogic : MonoBehaviour
{
    public MoveComponent mover;
    public Vector3 direction;
    public float movAmt = 0f;
    
    void Start()
    {
        mover = GetComponent<MoveComponent>();
        movAmt = 0f;
    }

    void Update()
    {
        float prevY = transform.position.y;
        if (movAmt < 5f)
        {
            mover.MoveAngularly(direction);
        }
        movAmt += Mathf.Abs(transform.position.y - prevY);
    }
}
