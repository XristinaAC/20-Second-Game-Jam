using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private bool _hasCrossKey = false;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHasCrossKey(bool hasKey)
    {
        _hasCrossKey = hasKey;
    }

    public bool GetHasCrossKey()
    {
        return _hasCrossKey;
    }
}
