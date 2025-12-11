using UnityEngine;

public class LightSource : Interactable
{
    private LightBeam _beam;
    private bool _canFreeBeam;

    private void Start()
    {
        _beam = GetComponent<LightBeam>();
    }

    private void Update()
    {
        if(_canFreeBeam)
        {
            _beam.CreateBeam();
            _canFreeBeam = false;
        }
    }

    protected override void Interact()
    {
        Debug.Log(PromptMessage);
        _canFreeBeam = true;
    }
}
