using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetornarMenu : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    //chama a tela de menu
    public void VoltarMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }

}
