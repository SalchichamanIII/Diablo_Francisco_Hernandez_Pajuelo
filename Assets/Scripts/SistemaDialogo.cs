using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaDialogo : MonoBehaviour
{
    //PATRÓN SINGLE-TON
    //1.Solo existe una unica instancia de SistemaDialogo
    //2.Es accesible desde cualquier punto del programa

    public static SistemaDialogo sistema; 

    // Awake se ejecuta ANTES del start() independientemente de que el gameobject este activo o no
    void Awake()
    {
        //Si el trono esta libre..
        if(sistema == null)
        {
            //Me hago con el trono, y entonces SistemaDialogo SOY YO(This)
            sistema = this;
        }
        else
        {
            //Me han quitado el trono , por lo tanto , me mato (soy un falso rey)
            Destroy(this.gameObject);
        }
    }

    public void IniciarDialogo(DialogaSO dialogo)
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
