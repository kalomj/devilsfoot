using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PrologueSceneManager : MonoBehaviour {

    public Text exposition;
    public int textScale = 30;

    List<string> expositionList;

    void Awake()
    {
        expositionList = new List<string>();

    }

    void Start()
    {
        expositionList.Add("The events at the estate sounded ... unnatural...");
        expositionList.Add("My curiosity was piqued.");
        expositionList.Add("I had to embark on a journey to the estate at once.");
        StartCoroutine("UpdateExposition");
    }

    /*void OnGUI()
    {
        exposition.fontSize = Screen.height / textScale;
    }*/

    IEnumerator UpdateExposition()
    {
        for(int i = 0; i < expositionList.Count; i++)
        {
            exposition.text = expositionList[i];
            yield return new WaitForSeconds(2);
        }

        GameManager.Instance.SwitchScene(GameManager.Scene.ch1);

    }
}
