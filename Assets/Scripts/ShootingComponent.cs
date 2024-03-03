//using System.Collections;
//using System.Collections.Generic;
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

    public GameObject Shoot(Vector3 startingPosition, Vector3 shotDirection, GameObject parent = null, bool localPositioning = false, float destroyTimer = 0f)
    {
        if (shotDelay <= 0)
        {
            GameObject newProjectile = spawner.Spawn(startingPosition, parent, localPositioning, destroyTimer);
            if (newProjectile.TryGetComponent<MoveComponent>(out MoveComponent mover))
            {
                mover.angularSpeed = angularSpeed;
            }
            if (shotDirection != Vector3.zero)
            {
                if (newProjectile.TryGetComponent<PillarLogic>(out PillarLogic pillar))
                {
                    pillar.direction = shotDirection;
                }
                if (newProjectile.TryGetComponent<FireballLogic>(out FireballLogic fireball))
                {
                    fireball.direction = shotDirection;
                }
                if (newProjectile.TryGetComponent<GustLogic>(out GustLogic gust))
                {
                    gust.direction = shotDirection;
                }
            }
            shotDelay = shotDelaySet;
            return newProjectile;
        }
        return null;
    }
}