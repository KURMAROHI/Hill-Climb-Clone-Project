
using UnityEngine;
using UnityEditor;




public class KK : EditorWindow
{
    [MenuItem("KK/SwitchPlatform/Android", false, 1)]
    public static void Android()
    {
        //Debug.LogError("Android|" + PlayerSettings.applicationIdentifier);
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);
        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, "KK_UNITY_ANDROID");
    }

    [MenuItem("KK/SwitchPlatform/Windows", false, 2)]
    public static void Windows()
    {
        // Debug.LogError("Windows");
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Standalone, BuildTarget.StandaloneWindows);
        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, "KK_UNITY_WINDOWS");
    }

    [MenuItem("KK/DeletePlayerPrefs")]
    public static void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        EditorUtility.DisplayDialog("Cleared", "ok", "Ok");
    }
}
