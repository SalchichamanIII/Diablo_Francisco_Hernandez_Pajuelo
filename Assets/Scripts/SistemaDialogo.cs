using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SistemaDialogo : MonoBehaviour
{
    [SerializeField] private GameObject marcoDialogo; //Marci habilitar / deshabilitar
    [SerializeField] private TMP_Text textoDialogo; //El texto donde se veran reflejados los dialogos
    [SerializeField] private Transform npcCamera; //Camara compartida por todos los npc
    [SerializeField] AudioSource audioSource;
    [SerializeField] EventManagerSO eventManager;



    //PATRÓN SINGLE-TON
    //1.Solo existe una unica instancia de SistemaDialogo
    //2.Es accesible desde cualquier punto del programa

    private bool escribiendo;
    private int indiceFraseActual = 0;

    private DialogaSO dialogoActual; //Para saber rn todo momento cual es el dialogo con el que estamos trabajando

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

    public void IniciarDialogo(DialogaSO dialogo, Transform cameraPoint)
    {
        Time.timeScale = 0;
        //El dialogo actual que tenemos que tratar es el que me pasan por parametro
        dialogoActual =dialogo;
         marcoDialogo.SetActive(true);

        //Posiciono Y ROTO la vamara en el punto de este npc
        npcCamera.SetPositionAndRotation(cameraPoint.position, cameraPoint.rotation);
        StartCoroutine(EscribirFrase());
    }
    //sirve para escribir frase letra por letara 
    private IEnumerator EscribirFrase()
    {
        escribiendo = true;
        //Limpio el texto
        textoDialogo.text = string.Empty;
        //Desmenuzo la frase actual por caracteres por separado
        char[] fraseEnLetras = dialogoActual.frases[indiceFraseActual].ToCharArray();

        //HAZ LO DEL AUDIO PERRO 


        foreach(char letra in fraseEnLetras)
        {
            //1.Incluir la letra en el texto
            textoDialogo.text += letra; 
            //2,Esperar
            //Wait for seconds realtime no se para si el tiempo no esta congeladoooooo :D
            yield return new WaitForSecondsRealtime(dialogoActual.tiempoEntreLetras); 
        }

        escribiendo = false;
    }
    //Sirve para completar frase
    private void CompletarFrase()
    {
        //Si me piden completar la frase entera, en el texto pongo la frase enetera.
        textoDialogo.text = dialogoActual.frases[indiceFraseActual];
        //Y paro las corrutinas que puedan estar vivas.
        StopAllCoroutines();
        escribiendo = false;
    }
    //Se ejecuta al hacer clixk al boton para pasar a la siguiente frase.
    public void SiguienteFrase()
    {
        //Si no estoy escribiendo
        if (!escribiendo)
        {
            indiceFraseActual++; //Entonces , Avanzo a la siguiente frase
            //Si aun me quedan frases por sacar...
            if (indiceFraseActual < dialogoActual.frases.Length)
            {
                //La escribo 
                StartCoroutine(EscribirFrase());
            }
            else
            {
                FinalizarDialogo();
            }
        }
        else
        {
            CompletarFrase();
        }
        
        
    }
    private void FinalizarDialogo()
    {
        Time.timeScale = 1.0f;  
        marcoDialogo.SetActive(false); //Cerramos el marco de dialogo
        indiceFraseActual = 0; //Para que en posteriores dialogos empecemos desde indice cero
        escribiendo = false ;
        if (dialogoActual.tieneMision)
        {
            eventManager.NuevaMision(dialogoActual.mision);
        }
        dialogoActual = null; //Ya no tengo dialogo que escribir. 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
