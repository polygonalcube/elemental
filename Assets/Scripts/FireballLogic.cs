using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballLogic : MonoBehaviour
{
    public MoveComponent mover;
    public Vector3 direction;
    public SpawningComponent spawner;
    bool isDying = false;
    
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
        isDying = true;
        spawner.Spawn(transform.position, destroyTimer: 1f);
        yield return new WaitForSeconds(1f/60f);
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        /*if (col.gameObject.tag != "Player")
        {
            GameObject fireburst = Instantiate(FireBurst, gameObject.transform.position, Quaternion.identity);
            fireburst.GetComponent<ParticleSystem>().Play();
            // I tried this after the spawning component didnt work, so I tried to
            // make it just despawn using the despawner in the component, to control
            // the time, but it's at a protected level so this won't work.
            //StartCoroutine(spawner.Despawn(fireburst, 5));
            // I tried to use the spawning component and didn't get it right
            //spawner.Spawn(gameObject.transform.position, FireBurst, false, 5);
        }*/
        if ((col.gameObject.tag != "Player") && (col.gameObject.tag != "Fire") && isDying == false) StartCoroutine(Die());
    }
}
