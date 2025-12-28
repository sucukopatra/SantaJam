using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class CountdownUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] private float startTime = 10f;
    [SerializeField] private string sceneToLoad = "FirstHouse";

    private Coroutine countdownRoutine;

    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == sceneToLoad)
        {
            StartCountdown(startTime);
        }
    }

    public void StartCountdown(float time)
    {
        if (countdownRoutine != null)
            StopCoroutine(countdownRoutine);

        countdownRoutine = StartCoroutine(Countdown(time));
    }

    private IEnumerator Countdown(float time)
    {
        float t = time;

        while (t > 0f)
        {
            countdownText.text = Mathf.Ceil(t).ToString();
            yield return null;
            t -= Time.deltaTime;
        }

        countdownText.text = "0";
        countdownRoutine = null;

        SceneManager.LoadScene(sceneToLoad);
    }
}
