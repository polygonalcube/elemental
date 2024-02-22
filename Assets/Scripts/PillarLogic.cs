using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarLogic : MonoBehaviour
{
    public MoveComponent mover;
    [SerializeField] SpawningComponent spawner;

    public Vector3 direction;
    public float movAmt = 0f;
    public float movMul = 0.1f;
    public float slowMovThres = 1f;
    public Vector3 movRef;
    
    void Start()
    {
        mover = GetComponent<MoveComponent>();
        spawner = GetComponent<SpawningComponent>();
        spawner.Spawn(transform.position + (Vector3.up * 5f));
        movAmt = 0f;
    }

    void Update()
    {
        float prevY = transform.position.y;
        if (movAmt < slowMovThres)
        {
            movRef = mover.MoveAngularly(direction * movMul);
        }
        else if (movAmt < 5f)
        {
            movRef = mover.MoveAngularly(direction);
        }
        movAmt += Mathf.Abs(transform.position.y - prevY);
    }
}
