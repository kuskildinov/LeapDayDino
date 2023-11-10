using UnityEngine;

public class DesktopInput : IInput
{
    public bool PlayerTap()
    {
        //if(Input.touchCount > 0)
        //    return true;        
        if(Input.GetMouseButtonDown(0))
            return true;
        
        return false;
    }
}
