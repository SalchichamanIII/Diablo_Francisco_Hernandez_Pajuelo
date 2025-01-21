using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SistemaPatrulla patrulla;
    private SistemaCombate combate;

    private Transform target;

    public SistemaCombate Combate { get => combate; set => combate = value; }
    public SistemaPatrulla Patrulla { get => patrulla; set => patrulla = value; }
    public Transform Target { get => target; set => target = value; }

    public void ActivarCombate(Transform target)
    {
        patrulla.enabled = false;  //desactivamos patrulla
        combate.enabled = true;  //Activamos combate
        this.target = target;   //Definimos tarjet

    }

    public void ActivarPatrulla()
    {
        //Deshabilitar combate
       combate.enabled = false;
        //Nos dicen de activar el combate 
        patrulla.enabled = true;
    }

    // Start is called before the first frame update
   private  void Start()
    {
        //Empieza el juego y activamos la patrulla
        patrulla.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
