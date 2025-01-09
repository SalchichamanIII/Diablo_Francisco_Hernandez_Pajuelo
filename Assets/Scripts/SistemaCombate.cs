using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaCombate : MonoBehaviour
{
    [SerializeField] private Enemy main;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float velocidadCombate;
    private void Awake()
    {
        main.Combate = this;
        
    }
    //OnEnable se ejecuta cuando se activa el script.
    //Se puede ejecutar varias veces
    private void OnEnable()
    {
        agent.speed = velocidadCombate;
    }
    private void Update()
    {
       
        //Voy a perseguir al main todo el rato rastreando su posicion
        agent.SetDestination(main.Target.position);
    }

}
