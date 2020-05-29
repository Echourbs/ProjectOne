using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonVoltar : MonoBehaviour
{
    public void VoutarMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }
}
