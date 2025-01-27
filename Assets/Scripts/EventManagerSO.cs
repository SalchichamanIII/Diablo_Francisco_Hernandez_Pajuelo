using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "EventManager")]
public class EventManagerSO : ScriptableObject
{
    //Creo un evento
    public event Action<MisionSO> OnNuevaMision;
    public void NuevaMision(MisionSO mision)
    {
        //Lanzar/disparar el evento/notificacion

        // ?. -> invocacion SeGURa
        OnNuevaMision?.Invoke(mision);
    }

    
}
