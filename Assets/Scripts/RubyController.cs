using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public float speed = 3.0f;

    public int maxHealth = 5;

    public int health { get { return currentHealth; } }    //declaras variables con lo que te de el get
    // con "get" obtienes lo que sea que este en el segundo bloque,
    // el segundo bloque es como una función normal en la que devuelves el valor currentHealth.
    int currentHealth;


    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;


    Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //para usar los ejes
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //como nos vamos a desplazar al pulsar las flechas
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime; //tiempo que toma Unity para reproducir un marco
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);


        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0) //le hacen daño
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
