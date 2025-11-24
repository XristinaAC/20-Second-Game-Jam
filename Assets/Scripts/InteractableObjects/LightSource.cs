using UnityEngine;

public class LightSource : Interactable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        }
    }

    protected override void Interact()
    {
        Debug.Log(PromptMessage);
        _canFreeBeam = true;
    }
}
