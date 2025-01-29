using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetaDeMuerte : MonoBehaviour , IInteractuable
{
    private Outline outline;
    [SerializeField] private MisionSO mision;
    [SerializeField] private EventManagerSO eventManager;

    public void Interactuar()
    {
        mision.repeticionActual++; //Aumentamos en uno la repeticion de esta mision 

        //Todavia quedan setas por recoger 
        if (mision.repeticionActual < mision.totalRepeticiones)
        {
            eventManager.ActualizarMision(mision);
        }
        else //Ya hemos terminado de recoger todas las setas.
        {
            eventManager.TerminarMision(mision);
        }
        
        Destroy(gameObject);
    }

    private void Awake()
    {
        outline = GetComponent<Outline>();  
    }

    private void OnMouseEnter()
    {
        outline.enabled = true;
    }
    
    private void OnMouseExit()
    {
        outline.enabled = false;
    }
}
