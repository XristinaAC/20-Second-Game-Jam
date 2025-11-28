using UnityEngine;

public class ControlsPanelManager : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void Close()
    {
        this.gameObject.SetActive(false);
    }
}
