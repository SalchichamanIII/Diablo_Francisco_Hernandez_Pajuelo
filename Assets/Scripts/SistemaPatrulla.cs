//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaPatrulla : MonoBehaviour
{
    [SerializeField] private Transform ruta;

    [SerializeField] private NavMeshAgent agent;

    private List<Vector3> listadoPuntos = new List<Vector3>();

    private int indiceDestinoActual = 0; //Marca el punto al cual debo ir.

    private Vector3 destinoActual; //Marca el destino al que tengo que ir 

    //Diferencia con Array:
    //private Transform[] array = new Transform[50];
    // Start is called before the first frame update

    private void Awake()//Funciona antes del start
    {
       
        foreach (Transform punto in ruta)
        {
            //Añado todos los puntos de ruta al listado
            listadoPuntos.Add(punto.position);
        }
    }
    void Start()
    {
        StartCoroutine(PatrullarYEsperar());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator PatrullarYEsperar()
    {
        //Por siempre
        while (true)
        {
            CalcularDestino(); //Tendre que calcular mi nuevo destino
            agent.SetDestination(destinoActual);
            yield return new WaitUntil(()=> agent.remainingDistance <=0); //Expresion lambda
            yield return new WaitForSeconds(Random.Range(0.25f, 3f));
            //Ir a destino.
        }
    }
    //Esto es lo mismo que lo de arriba (()=> agent.remainingDistance <=0)
    //private bool CalcularDistanciaRestante()
    //{
    //    if(agent.remainingDistance <= 0)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    private void CalcularDestino()
    {
        indiceDestinoActual++;
        //Si nos hemos quedado sin puntos ...
        if (indiceDestinoActual >= listadoPuntos.Count)
        {
            indiceDestinoActual = 0;   
        }
        //Mi destino es dentro del listado de puntos aquel con el nuevo índice calculado.
        destinoActual = listadoPuntos[indiceDestinoActual];
    }
}
