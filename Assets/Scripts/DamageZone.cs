using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    //no estan las funciones Start y Update porque no queremos que algo suceda al principio del juego o en cada marco o frame

    //unity invoca esta funci�n en el primer marco cuando detecta que un nuevo Rigidbody est� entrando en el Trigger.
    //Other es el collider que entro al trigger
    void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log("Object that entered the trigger : " + other); //para revisar qu� entro al Trigger

        RubyController controller = other.GetComponent<RubyController>(); //da null cuando no puede darte RubyController

        if (controller != null) //null es como nada/vac�o
        {
            controller.ChangeHealth(-1);
        }

    }

}
