using UnityEngine;

public class SettingsMenuManager : MonoBehaviour
{
    public static SettingsMenuManager Instance = null;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
