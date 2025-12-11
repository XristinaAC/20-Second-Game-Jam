using UnityEngine;

public class MirrorBase : Interactable
{
    public static MirrorBase instance = null;

    private Vector3 qu;
    bool rotate = false;
    bool checkR = false;
    float waitT = 0;
    float waitTimer = 2;
    public bool new_surface;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        new_surface = true;
    }

    private void Update()
    {
        if(rotate)
        {
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, qu, 10 * 40 * Time.deltaTime);
            rotate = false;
            checkR = true;
        }

        if(checkR)
        {
            //LightBeam.instance.Reflect();
            checkR = false;
        }
    }

    protected override void Interact()
    {
        Debug.Log(PromptMessage);
        qu = transform.eulerAngles + 90f * Vector3.up;
        new_surface = true;
        rotate = true;
    }
}
