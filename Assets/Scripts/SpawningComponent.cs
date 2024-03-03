using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class SpawningComponent : MonoBehaviour
{
    public GameObject spawnedObject;
    
    public GameObject Spawn(Vector3 spawnPosition, GameObject parent = null, bool localPositioning = false, float destroyTimer = 0f)
    {
        GameObject newObject = Instantiate(spawnedObject, spawnPosition, Quaternion.identity);
        if (parent != null)
        {
            newObject.transform.SetParent(parent.transform);
        }
        if (destroyTimer > 0f)
        {
            StartCoroutine(GameManager.gm.Despawn(newObject, destroyTimer));
            // Note: This also works [GameManager.gm.StartCoroutine(Despawn(newObject, destroyTimer));].
        }
        return newObject;
    }

    // Moved to the GameManager.
    /*IEnumerator Despawn(GameObject despawnee, float timer)
    {
        yield return new WaitForSeconds(timer);
        Destroy(despawnee);
    }*/
}