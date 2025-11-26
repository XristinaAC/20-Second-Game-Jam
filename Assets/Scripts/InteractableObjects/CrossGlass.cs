using UnityEngine;

public class CrossGlass : Interactable
{
    [SerializeField] private GameObject _player;
    protected override void Interact()
    {
        Debug.Log(PromptMessage);
        if(_player.GetComponent<PlayerManager>().GetHasCrossKey())
        {
            //Debug.Log("Player has the key");
            this.GetComponent<Animator>().SetBool("IsOpening", true);
        }
    }

    public void EndAnimation()
    {
        this.GetComponent<Animator>().SetBool("IsOpening", false);
    }
}
