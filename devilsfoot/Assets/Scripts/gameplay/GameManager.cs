using UnityEngine;
using UnityEngine.SceneManagement;

// Singleton Game Manager to control global game states
// Each scene implements a scene manager that controls the interface to this class for the scene
// This class exists so that global state access from within each scene is centrally controlled.
public class GameManager : Singleton<GameManager> {

    public bool NoSceneSwitch = true;

    public enum Scene {start, prologue, ch1 };

    public static GameManager singleton;

    // This prevents other scripts from creating an instance 
    // of the game manager class with "new GameManager()"
    protected GameManager() { }

    //called before start
    void Awake()
    {

    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //called on a reliable timer for things like physics updates
    void FixedUpdate()
    {

    }

    //called to process GUI actions independent of the game loop
    void OnGUI()
    {

    }

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
