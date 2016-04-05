using UnityEngine;
using UnityEngine.SceneManagement;

// Singleton Game Manager to control global game states
// Each scene implements a scene manager that controls the interface to this class for the scene
// This class exists so that global state access from within each scene is centrally controlled.
public class GameManager : Singleton<GameManager> {

    public bool NoSceneSwitch = false;
    
    public enum Scene {start, prologue, ch1 };

    private static GameManager singleton;
    
    // This prevents other scripts from creating an instance 
    // of the game manager class with "new GameManager()"
    protected GameManager() { }

    public void DebugMessage(string message)
    {
        Debug.Log(message);
    }

    public void SwitchScene(Scene scene)
    {
        if (!NoSceneSwitch)
        {
            SceneManager.LoadScene(scene.ToString());
        }
    }
}
