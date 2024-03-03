//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    // A wind-powered lever for opening doors.

    // By hitting the lever with a gust of wind, it will activate and raise any associated doors.

    public Transform pullPart; // The transform for the part of the lever that's pulled.
    public bool hasActivated = false; // Check for if the lever has been activated by wind.
    public float amountRotated = 0f;
    public float rotSpdMultiplier = 0.1f;

    public Transform[] doors;
    Vector3[] positions;
    public float ascendSpd = 1.5f;

    void Start()
    {
        pullPart.eulerAngles = new Vector3(0f, 0f, -45f);
        positions = new Vector3[doors.Length];
    }

    void Update()
    {
        if (hasActivated)
        {
            float prevRot = pullPart.eulerAngles.z;
            if (amountRotated < 90f) pullPart.eulerAngles -= new Vector3(0f, 0f, 1f) * rotSpdMultiplier;
            amountRotated += Mathf.Abs(pullPart.eulerAngles.z - prevRot);
            if ((doors[0] != null) && (doors[1] != null))
            {
                for (int i = 0; i < doors.Length; i++)
                {
                    if (doors[i].position.y < (positions[i].y + 10f)) doors[i].position += Vector3.up * ascendSpd * Time.deltaTime;
                }
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Air")
        {
            hasActivated = true;
            if ((doors[0] != null) && (doors[1] != null))
            {
                for (int i = 0; i < doors.Length; i++) positions[i] = doors[i].position;
            }
        }
    }
}
