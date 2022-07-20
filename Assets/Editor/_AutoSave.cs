using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.Reflection;

[InitializeOnLoad]
public static class _AutoSave
{
    static _AutoSave()
    {
        EditorApplication.playModeStateChanged += _saveSceneWhenEntersPlayMode;
    }

    private static void _saveSceneWhenEntersPlayMode(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingEditMode)
        {
            Debug.Log("Auto-saving...");
            EditorSceneManager.SaveOpenScenes();
            AssetDatabase.SaveAssets();
        }
    }

    [MenuItem("_Covic/Clear console #%q")]
    public static void _ClearConsole()
    {
        var assembly = Assembly.GetAssembly(typeof(SceneView));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(null, null);


    }
}
