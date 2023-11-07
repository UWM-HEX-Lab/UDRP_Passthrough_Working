using UnityEngine;
using Varjo.XR;

public class MRToggle : MonoBehaviour
{
    private bool isMixedRealityRenderingEnabled = false;


    private void Start()
    {
        VarjoMixedReality.StartRender();
        isMixedRealityRenderingEnabled = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (isMixedRealityRenderingEnabled)
            {
                VarjoMixedReality.StopRender();
                isMixedRealityRenderingEnabled = false;
            }
            else
            {
                VarjoMixedReality.StartRender();
                isMixedRealityRenderingEnabled = true;
            }
        }
    }
}
