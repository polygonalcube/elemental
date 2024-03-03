using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Allows for Singleton.
    public static GameManager gm;
    
    void Awake()
    {
        if (gm != null && gm != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            gm = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Differs from Mathf.Sign() in that it can return 0;
    public int Sign(float num)
    {
        if (num < 0)
        {
            return -1;
        }
        else if (num > 0)
        {
            return 1;
        }
        return 0;
    }

    public GameObject FindPlayer()
    {
        return GameObject.Find("Player");
    }

    public PlayerLogic FindPlayerScript()
    {
        return GameObject.Find("Player").GetComponent<PlayerLogic>();
    }

    // Destroys the given object in the specified time.
    // Was previously part of the SpawningComponent, but moved to the GameManager, 
    // due to issues with the SpawningComponent not being able to despawn the object if the SpawningComponent gets destroyed.
    IEnumerator Despawn(GameObject despawnee, float timer)
    {
        yield return new WaitForSeconds(timer);
        Destroy(despawnee);
    }
}
