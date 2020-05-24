using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public GameObject yesBt, noBt, skipBt, closeBt;

    public Animator animator;
    private AudioSource aud;

    private Queue<string> sentences;

    private DialogueTrigger dt;
    private GameObject player;
    private PlayerScript playerScript;
    private bool finalSentence;

    // Use this for initialization
    void Start()
    {
        finalSentence = false;
        sentences = new Queue<string>();
        aud = GetComponent<AudioSource>();
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerScript>();
        dt = FindObjectOfType<DialogueTrigger>();
        playerScript.playing = true;
        dt.quest = false;
    }

    void Update()
    {
        if (nameText.text.ToString() == "Rainha da Floresta")
        {
            dt.npcId = 1;
        }
        else{
            dt.npcId = 0;
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if (!finalSentence)
        {
            animator.SetBool("isOpen", true);
        }

        aud.enabled = true;
        aud.mute = false;
        playerScript.playing = false;
        nameText.text = dialogue.name;

        //Limpa as sentenças anteriores para começar a próxima
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        if (!dt.quest)
        {
            Invoke("DisplayNextSentence", 0.3f);
        }
        else
        {
            Invoke("CloseSentence", 0.3f);
        }
    }

    //Funções para botões
    public void YesSir()
    {
        dt.YesAnswer(dt.npcId);
    }
    public void NoSir()
    {
        dt.NoAnswer(dt.npcId);
    }
    public void Trigger()
    {
        dt.TriggerDialogue();
    }

    //Próxima Sentença
    public void DisplayNextSentence()
    {
        print(dt.npcId);
        if (sentences.Count == 2)
        {
            skipBt.SetActive(false);
            noBt.SetActive(true);
            yesBt.SetActive(true);
        }

        if(sentences.Count == 1)
        {
            finalSentence = true;
            skipBt.SetActive(true);
            noBt.SetActive(false);
            yesBt.SetActive(false);
        }
       
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    //Proxima sentença quando ja foi respondido
    public void CloseSentence()
    {
        if(sentences.Count == 4)
        {
            closeBt.SetActive(true);
            noBt.SetActive(false);
            yesBt.SetActive(false);
        }
        if (sentences.Count == 3)
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
    public void EndDialogue()
    {
        aud.mute = true;
        playerScript.playing = true;
        animator.SetBool("isOpen", false);
        dt.quest = true;
        closeBt.SetActive(false);
        skipBt.SetActive(true);
    }

}