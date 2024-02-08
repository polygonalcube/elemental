using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public Transform pull;
    public bool isOn = false;
    public float rotAmt = 0f;
    public float rotMulti = 0.1f;

    void Start()
    {
        pull.eulerAngles = new Vector3(-45f, pull.eulerAngles.y, pull.eulerAngles.z);
    }

    void Update()
    {
        if (isOn)
        {
            float prevRot = pull.eulerAngles.x;
            if (rotAmt < 90f)
            {
                pull.eulerAngles -= new Vector3(1f, 0f, 0f) * rotMulti;
            }
            rotAmt += Mathf.Abs(pull.eulerAngles.x - prevRot);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Air")
        {
            isOn = true;
        }
    }
}