using UnityEngine;

public class MirrorBase : Interactable
{
    private Vector3 qu;
    bool rotate = false;

    private void Update()
    {
        if(rotate)
        {
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, qu, 10 * 40 * Time.deltaTime);
            rotate = false;
        }
    }

    protected override void Interact()
    {
        Debug.Log(PromptMessage);
        qu = transform.eulerAngles + 90f * Vector3.up;
        rotate = true;
        //transform.Rotate(0, 90, 0); 
    }
}
