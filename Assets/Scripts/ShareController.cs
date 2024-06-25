using UnityEngine;

public class ShareController : MonoBehaviour
{

    public void OnShareButonClick()
    {
        Debug.LogError(" On Share Button Click");
#if UNITY_ANDROID
        ShareInAndroindDevices();
#else
#endif
    }

    void ShareInAndroindDevices()
    {
        //Intent SendIntent=new Intent();
    }
}
