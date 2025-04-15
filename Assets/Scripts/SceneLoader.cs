using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement; // For scene loading

public static class SceneLoader
{
    public enum Scene
    {
        // Define your scenes here, for example:
        RofLScene,
        LoginScene,
        RegistreerScene,
        MijnWereldenScene,
        WereldScene,
    }

    public static void Load(Scene scene)
    {
        // Convert enum to string to load the scene
        SceneManager.LoadScene(scene.ToString());
    }
}
