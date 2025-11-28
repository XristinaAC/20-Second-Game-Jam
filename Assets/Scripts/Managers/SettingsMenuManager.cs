using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuManager : MonoBehaviour
{
    [Serializable]
    struct WindowModes
    {
        public string mode;
        public bool fullscreen;
    }
    public static SettingsMenuManager Instance = null;

    [SerializeField] GameObject audioMenu;
    [SerializeField] GameObject graphicsMenu;
    [SerializeField] Toggle VSync = null;
    [SerializeField] List<Vector2> resolutions = new List<Vector2>();
    //[SerializeField] List<string> window_modes = new List<string>();
    [SerializeField] List<WindowModes> window_modes = new List<WindowModes>();
    [SerializeField] TMP_Text resolutions_text = null;
    [SerializeField] TMP_Text window_mode_text = null;
    
    int selected_resolution = 0;
    int selected_wm = 0;
    public Vector2 resolution = new();
    bool fullscreen;

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
        Screen.fullScreen = true;
        window_mode_text.text = window_modes[0].mode;
        this.gameObject.SetActive(false);
        if (QualitySettings.vSyncCount == 0)
        {
            VSync.isOn = false;
        }
        else
        {
            VSync.isOn = true;
        }
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

    public void Close_Settings()
    {
        this.gameObject.SetActive(false);
    }

    public void Res_Left_Arrow()
    {
        selected_resolution--;
        if (selected_resolution < 0)
        {
            selected_resolution = 0;
        }

        Update_Resolutions_Text();
    }

    public void Res_Right_Arrow()
    {
        selected_resolution++;
        if (selected_resolution > resolutions.Count - 1)
        {
            selected_resolution = resolutions.Count - 1;
        }

        Update_Resolutions_Text();
    }

    public void Update_Resolutions_Text()
    {
        resolutions_text.text = resolutions[selected_resolution].x.ToString() + " x " + resolutions[selected_resolution].y.ToString();
    }

    public void Apply_Changes()
    {
        if (VSync.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }

        Screen.SetResolution((int)resolutions[selected_resolution].x, (int)resolutions[selected_resolution].y, fullscreen);
    }


    public void wm_Res_Left_Arrow()
    {
        selected_wm--;
        if (selected_wm < 0)
        {
            selected_wm = 0;
        }

        Update_WindowMode_Text();
    }

    public void wm_Res_Right_Arrow()
    {
        selected_wm++;
        if (selected_wm > window_modes.Count - 1)
        {
            selected_wm = window_modes.Count - 1;
        }

        Update_WindowMode_Text();
    }

    public void Update_WindowMode_Text()
    {
        window_mode_text.text = window_modes[selected_wm].mode;
        fullscreen = window_modes[selected_wm].fullscreen;
    }
}

//public void Start()
//{
//    this.gameObject.SetActive(false);
//    fullscreen.isOn = Screen.fullScreen;
//    //sound_volume.value = audio.volume;

//    if (QualitySettings.vSyncCount == 0)
//    {
//        VSync.isOn = false;
//    }
//    else
//    {
//        VSync.isOn = true;
//    }
//}


//public void Close_Settings()
//{
//    AudioManager.Instance.PlaySFX(AudioManager.Instance.buttonEffecct);
//    if (this.gameObject.activeInHierarchy)
//    {
//        this.gameObject.SetActive(false);
//    }
//}



