using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingComponent : MonoBehaviour
{
    public SpawningComponent spawner;

    public Vector3 speed;
    public float angularSpeed;
    float shotDelay;
    public float shotDelaySet;
    
    void Start()
    {
        shotDelay = 0f;
    }

    void Update()
    {
        shotDelay -= Time.deltaTime;
    }

    public void Shoot(Vector3 startingPosition, Vector3 shotDirection)
    {
        if (shotDelay <= 0)
        {
            GameObject newProjectile = spawner.Spawn(transform.position);
            if (newProjectile.TryGetComponent<MoveComponent>(out MoveComponent mover))
            {
                mover.angularSpeed = angularSpeed;
            }
            if (shotDirection != Vector3.zero)
            {
                if (newProjectile.TryGetComponent<FireballLogic>(out FireballLogic fireball))
                {
                    fireball.direction = shotDirection;
                }
            }
            shotDelay = shotDelaySet;
        }
    }
}