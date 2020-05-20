using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;

    public Animator animator;
    private AudioSource aud;

    private Queue<string> sentences;

    // Use this for initialization
    void Start()
    {
        sentences = new Queue<string>();
        aud = GetComponent<AudioSource>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);
        aud.enabled = true;
        aud.mute = false;
        nameText.text = dialogue.name;

        //Limpa as sentenças anteriores para começar a próxima
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    //Próxima Sentença
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    //Animação para cada letra da sentença
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            aud.Play();
            yield return new WaitForSeconds(0.08f);
        }
    }

    //Fim do Diálogo
    void EndDialogue()
    {
        aud.mute = true;
        animator.SetBool("isOpen", false);
    }

}