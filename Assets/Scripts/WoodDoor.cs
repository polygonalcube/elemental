using System.Collections;
using UnityEngine;

public class WoodDoor : MonoBehaviour
{
    //public Material burning;
    public MeshRenderer mr;
    public float burnTime = 3f; 
    public bool isBurning = false;

    void Start()
    {
        //burning.SetFloat("_ColorBurnBlend", 0f);
        //burning.SetFloat("_FireEmissionStrength", 0f);

        Material[] mats = mr.sharedMaterials;

        mats[1].SetFloat("_ColorBurnBlend", 0f);
        mats[1].SetFloat("_FireEmissionStrength", 0f);

        mr.sharedMaterials = mats;
    }

    void Update()
    {
        if (isBurning)
        {
            //burning.SetFloat("_ColorBurnBlend", (burning.GetFloat("_ColorBurnBlend") < 1.25f) ? (burning.GetFloat("_ColorBurnBlend") + (1.25f / 3f) * Time.deltaTime) : 1.25f);
            //burning.SetFloat("_FireEmissionStrength", (burning.GetFloat("_FireEmissionStrength") < 4.5f) ? (burning.GetFloat("_FireEmissionStrength") + (4.5f / 3f) * Time.deltaTime) : 4.5f);
        
            Material[] mats = mr.sharedMaterials;

            mats[1].SetFloat("_ColorBurnBlend", (mats[1].GetFloat("_ColorBurnBlend") < 1.25f) ? (mats[1].GetFloat("_ColorBurnBlend") + (1.25f / 3f) * Time.deltaTime) : 1.25f);
            mats[1].SetFloat("_FireEmissionStrength", (mats[1].GetFloat("_FireEmissionStrength") < 4.5f) ? (mats[1].GetFloat("_FireEmissionStrength") + (4.5f / 3f) * Time.deltaTime) : 4.5f);

            mr.sharedMaterials = mats;
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
