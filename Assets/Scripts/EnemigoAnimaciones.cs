using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoAnimaciones : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private NavMeshAgent agent;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //agent.velocity.magnitude); ---> Velocidad actual
        //agent.speed ---> Maxima velocidad que tengo configurada.
        anim.SetFloat("Velocity", agent.velocity.magnitude / agent.speed);
        // Update is called once per frame
    }
}
