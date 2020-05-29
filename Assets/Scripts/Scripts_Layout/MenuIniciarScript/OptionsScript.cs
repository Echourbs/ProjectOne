using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsScript : MonoBehaviour
{
    //Chama a tela de Options
    public void ChamaOpcoes()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("OptionsScene");
    }
}
