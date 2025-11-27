using UnityEngine;

public class SettingsMenuManager : MonoBehaviour
{
    public static SettingsMenuManager Instance = null;

    [SerializeField] GameObject audioMenu;
    [SerializeField] GameObject graphicsMenu;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        this.gameObject.SetActive(false);
        graphicsMenu.SetActive(true);
    }

    void Update()
    {
        
    }

    public void AudioMenu()
    {
        graphicsMenu.SetActive(false);
        audioMenu.SetActive(true);
    }

    public void GraphicsMenu()
    {
        graphicsMenu.SetActive(true);
        audioMenu.SetActive(false);
    }
}
