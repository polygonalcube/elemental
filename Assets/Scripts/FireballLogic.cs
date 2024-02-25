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

    IEnumerator Die()
    {
        yield return new WaitForSeconds(1f/60f);
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        if ((col.gameObject.tag != "Player") && (col.gameObject.tag != "Fire")) StartCoroutine(Die());
    }
}
