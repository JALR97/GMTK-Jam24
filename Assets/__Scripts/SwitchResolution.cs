using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchResolution : MonoBehaviour
{
    private bool smallerRes = false;

    public void SwitchRes()
    {
        if (smallerRes)
            Screen.SetResolution(1280, 720, false);
        else
            Screen.SetResolution(640, 360, false);
        //
        smallerRes = !smallerRes;
        
    }
    
}
