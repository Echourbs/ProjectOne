using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    void OnTriggerStay2D(Collider2D c)
    {
        //Quando dentro da Área do Trigger do NPC, ao apertar V abre o diálogo
        if (c.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.V))
        {
            TriggerDialogue();
        }
    }

    public void TriggerDialogue()
    {
        //Inicia o diálogo
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }


}
