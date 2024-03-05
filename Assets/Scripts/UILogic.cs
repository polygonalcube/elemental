using System.Collections;
using TMPro;
using UnityEngine;
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

    [SerializeField] GameObject options;
    [SerializeField] Slider senSlider;

    void Start()
    {
        StartCoroutine(TutorialDisplay());
        player = GameManager.gm.FindPlayerScript();
        options.SetActive(false);
    }

    void Update()
    {
        earth.gameObject.SetActive(player.unlocks[0]);
        fire.gameObject.SetActive(player.unlocks[1]);
        air.gameObject.SetActive(player.unlocks[2]);

        //method for moving UI elements; if this yields unexpected results, replace "localPosition" with "anchoredPosition"
        sel.GetComponent<RectTransform>().localPosition = new Vector3(650f + (120f * (int)player.element), -470f, 0f);

        if (Input.GetButtonDown("Pause"))
        {
            Time.timeScale = (Time.timeScale == 1f) ? 0f : 1f;
            Cursor.lockState = (Time.timeScale == 1f) ? CursorLockMode.Locked : CursorLockMode.None;
            options.SetActive(!options.activeSelf);
            if (!options.activeSelf) GameManager.gm.SetSensitivity(senSlider.value);
        }
    }

    IEnumerator TutorialDisplay()
    {
        float start = Time.time;
        tutor.gameObject.SetActive(true);
        yield return new WaitUntil(() => Time.time >= (start + tutorDuration));
        tutor.gameObject.SetActive(false);
    }
}
