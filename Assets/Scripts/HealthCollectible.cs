using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    //no estan las funciones Start y Update porque no queremos que algo suceda al principio del juego o en cada marco o frame

    //unity invoca esta función en el primer marco cuando detecta que un nuevo Rigidbody está entrando en el Trigger.
    //Other es el collider que entro al trigger
    void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("Object that entered the trigger : " + other); //para revisar qué entro al Trigger
    }
}
