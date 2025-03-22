using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class TutorialManager : MonoBehaviour
{
    public CanvasGroup controlsTutorial;
    public CanvasGroup obstacleTutorial;
    public CanvasGroup stationTutorial;
    public float fadeDuration;
    public float visibleDuration;

    private bool isPaused = false;

    public static TutorialManager Instance;


    private void Start()
    {
        HideInstant();
        if (PlayerPrefs.GetInt("controlsTutorial", 0) == 0)
        {
            Show(0);
            PlayerPrefs.SetInt("controlsTutorial", 1);
        }
    }



    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Show(int choice)
    {
        if (isPaused) return;

        CanvasGroup current = controlsTutorial;
        if (choice == 1)
        {
            current = obstacleTutorial;
        }
        else if (choice == 2)
        {
            current = stationTutorial;
        }

        StartCoroutine(ShowAndAutoHide(current));
    }

    private IEnumerator ShowAndAutoHide(CanvasGroup group)
    {
        Time.timeScale = 0;
        yield return StartCoroutine(FadeCanvasGroup(1, group));


        isPaused = true;


        yield return new WaitForSecondsRealtime(visibleDuration);

        yield return StartCoroutine(FadeCanvasGroup(0, group));

        Time.timeScale = 1;
        isPaused = false;
        
    }

    private IEnumerator FadeCanvasGroup(float targetAlpha, CanvasGroup group)
    {
        float startAlpha = group.alpha;
        float time = 0;

        while (time < fadeDuration)
        {
            time += Time.unscaledDeltaTime;
            group.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);
            yield return null;
        }

        group.alpha = targetAlpha;
        group.interactable = targetAlpha > 0;
        group.blocksRaycasts = targetAlpha > 0;
    }

    public void HideInstant()
    {
        controlsTutorial.alpha = 0;
        controlsTutorial.interactable = false;
        controlsTutorial.blocksRaycasts = false;

        obstacleTutorial.alpha = 0;
        obstacleTutorial.interactable = false;
        obstacleTutorial.blocksRaycasts = false;

        stationTutorial.alpha = 0;
        stationTutorial.interactable = false;
        stationTutorial.blocksRaycasts = false;

    }
}