using UnityEngine;

public class Sphere : Interactable
{
    protected override void Interact()
    {
        Debug.Log(PromptMessage);
        transform.position = transform.position * 5.0f;
    }
}
