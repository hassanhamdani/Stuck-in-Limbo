using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class house : MonoBehaviour
{

    //get game manager
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
        {

            gameManager.ElleninHouse = true;
            
            
               
               
              
        }

         private void OnTriggerStay(Collider other)
        {
            gameManager.ElleninHouse = true;
        }

        private void OnTriggerExit(Collider other)
        {
            gameManager.ElleninHouse = false;
        }
}
