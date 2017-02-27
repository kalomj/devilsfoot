using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscMenu : MonoBehaviour {

    public List<GameObject> gameObjects;
    public bool Active;

    void Start()
    {
        foreach (GameObject o in gameObjects)
        {
            setMenuState(Active);
        }
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Active = !Active;
            setMenuState(Active);
        }
	}

    private void setMenuState(bool state)
    {
        foreach(GameObject o in gameObjects)
        {
            o.SetActive(state);
        }
    }

    public void restartSceneButton_Click()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void quitButton_Click()
    {
        SceneManager.LoadScene(0);
    }

    public void quitToDesktopButton_Click()
    {
        Application.Quit();
    }
}
