using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
     
    
    //Chama a tela de Load
    public void ChamaLoad()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LoadScene");
    }

}
