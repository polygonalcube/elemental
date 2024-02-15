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

    [SerializeField] Image earth;
    [SerializeField] Image fire;
    [SerializeField] Image air;
    [SerializeField] Image sel;
    PlayerLogic player;

    void Start()
    {
        StartCoroutine(TutorialDisplay());
        player = GameManager.gm.FindPlayerScript();
    }

    void Update()
    {
        earth.gameObject.SetActive(player.unlocks[0]);
        fire.gameObject.SetActive(player.unlocks[1]);
        air.gameObject.SetActive(player.unlocks[2]);

        //method for moving UI elements; if this yields unexpected results, replace "localPosition" with "anchoredPosition"
        sel.GetComponent<RectTransform>().localPosition = new Vector3(650f + (120f * (int)player.element), -470f, 0f);
    }

    IEnumerator TutorialDisplay()
    {
        float start = Time.time;
        tutor.gameObject.SetActive(true);
        yield return new WaitUntil(() => Time.time >= (start + tutorDuration));
        tutor.gameObject.SetActive(false);
    }
}
