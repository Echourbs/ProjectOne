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
    private bool question;
    public bool quest;

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
        quest = false;
        question = false;
    }

    void Update()
    {
        print("Quest: " + quest);
        //Define qual o NPC está falando, para a resposta seja adequada
        if (nameText.text.ToString() == "Rainha da Floresta")
        {
            dt.npcId = 1;
        }
        else{
            dt.npcId = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !question)
        {
            DisplayNextSentence();
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
        if(dt.npcId == 0)
        {
            print("Seu inimigo agora é a Rainha da Floresta, enfrente-a e conquiste o prêmio com a Rainha do Mal");
        }
        if (dt.npcId == 1)
        {
            print("Seu inimigo agora é a Rainha do Mal, enfrente-a e conquiste o prêmio com a Rainha da Floresta");
        }
        quest = true;
        dt.YesAnswer(dt.npcId);
    }
    public void NoSir()
    {
        if (dt.npcId == 1)
        {
            print("Seu inimigo agora é a Rainha da Floresta, enfrente-a e conquiste o prêmio com a Rainha do Mal");
        }
        if (dt.npcId == 0)
        {
            print("Seu inimigo agora é a Rainha do Mal, enfrente-a e conquiste o prêmio com a Rainha da Floresta");
        }
        quest = true;
        dt.NoAnswer(dt.npcId);
    }
    public void Trigger()
    {
        dt.TriggerDialogue();
    }

    //Próxima Sentença
    public void DisplayNextSentence()
    {
        if (sentences.Count == 2)
        {
            question = true;
            skipBt.SetActive(false);
            closeBt.SetActive(true);
            noBt.SetActive(true);
            yesBt.SetActive(true);
        }

        if(sentences.Count == 1)
        {
            finalSentence = true;
            closeBt.SetActive(true);
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
        question = false;
        aud.mute = true;
        playerScript.playing = true;
        animator.SetBool("isOpen", false);

        noBt.SetActive(false);
        yesBt.SetActive(false);
        closeBt.SetActive(false);
        skipBt.SetActive(true);
    }

}