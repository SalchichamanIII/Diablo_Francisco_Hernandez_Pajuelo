using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Npc : MonoBehaviour , IInteractuable
{
    [SerializeField] private EventManagerSO eventManager;
    [SerializeField] private MisionSO miMision;
    [SerializeField] private DialogaSO miDialogo1;
    [SerializeField] private DialogaSO miDialogo2;
    [SerializeField] private float duracionRotacion;
    [SerializeField] private Transform cameraPoint; //Punto en el que se pondra CAMERANPC

    private DialogaSO dialogoActual;

    private void Awake()
    {
        dialogoActual = miDialogo1;
    }

    private void OnEnable()
    {
        eventManager.OnTerminarMision += CambiarDialogo;
    }

    private void CambiarDialogo(MisionSO misionTerminada)
    {
        if(miMision == misionTerminada)
        {
            dialogoActual = miDialogo2;
        }
    }

    public void Interactuar(Transform interactuador)
    {
        //Poco a poco voy rotando hacia el interactuador y Cuando termine... se inicia la interaccion
        //
        //Debug.Log("Hola jonash me duele la puchita");
        transform.DOLookAt(interactuador.position, duracionRotacion, AxisConstraint.Y).OnComplete(IniciarInteraccion);
    }

    public void Interactuar()
    {
       
    }

    private void IniciarInteraccion()
    {

        SistemaDialogo.sistema.IniciarDialogo(miDialogo1, cameraPoint);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        eventManager.OnTerminarMision -= CambiarDialogo;
    }
}
