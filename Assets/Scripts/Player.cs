using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private Camera cam;
    private NavMeshAgent agent;

    //almaceno ultimo transform que clicke con el raton
    private Transform ultimoClick;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
       agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();// ctrl r m hacer metodo
        ComprobarInreraccion(); //Alt enter generar metodo

    }

    private void ComprobarInreraccion()
    {
        //Si existe un interactuable al cual clicke y lleva el script Npc ..
       if(ultimoClick != null && ultimoClick.TryGetComponent(out Npc npc))
        {
            //Actualizo la distancia de pearada para no comerme al npc
            agent.stoppingDistance = 2f;

            //Mira a ver si hemos llegado a dicho destino 
            if(agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                //Y por lo tanto, interactuo con el npc 
                npc.Interactuar(this.transform);

                //Me olvido cuando fue el ultimo click, pq solo quiero interactuar una vez
                ultimoClick = null;
            }
        }
       //Si no es un npc, si no que es un clk en el suelinchi
       else if (ultimoClick)
        {
            //Reseteo el sttopingDistance original.
            agent.stoppingDistance = 0f;
        }
    }

    private void Movimiento()
    {
        //Si clico con el mouse izq 
        if (Input.GetMouseButtonDown(0))
        {
            //Creo un rayo desde la camara a la posicion del raton
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            //Y si ese rayo impacta en algo
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                //Le decimos al agente (nosostros) que tiene como destino el punto de impacto
                agent.SetDestination(hitInfo.point);

                //Actualizo el ultimoHit con el transform que acabo de clickar
                ultimoClick = hitInfo.transform;
            }
        }
    }
}
