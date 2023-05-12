using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class magic : MonoBehaviour
{
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

            //destroy the object it collided with
            Destroy(other.gameObject);
            SceneManager.LoadScene("End");
            
            
            
               
               
              
        }

         private void OnTriggerStay(Collider other)
        {
             Destroy(other.gameObject);

        }
}
