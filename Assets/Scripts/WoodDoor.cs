using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodDoor : MonoBehaviour
{
    public Material burning;
    public MeshRenderer mr;
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
        List<Material> mats = new List<Material>();
        mats.Add(burning);
        mr.SetMaterials(mats);
        yield return new WaitForSeconds(burnTime);
        Destroy(this.gameObject);
    }
}
