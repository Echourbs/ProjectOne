using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_IA : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    float range;

    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb;

    float Andarmin;

    float Andarmax;

    int Direcao = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Andarmax = transform.position.x + 10;
        Andarmin = transform.position.x - 10;
    }


    void Update()
    {
        float distanciaPlayer = Vector2.Distance(transform.position, player.position);

        if(distanciaPlayer < range)
        {
            SeguirJogador();
        }
        else
        {
            PararJogador();
        }

        transform.Translate(Direcao * Time.deltaTime * 3f, 0, 0);

        if((transform.position.x > Andarmax && Direcao ==1 || transform.position.x < Andarmin && Direcao == -1))
        {
            Direcao *= -1;
        }
    }

    void SeguirJogador()
    {
       if(transform.position.x < player.position.x)
       {
            //inimigo vai para esquerda atras do jogador, caso ele esteje na direita
            rb.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(-1, 1);
        }
       else 
       {
            //inimigo vai para direita atras do jogador, caso ele esteje na esquerda
            rb.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(1, 1);
            
       }
    }

    void PararJogador()
    {
        rb.velocity = new Vector2(0, 0);
    }


}


