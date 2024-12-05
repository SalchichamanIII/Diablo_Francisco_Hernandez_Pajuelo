using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Npc : MonoBehaviour
{
    [SerializeField] private float duracionRotacion;
    public void Interactuar(Transform interactuador)
    {
        Debug.Log("Hola jonash me duele la puchita");
        transform.DOLookAt(interactuador.position, duracionRotacion, AxisConstraint.Y);
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
