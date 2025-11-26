using UnityEngine;

public class Key : Interactable
{
    [SerializeField] private GameObject _player;
    protected override void Interact()
    {
        Debug.Log(PromptMessage);
        _player.GetComponent<PlayerManager>().SetHasCrossKey(true);
    }
}
