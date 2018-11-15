using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoScript : MonoBehaviour {

    
    [SerializeField] Transform[] puntosPatrulla = new Transform[4];
    NavMeshAgent agente;
    // Tiempo de espera entre asignaciones de puntos de patrulla
    const int TIEMPO_ESPERA = 1; 
    // DECLARACION DE ESTADO
    enum Estado { Idle, Andando, Corriendo, Saltando, Disparando };
    Estado estado = Estado.Idle;

    private void Start() {
        agente = GetComponent<NavMeshAgent>();
        AsignarPuntoPatrulla();
    }

    private void Update() {
        // Evaluacion de los estados
        switch (estado) {
            case Estado.Idle:
                // NO EVALUAMOS NADA
                break;
            case Estado.Andando:
                ComprobarDestino();
                break;
            case Estado.Corriendo:

                break;
            case Estado.Saltando:

                break;
            case Estado.Disparando:

                break;
        }
    }
    
    private void ComprobarDestino() {
        if (!agente.pathPending) {
            if (agente.remainingDistance <= agente.stoppingDistance) {
                // animador.SetBool("andando", false);
                estado = Estado.Idle;
                Invoke("AsignarPuntoPatrulla", TIEMPO_ESPERA);
            }
        }
    }
    // PUNTOS DE PATRULLA ALEATORIOS
    private void AsignarPuntoPatrulla() {
        int pp = Random.Range(0, puntosPatrulla.Length);
        agente.destination = puntosPatrulla[pp].position;
        estado = Estado.Andando;
    }

    // PUNTOS DE PATRULLA SECUENCIAL
    /*
    int pp = 0;
    private void AsignarPuntoPatrulla() {
        if(pp == puntosPatrulla.Length) {
            pp = 0;
        }
        agente.destination = puntosPatrulla[0].position;
        estado = Estado.Andando;
        pp++;
    }
    */
}
