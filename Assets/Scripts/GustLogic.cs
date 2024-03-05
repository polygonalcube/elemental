using System.Collections;
using UnityEngine;

public class GustLogic : MonoBehaviour
{
    // The logic for the gust projectile of the air element.

    // On left click, shoots a gust of wind that travels straight & breaks upon collision. If it hits a lever, the lever will activate.
    
    public MoveComponent mover;
    public Vector3 direction;
    
    void Start()
    {
        mover = GetComponent<MoveComponent>();
        transform.rotation = Quaternion.LookRotation(direction); // Aligns the rotation of the projectile with the direction its moving in.
    }

    void Update()
    {
        mover.MoveAngularly(direction);
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(1f/60f); // Waits the equivalent of a physics frame to give relevant objects the opportunity to detect the collision.
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        // Starts the death process, unless the collider is a player or air collider.
        if ((col.gameObject.tag != "Player") && (col.gameObject.tag != "Air")) StartCoroutine(Die());
    }
}
