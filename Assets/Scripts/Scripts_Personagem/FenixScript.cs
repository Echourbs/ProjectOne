using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenixScript : MonoBehaviour
{
    private float mover;
    public float velocidade;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        //Input Movimento
        mover = velocidade * Input.GetAxis("Horizontal") * Time.deltaTime;
        transform.Translate(mover, 0.0f, 0.0f);

        //ORIENTAÇÃO
        if (mover > 0.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else if (mover < 0.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
    }
}
