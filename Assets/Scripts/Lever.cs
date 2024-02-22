using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public Transform pull;
    public bool isOn = false;
    public float rotAmt = 0f;
    public float rotMulti = 0.1f;

    public Transform[] doors;
    Vector3[] positions;
    public float ascendSpd = 1.5f;

    void Start()
    {
        pull.eulerAngles = new Vector3(-45f, pull.eulerAngles.y, pull.eulerAngles.z);
        positions = new Vector3[doors.Length];
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
            for (int i = 0; i < doors.Length; i++)
            {
                if (doors[i].position.y < (positions[i].y + 10f)) doors[i].position += Vector3.up * ascendSpd * Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Air")
        {
            isOn = true;
            for (int i = 0; i < doors.Length; i++)
            {
                positions[i] = doors[i].position;
            }
        }
    }
}
