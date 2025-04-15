using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public void GoToLogin()
    {
        SceneLoader.Load(SceneLoader.Scene.LoginScene);
    }

    public void GoToRegistreer()
    {
        SceneLoader.Load(SceneLoader.Scene.RegistreerScene);
    }

    public void GoToMijnWerelden()
    {
        SceneLoader.Load(SceneLoader.Scene.MijnWereldenScene);
    }

    public void GoToWereld()
    {
        SceneLoader.Load(SceneLoader.Scene.WereldScene);
    }

    public void GoToRofL()
    {
        SceneLoader.Load(SceneLoader.Scene.RofLScene);
    }
}
