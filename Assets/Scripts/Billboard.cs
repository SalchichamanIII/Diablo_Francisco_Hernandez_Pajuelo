using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        //cam es la camara con la etiqueta Maincamera
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Mi frontal es el frontal de la camara en sentido contrario
        transform.forward = - cam.transform.forward;
    }
}
