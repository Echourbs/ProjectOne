using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    
    [SerializeField] GameObject exitGame;





    //Chama a tela de new game
    public void ChamaTela()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    



    public void ClickSN(int clicou)
    {
        


        // se cliclou for igual a 1 então é o botão sim e se clicou for igual a 0 então é o botão Não
        if (clicou == 1)
        {
            Application.Quit();
        }
        exitGame.SetActive(false);

    }

}
