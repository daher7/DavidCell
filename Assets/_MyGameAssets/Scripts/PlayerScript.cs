using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerScript : MonoBehaviour {

    // Declaracion de los estdos del player
    enum Estado { Idle, Andando, Corriendo, Saltando, Disparando };
    Estado estado = Estado.Idle;

    NavMeshAgent agente;
    public Transform targetCircle;
    Animator animador;
    public LayerMask walkableLayer;
    // DISTRACCION AL ENEMIGO
    [SerializeField] GameObject prefabPiedra;
    [SerializeField] Transform ptoGeneracionPiedra;
    [SerializeField] int fuerzaPiedra = 100;
 
    void Start() {
        agente = GetComponent<NavMeshAgent>();
        animador = GetComponent<Animator>();
    }

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            ManageMouseClick();
        }
        if (Input.GetKeyDown(KeyCode.V)) {
            print("Has pulsado la v");
            LanzarPiedra();
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
        }
    }

    private void LanzarPiedra() {
        GameObject piedra = Instantiate(prefabPiedra, ptoGeneracionPiedra.position, ptoGeneracionPiedra.rotation);
        piedra.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * fuerzaPiedra);
    }

    private void ComprobarDestino() {
        if (!agente.pathPending) {
            if (agente.remainingDistance <= agente.stoppingDistance) {
                animador.SetBool("andando", false);
                estado = Estado.Idle;
            }
        }
    }

    private void ManageMouseClick() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rch;
        // Vamos a limitar que se muestre el CirculoHud solo en aquellos objetos que tengan
        // la capa walkable
        bool hasTouch = Physics.Raycast(ray, out rch, Mathf.Infinity, walkableLayer);
        if (hasTouch) {
            switch (estado) {
                case Estado.Idle:
                    Andar(rch);
                    break;
                case Estado.Andando:

                    break;
                case Estado.Corriendo:

                    break;
                case Estado.Saltando:

                    break;
                case Estado.Disparando:

                    break;
            }

        }
    }

    private void Andar(RaycastHit rch) {
        targetCircle.transform.position = rch.point;
        targetCircle.transform.rotation = Quaternion.LookRotation(rch.normal);
        agente.destination = targetCircle.transform.position;
        animador.SetBool("andando", true);
        estado = Estado.Andando;
    }
}
