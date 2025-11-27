using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        //SceneManager.LoadSceneAsync("VampireSurvivors");
    }

    public void OpenSettings()
    {
        SettingsMenuManager.Instance.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
