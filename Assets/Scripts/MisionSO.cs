using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Misión")]
public class MisionSO : ScriptableObject
{
    public string ordenInicial; //Mensaje inicial.
    public string ordenFinal; //Mensaje victoria.
    public bool tieneRepeticion; //(0/15)
    public int totalRepeticiones; //Veces que tengo que repetir ese paso 
    public int indiceMision; //Indice unico que representa cada mision

    [NonSerialized]   public int repeticionActual; // (3/8)... (4/8)
}

