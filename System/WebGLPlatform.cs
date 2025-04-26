using System.Runtime.InteropServices;
using UnityEngine;

public static class WebGLPlatform
{
    [DllImport("__Internal")]
    private static extern bool IsMobile();

    public static bool IsMobileDevice()
    {
        #if UNITY_WEBGL && !UNITY_EDITOR
                return IsMobile();
        #else
                return Application.isMobilePlatform;
        #endif
    }
}