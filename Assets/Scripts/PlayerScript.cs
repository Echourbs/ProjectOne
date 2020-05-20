using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public bool playing;

    void Update()
    {
        if (playing)
        {
            transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0.0f, 0.0f);
        }
    }

}
