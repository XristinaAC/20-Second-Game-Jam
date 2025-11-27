using UnityEngine;

public class Altar : Interactable
{
    [SerializeField] private GameObject _cross;
    //[SerializeField] private Transform _placementPosition;
    protected override void Interact()
    {
        Debug.Log(PromptMessage);
        _cross.transform.Rotate(0, 0, 45);
        _cross.SetActive(true);
        _cross.transform.position = this.transform.position;
    }
}
