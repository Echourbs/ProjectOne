using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentacao : MonoBehaviour
{
    public GameObject prefabFenix;
    private GameObject Fenix;
    public Transform ancoraFenix;

    public GunScript gs;
    public GameObject Player;
    public Transform SensorChao;
    public Transform ancoraArma;

    private bool pular;
    private bool noChao;
    private bool puloDuplo;
    private bool Ataque;
    private bool Rolar = false;

    public float impulso;
    public float velocidade;
    private float mover;

    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator an;

    private GameObject cam;
    public bool isPlaying;
    
    void Start()
    {
        an = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main.gameObject;

        Fenix = Instantiate(prefabFenix, transform.position, transform.rotation);
        isPlaying = true;
    }

    void Update()
    {
        //Fenix.transform.position = Vector2.MoveTowards(Fenix.transform.position, ancoraFenix.transform.position, 7.5f* Time.deltaTime);
        Fenix.transform.position = Vector2.Lerp(Fenix.transform.position, ancoraFenix.transform.position, 4f* Time.deltaTime);

        cam.transform.position = Vector3.Lerp(cam.transform.position, new Vector3(transform.position.x, transform.position.y, cam.transform.position.z), 10f* Time.deltaTime);

        //Input Movimento
        mover = velocidade * Input.GetAxis("Horizontal") * Time.deltaTime;
        transform.Translate(mover *transform.right);

        //Verifica contato com o chao
        noChao = Physics2D.Linecast(transform.position, SensorChao.position, 1 << LayerMask.NameToLayer("floor"));


        //ORIENTAÇÃO
        if (mover > 0.0f)
        {
           Fenix.transform.eulerAngles = transform.eulerAngles = new Vector2(0,0);
            //ancoraArma.eulerAngles = new Vector2(0.0f, 0.0f);
            //sr.flipX = true;
        }
        else if (mover < 0.0f)
        {
          Fenix.transform.eulerAngles = transform.eulerAngles = new Vector2(0, 180);
           //ancoraArma.eulerAngles = new Vector2(0.0f, 180.0f);
           //sr.flipX = false;
        }
   

        //Input para o Pulo
        if (Input.GetButtonDown("Jump"))
        {
            if (noChao)
            {
                rb.AddForce(Vector2.up * impulso);
                an.SetTrigger("PULO");
                puloDuplo = true;
                noChao = false;
            }
            else
            {
                if (puloDuplo)
                {
                    an.SetTrigger("PULO2");
                    puloDuplo = false;
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    rb.AddForce(Vector2.up * impulso);
                }
            }
        }


        //ROLAMENTO
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (mover > 0.0f)
            {
                Rolar = true;
                StartCoroutine(DelayRolamentoDireita());
            }
            if (mover < 0.0f)
            {
                Rolar = true;
                StartCoroutine(DelayRolamentoEsquerda());
                
            }
        }
   


        //ATAQUE
        if (Input.GetButtonDown("Fire1"))
        {
            Ataque = true;
            StartCoroutine(DelayAtaque());
        }
    

            //ANIMAÇÕES
        an.SetBool("RUN", Input.GetAxisRaw ("Horizontal") != 0);
        an.SetBool("ISGROUNDED", noChao);
        an.SetBool("ATTACK", Ataque);
        an.SetBool("ATTACKEFFECT", Ataque);
        an.SetBool("DODGE", Rolar);
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.collider.gameObject.layer == LayerMask.NameToLayer("floor"))
        {
            noChao = true;
            
        }
    }
    void FixedUpdate()
    {

        //Pulo
        if (pular)
        {
            rb.AddForce(Vector2.up * impulso);
            noChao = false;
            an.SetBool("ISGROUNDED", noChao);
            pular = false;
        }
    }

    IEnumerator DelayAtaque()
    {
        yield return new WaitForSeconds(0.3f);
        Ataque = false;
    }

    IEnumerator DelayRolamentoDireita()
    {
        yield return new WaitForSeconds(0.2f);
        transform.Translate(0.8f, 0.0f, 0.0f);
        yield return new WaitForSeconds(0.1f);
        Rolar = false;
    }

    IEnumerator DelayRolamentoEsquerda()
    {
        yield return new WaitForSeconds(0.2f);
        transform.Translate(-0.8f, 0.0f, 0.0f);
        yield return new WaitForSeconds(0.1f);
        Rolar = false;
    }
    



}

