using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public string winScene; 
    
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(winScene);
        }
    }
}
