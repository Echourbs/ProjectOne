using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    public void TelaControle()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ControlScene");
    }
}
