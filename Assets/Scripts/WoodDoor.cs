using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodDoor : MonoBehaviour
{
    public float burnTime = 3f; 
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Fire")
        {
            Destroy(col.gameObject);
            StartCoroutine(Burn());
        }
    }

    IEnumerator Burn()
    {
        yield return new WaitForSeconds(burnTime);
        Destroy(this.gameObject);
    }
}
