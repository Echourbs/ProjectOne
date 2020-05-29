using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMenuScript : MonoBehaviour
{
 

    // Update is called once per frame
    void FixedUpdate()
    {
        //ABRIR HUD ARMAS
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("Tab key was pressed.");
        }

       else if (Input.GetKeyUp(KeyCode.Tab))
        {
            Debug.Log("Tab was released.");
        }
    }
}
