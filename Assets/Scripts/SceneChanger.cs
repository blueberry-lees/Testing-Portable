using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{


    public string sceneName;
    public void SceneChange()
    {
        //load a scene

        SceneManager.LoadScene(sceneName);
    }



}
