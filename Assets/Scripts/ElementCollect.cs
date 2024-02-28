//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class ElementCollect : MonoBehaviour
{
    // The logic for the permanent element power-ups.

    //                     earth, fire,  air
    public bool[] which = {false, false, true};

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerLogic player = GameManager.gm.FindPlayerScript();
            for (int i = 0; i < player.unlocks.Length; i++)
            {
                if (which[i]) player.unlocks[i] = which[i];
            }
            Destroy(this.gameObject);
        }
    }
}
