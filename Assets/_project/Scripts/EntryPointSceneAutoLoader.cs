
using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public static class EntryPointSceneAutoLoader
{
    private const string MENUPATH = "PlayFromBootstrap/Enabled";
    private const string PLAYFROMBOOTSTRAPKEY = "PlayFromBootstrapKey";
    private const int BOOTSCENEINDEX = 0;

    static EntryPointSceneAutoLoader()
    {
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
    }

    private static void OnPlayModeStateChanged(PlayModeStateChange state)
    {
       if(state == PlayModeStateChange.ExitingEditMode)
        {
            if(EditorPrefs.GetBool(PLAYFROMBOOTSTRAPKEY) == false)
            {
                EditorSceneManager.playModeStartScene = null;
                return;
            }

            if(EditorBuildSettings.scenes.Length == 0 )
            {
                return;
            }

            EditorSceneManager.playModeStartScene = AssetDatabase
                .LoadAssetAtPath<SceneAsset>(EditorBuildSettings.scenes[BOOTSCENEINDEX].path);
        }
    }

    [MenuItem(MENUPATH)]
    private static void Toggle()
    {
        bool result = EditorPrefs.GetBool(PLAYFROMBOOTSTRAPKEY);
        EditorPrefs.SetBool(PLAYFROMBOOTSTRAPKEY, !result);
    }

    [MenuItem(MENUPATH, true)]
    private static bool ToggleValidate()
    {
        Menu.SetChecked(MENUPATH, EditorPrefs.GetBool(PLAYFROMBOOTSTRAPKEY));
        return true;
    }
}
