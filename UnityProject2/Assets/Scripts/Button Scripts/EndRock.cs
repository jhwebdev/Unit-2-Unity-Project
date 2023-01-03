using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRock : InteractObject
{
    public string scene;
    void Update(){
        if(isClicked()){
            SceneManager.LoadScene(scene);
        }
    }

}
