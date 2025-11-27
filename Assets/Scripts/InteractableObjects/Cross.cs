using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Cross : Interactable
{
    private void Update()
    {
        
    }

    [SerializeField] private GameObject _player;
    protected override void Interact()
    {
        Debug.Log(PromptMessage);
        _player.GetComponent<PlayerManager>().SetHasCross(true);
        this.gameObject.SetActive(false);
    }
}
