using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementCollect : MonoBehaviour
{
    public bool[] which = {false, false, true};

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerLogic player = col.gameObject.GetComponent<PlayerLogic>();
            for (int i = 0; i < player.unlocks.Length; i++)
            {
                if (which[i])
                {
                    player.unlocks[i] = which[i];
                }
            }
            Destroy(this.gameObject);
        }
    }
}
