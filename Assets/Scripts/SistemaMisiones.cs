using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaMisiones : MonoBehaviour
{
    [SerializeField] private EventManagerSO eventManager;

    [SerializeField] private ToggleMision[] togglesmision; //Coleccion de toggles

    private void OnEnable()
    {
        //me subscribo al evento y lo vinculo con el metodo
        eventManager.OnNuevaMision += EncenderToggleMision;
    }

    private void EncenderToggleMision(MisionSO mision)
    {
       
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
