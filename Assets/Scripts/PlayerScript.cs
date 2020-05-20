using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0.0f, 0.0f);
    }

    //void OnTriggerStay2D(Collider2D c)
    //{
    //   if (c.gameObject.name == "NPC1" && Input.GetKeyDown(KeyCode.Y))
    //    {
    //        FindObjectOfType<DialogueTrigger>().TriggerDialogue();
    //    }
    //}
}
