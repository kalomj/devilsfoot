using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Text))]
public class PrologueGameManager : MonoBehaviour {

    public Text exposition;

    List<string> expositionList;


	void Start()
    {
        expositionList = new List<string>();
        expositionList.Add("The events at the estate sounded ... unnatural...");
        expositionList.Add("My curiosity was piqued.");
        expositionList.Add("I had to embark on a journey to the estate at once.");
        StartCoroutine("UpdateExposition");
    }

    IEnumerator UpdateExposition()
    {
        for(int i = 0; i < expositionList.Count; i++)
        {
            exposition.text = expositionList[i];
            yield return new WaitForSeconds(2);
        }

        SceneManager.LoadScene(2);

    }
}
