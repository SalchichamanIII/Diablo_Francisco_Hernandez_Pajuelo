using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMinimapa : MonoBehaviour
{
    [SerializeField] private Player player;

    private Vector3 DistanciaAPlayer;
    // Start is called before the first frame update
    void Start()
    {
        //Calculo la distancia que hay entre el player y yo (camar)
        DistanciaAPlayer = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Me posiciono en el player, respetando dicha distancia
        transform.position = player.transform.position + DistanciaAPlayer;
    }
}
