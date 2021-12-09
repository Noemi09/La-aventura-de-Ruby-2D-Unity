using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3.0f;
    public bool vertical;
    public float changeTime = 3.0f; //momento antes de cambiar la direcci�n del enemigo
    private bool broken = true;
    
    Rigidbody2D rigidbody2d;

    //necesitas un timer para el movimiento de un lado a otro
    //El enemigo se mueve en una direcci�n (timer = 0), luego cambia de direcci�n y reinicia el timer (asi indefinidamente)
    
    float timer; //mantendr� el valor actual del temporizador
    int direction = 1; //direcci�n actual de tu enemigo (1/-1)

    Animator animator;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        timer = changeTime; //timer tiene el valor del temporizador

        animator = GetComponent<Animator>();

        
    }

    void Update()
    {
        timer -= Time.deltaTime; //disminuyes el temporizador

        if (!broken)
        {
            return;
        }

        if (timer < 0) //si el time es menor que 0 cambias de direcci�n
        {
            direction = -direction;
            timer = changeTime; //reiniciamos el temporizador
        }


        Vector2 position = rigidbody2d.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction; //multiplicas la velocidad por la direcci�n
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", direction);
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
            animator.SetFloat("MoveX", direction);
            animator.SetFloat("MoveY", 0);
        }
        

        rigidbody2d.MovePosition(position);

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    public void Fix()
    {
        broken = false;
        GetComponent<Rigidbody2D>().simulated = false;
    }
}
