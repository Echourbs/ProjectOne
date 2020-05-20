using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Invoke("TriggerDialogue", 0.5f);
        }
    }

    void OnTriggerStay2D(Collider2D c)
    {
        if (c.gameObject.name == "Player" && Input.GetKeyDown(KeyCode.V))
        {
            TriggerDialogue();
            print("pipi");
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }


}
