using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UILogic : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tutor;
    [SerializeField] float tutorDuration = 7f;

    void Start()
    {
        StartCoroutine(TutorialDisplay());
    }

    IEnumerator TutorialDisplay()
    {
        float start = Time.time;
        tutor.gameObject.SetActive(true);
        yield return new WaitUntil(() => Time.time >= (start + tutorDuration));
        tutor.gameObject.SetActive(false);
    }
}
