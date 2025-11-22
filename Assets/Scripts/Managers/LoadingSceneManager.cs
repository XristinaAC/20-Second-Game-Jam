using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    private float _delay = 20f;
    private float _timer = 0;

    void Start()
    {
        StartCoroutine(ReloadingSceneAfterSeconds());
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if(timerText)
        {
            if(_timer < 10)
            {
                timerText.text = "00 : 0" + ((int)_timer).ToString();
            }
            else
            {
                timerText.text = "00 : " + ((int)_timer).ToString();
            }    
        }
    }

    IEnumerator ReloadingSceneAfterSeconds()
    {
        yield return  new WaitForSeconds(_delay);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
