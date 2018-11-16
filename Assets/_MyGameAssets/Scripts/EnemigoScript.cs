using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemigoScript : MonoBehaviour {

    public Text textDTP, textATP, textAtiro;
    public GameObject player;
    [SerializeField] Transform[] puntosPatrulla = new Transform[4];
    NavMeshAgent agente;
    // Tiempo de espera entre asignaciones de puntos de patrulla
    const int TIEMPO_ESPERA = 1;
    float anguloVision = 25;
    float distanciaVision = 7;
    // DECLARACION DE ESTADO
    enum Estado { Idle, Andando, Corriendo, Saltando, Disparando, Siguiendo, Distraido };
    Estado estado = Estado.Idle;

    private void Start() {
        agente = GetComponent<NavMeshAgent>();
        AsignarPuntoPatrulla();
    }

    private void Update() {
        if(estado != Estado.Distraido) {
            VerificarObjetivo();
        }
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
            case Estado.Siguiendo:
                agente.destination = player.transform.position;
                break;
            case Estado.Distraido:
                ComprobarDestino();
                break;
        }
    }

    private void VerificarObjetivo() {
        float distanciaAlplayer = Vector3.Distance(transform.position, player.transform.position);
        Vector3 direccion = Vector3.Normalize(player.transform.position - transform.position);
        float anguloAlPlayer = Vector3.Angle(direccion, transform.forward);
        // Vamos a comprobar si ve al player
        if (distanciaAlplayer < distanciaVision && anguloAlPlayer < anguloVision) {
            // Lanzamos un raycast para ver si hay no hay ningun obstaculo en la linea de vision
            Debug.DrawLine(transform.position, player.transform.position, Color.red, 1);
            RaycastHit rh;
            if (Physics.Raycast(
                transform.position,
                direccion,
                out rh,
                Mathf.Infinity)) {
                if (rh.transform.gameObject.name == "Player") {
                    textAtiro.text = "A tiro: SI";
                    estado = Estado.Siguiendo;
                } else {
                    textAtiro.text = "A tiro: NO";
                }
            }
        } else {
            textAtiro.text = "A tiro: NO";
        }
        
        textDTP.text = "DTP: " + distanciaAlplayer.ToString();
        textATP.text = "ATP: " + anguloAlPlayer.ToString();
    }

    private void ComprobarDestino() {
        if (!agente.pathPending) {
            if (agente.remainingDistance <= agente.stoppingDistance + 0.1) {
                // animador.SetBool("andando", false);
                estado = Estado.Idle;
                //transform.Rotate(0, 180, 0);
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

    public void SetDistraccion(Vector3 position) {
        agente.destination = position;
        estado = Estado.Distraido;
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
