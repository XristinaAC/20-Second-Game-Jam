using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private bool _hasCrossKey = false;
    private bool _hasCross = false;

    public void SetHasCrossKey(bool hasKey)
    {
        _hasCrossKey = hasKey;
    }

    public bool GetHasCrossKey()
    {
        return _hasCrossKey;
    }

    public void SetHasCross(bool hasKey)
    {
        _hasCross = hasKey;
    }

    public bool GetHasCross()
    {
        return _hasCross;
    }
}
