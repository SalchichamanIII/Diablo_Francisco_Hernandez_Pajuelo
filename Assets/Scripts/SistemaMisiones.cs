using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaMisiones : MonoBehaviour
{
    [SerializeField] private EventManagerSO eventManager;

    [SerializeField] private ToggleMision[] togglesMision; //Coleccion de toggles

    private void OnEnable()
    {
        //me subscribo al evento y lo vinculo con el metodo
        eventManager.OnNuevaMision += EncenderToggleMision;
        eventManager.OnTerminarMision += TerminarToggleMision;
        eventManager.OnActualizarMision += ActualizarToggleMision;
    }

    private void ActualizarToggleMision(MisionSO mision)
    {
        togglesMision[mision.indiceMision].TextoMision.text = mision.ordenInicial;
        togglesMision[mision.indiceMision].TextoMision.text += "(" + mision.repeticionActual + "/" + mision.totalRepeticiones + ")";
    }

    private void TerminarToggleMision(MisionSO mision)
    {
        togglesMision[mision.indiceMision].ToggleVisual.isOn = true;//Al terminar la mision "chekeamos"el toggle
        togglesMision[mision.indiceMision].TextoMision.text = mision.ordenFinal;//Ponemos el texto de la victoria.
    }

    private void EncenderToggleMision(MisionSO mision)
    {
        togglesMision[mision.indiceMision].TextoMision.text = mision.ordenInicial;

        if (mision.tieneRepeticion)
        {
            togglesMision[mision.indiceMision].TextoMision.text += "(" + mision.repeticionActual + "/" + mision.totalRepeticiones + ")";
        }
        togglesMision[mision.indiceMision].gameObject.SetActive(true); //Enciendo el toggle para que se vea en pantalaa
    }

   
}
