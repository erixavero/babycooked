using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private Image blackScreen;
    private GameObject levelSelectMenu;

    void Start()
    {   
        levelSelectMenu = GameObject.FindGameObjectWithTag("Level Selection");
        levelSelectMenu?.SetActive(false);
        StartCoroutine(FadeIn(1f));
    }
    public void LoadScene(string sceneName)
    {
        StartCoroutine(FadeOutAndLoad(sceneName));
        AudioManager.instance.PlayMusic(sceneName);
    }

    public void RestartLevel()
    {
        StartCoroutine(FadeOutAndLoad(SceneManager.GetActiveScene().name));
    }
    IEnumerator FadeOutAndLoad(string sceneName)
    {
        yield return StartCoroutine(FadeOut(1f));
        // yield return null;
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void ToggleLevelSelectMenu()
    {
        levelSelectMenu?.SetActive(!levelSelectMenu.activeSelf);
    }

    #region BlackScreen Fade Transition

    IEnumerator FadeIn(float duration)
    {
        float timer = 0f;
        while (timer < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, timer / duration);
            blackScreen.color = new Color(0, 0, 0, alpha);
            timer += Time.deltaTime;
            yield return null;
        }
        blackScreen.color = new Color(0, 0, 0, 0f);
    }

    IEnumerator FadeOut(float duration)
    {
        float timer = 0f;
        while (timer < duration)
        {
            float alpha = Mathf.Lerp(0f, 1f, timer / duration);
            blackScreen.color = new Color(0, 0, 0, alpha);
            timer += Time.deltaTime;
            yield return null;
        }
        blackScreen.color = new Color(0, 0, 0, 1f);
    }
    #endregion

    public void QuitGame()
    {
        Application.Quit();
    }


}
