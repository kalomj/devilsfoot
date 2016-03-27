using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartGameManager : MonoBehaviour {

	public void OnGUI()
    {
        if(Input.anyKeyDown)
        {
            SceneManager.LoadScene(1);
        }
    }
}
