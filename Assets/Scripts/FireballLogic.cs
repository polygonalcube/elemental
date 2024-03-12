using System.Collections;
using UnityEngine;

public class FireballLogic : MonoBehaviour
{
    // The logic for the fireball projectile of the fire element.

    // On left click, shoots a fireball that travels straight & breaks upon collision. If it hits a wooden door, 
    // it will cause the door to burn & disappear.

    public MoveComponent mover;
    public Vector3 direction;
    public SpawningComponent effectSpawner; // Spawning Component for the burst particle effect.
    bool isDying = false; // Check for if the fireball is in the process of dying from collision.
    
    void Start()
    {
        mover = GetComponent<MoveComponent>();
        effectSpawner = GetComponent<SpawningComponent>();
    }

    void Update()
    {
        mover.MoveAngularly(direction);
    }

    IEnumerator Die()
    {
        isDying = true;
        effectSpawner.Spawn(transform.position, destroyTimer: 1f);
        yield return new WaitForSeconds(1f/60f); // Waits the equivalent of a physics frame to give relevant objects the opportunity to detect the collision.
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        // Starts the death process, unless the collider is a player or fire collider.
        // If dying is already taking place, a new coroutine won't start.
        if ((col.gameObject.tag != "Player") && (col.gameObject.tag != "Fire") && (isDying == false)) StartCoroutine(Die());
    }
}
