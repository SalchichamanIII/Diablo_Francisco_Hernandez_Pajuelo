using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaCombate : MonoBehaviour
{

    [SerializeField] private Enemy main;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float velocidadCombate;
    [SerializeField] private float distanciaAtaque;
    [SerializeField] private float danhoAtaque;
    [SerializeField] private Animator anim;
    private void Awake()
    {
        main.Combate = this;
        
    }
    //OnEnable se ejecuta cuando se activa el script.
    //Se puede ejecutar varias veces
    private void OnEnable()
    {
        agent.speed = velocidadCombate;
        agent.stoppingDistance = distanciaAtaque;
    }
    private void Update()
    {
        //Solo si exiate un objetivo
       if(main.Target != null && agent.CalculatePath(main.Target.position, new NavMeshPath()))
        {
            //Procuraremos que SIEMPRE estemos enfocando al player 
            EnfocarObjetivo();
            //Voy a perseguir al main todo el rato rastreando su posicion
            agent.SetDestination(main.Target.position);

            //Cuando tenga al objetivo a distancia de ataque...
            if(!agent.pathPending && agent.remainingDistance <= distanciaAtaque)
            {
               
                anim.SetBool("attacking",true);
                //Atacar
            }
        }
        else
        {
            ////Desabilitamos script de combate 
            //enabled = false;
            main.ActivarPatrulla();
        }
        
    }

    private void EnfocarObjetivo()
    {
        //!. Calculo la direccion al objetivo 
       Vector3 direccionAtarget = (main.Target.transform.position - transform.position).normalized;
        direccionAtarget.y = 0f;//Pongo la y a 0 para que no se vuelque

        //Transformo una direccion en una rotacion
        Quaternion rotacionATarget = Quaternion.LookRotation(direccionAtarget);

        //Aplico la rotacion
        transform.rotation = rotacionATarget;
    }

    #region Ejecutados por evento de animacion
    private void atacar()
    {
        //Hacer danho al target.
        main.Target.GetComponent<Player>().HacerDanho(danhoAtaque);
    }

    private void FinAnimacionAtaque()
    {
        anim.SetBool("attacking", false);
    }
    #endregion
}
