
using UnityEngine;

public class BaseControllerFlag : MonoBehaviour
{
    public Flag Flag { get; private set; }
    public bool IsFlagPlaced { get; private set; }
    public bool IsHaveFlag { get; private set; } = true;

    public void SetFlag(Flag flag)
    {
        Flag = flag;
        IsFlagPlaced = true;
    }

    public void RemoveFlag()
    {
        IsFlagPlaced = false;
        IsHaveFlag = false;
    }
}
