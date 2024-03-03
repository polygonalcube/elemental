using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class WoodDoor : MonoBehaviour
{
    public Material burning;
    public MeshRenderer mr;
    public float burnTime = 3f; 
    public bool isBurning = false;

    void Start()
    {
        burning.SetFloat("_ColorBurnBlend", 0f);
        burning.SetFloat("_FireEmissionStrength", 0f);
    }

    void Update()
    {
        if (isBurning)
        {
            burning.SetFloat("_ColorBurnBlend", (burning.GetFloat("_ColorBurnBlend") < 1.25f) ? (burning.GetFloat("_ColorBurnBlend") + (1.25f / 3f) * Time.deltaTime) : 1.25f);
            burning.SetFloat("_FireEmissionStrength", (burning.GetFloat("_FireEmissionStrength") < 4.5f) ? (burning.GetFloat("_FireEmissionStrength") + (4.5f / 3f) * Time.deltaTime) : 4.5f);
        }
    }
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Fire")
        {
            Destroy(col.gameObject);
            isBurning = true;
            StartCoroutine(Burn());
        }
    }

    IEnumerator Burn()
    {
        yield return new WaitForSeconds(burnTime);
        Destroy(this.gameObject);
    }
}
