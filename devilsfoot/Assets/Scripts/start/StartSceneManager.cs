using UnityEngine;

public class StartSceneManager : MonoBehaviour {

    public void Start()
    {
        GameManager.Instance.DebugMessage("Game Manager Called by State Scene Manager.");
    }

	public void OnGUI()
    {
        if(Input.anyKeyDown)
        {
            GameManager.Instance.SwitchScene(GameManager.Scene.prologue);
        }
    }
}
