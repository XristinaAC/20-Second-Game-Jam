using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject controls_menu;

    public void PlayGame()
    {
        //SceneManager.LoadSceneAsync("VampireSurvivors");
    }

    public void OpenSettings()
    {
        if (controls_menu.activeInHierarchy)
        {
            controls_menu.SetActive(false);
        }
        SettingsMenuManager.Instance.gameObject.SetActive(true);
    }

    public void OpenControlsPanel()
    {
        if(SettingsMenuManager.Instance.gameObject.activeInHierarchy)
        {
            SettingsMenuManager.Instance.gameObject.SetActive(false);
        }
        controls_menu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
