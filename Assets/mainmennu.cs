using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmennu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame(){
        SceneManager.LoadScene("mainGame");
    }

    public void quitGame(){
        Debug.Log("quitGame");
        Application.Quit();
    }
}
