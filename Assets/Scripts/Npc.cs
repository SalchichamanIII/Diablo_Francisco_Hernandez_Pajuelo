using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Npc : MonoBehaviour
{
    [SerializeField] private DialogaSO miDialogo;
    [SerializeField] private float duracionRotacion;
    public void Interactuar(Transform interactuador)
    {
        //Poco a poco voy rotando hacia el interactuador y Cuando termine... se inicia la interaccion
        //
        //Debug.Log("Hola jonash me duele la puchita");
        transform.DOLookAt(interactuador.position, duracionRotacion, AxisConstraint.Y).OnComplete(IniciarInteraccion);
    }
    private void IniciarInteraccion()
    {
        SistemaDialogo.sistema.IniciarDialogo(miDialogo);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
