using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PrologueSceneManager : MySceneManager {

    void Awake()
    {
        expositionProp = "prologue";
        expositionPropState = "first_playthrough";
    }

}
