using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using UnityEditor.SearchService;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private Image blackScreen;
    [SerializeField] private GameObject settings;

    void Start()
    {
        StartCoroutine(FadeIn(1f));
    }
    public void LoadScene(string sceneName)
    {
        StartCoroutine(FadeOutAndLoad(sceneName));
    }
    IEnumerator FadeOutAndLoad(string sceneName)
    {
        yield return StartCoroutine(FadeOut(1f));
        SceneManager.LoadScene(sceneName);
    }

    public void ToggleSettings()
    {
        settings.SetActive(!settings.activeSelf);
    }

    #region BlackScreen Fade Transition

    IEnumerator FadeIn(float duration)
    {
        while (duration > 0)
        {
            blackScreen.color = new Color(0, 0, 0, duration);
            duration -= Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator FadeOut(float duration)
    {
        while (duration > 0)
        {
            blackScreen.color = new Color(0, 0, 0, 1f-duration);
            duration -= Time.deltaTime;
            yield return null;
        }
    }
    #endregion


}
