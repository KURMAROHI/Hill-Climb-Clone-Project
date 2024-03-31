
using UnityEngine;
using UnityEditor;
using System.IO;





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

    [MenuItem("KK/ClearDirectory")]
    public static void ClearDirectory()
    {
        foreach (string _Directory in Directory.GetDirectories(Application.persistentDataPath))
        {
            DirectoryInfo directory = new DirectoryInfo(_Directory);
            Debug.Log("Delete Fileinfo|" + _Directory);
            directory.Delete(true);
        }
    }

    [MenuItem("KK/ClearAllFiles")]
    public static void ClearAllFiles()
    {
        foreach (string _file in Directory.GetFiles(Application.persistentDataPath))
        {
            FileInfo fileInfo = new FileInfo(_file);
            Debug.Log("Delete Fileinfo|" + _file);
            fileInfo.Delete();
        }
    }

    [MenuItem("KK/Persistentdatapath")]

    public static void Persistentdatapath()
    {
        EditorUtility.RevealInFinder(Application.persistentDataPath);
    }


}
