using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerScript : MonoBehaviour {

    NavMeshAgent agente;
    public Transform targetCircle;
    Animator animador;

    void Start() {
        agente = GetComponent<NavMeshAgent>();
        animador = GetComponent<Animator>();
    }

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            ManageMouseClick();
        }
        if(agente.remainingDistance <= agente.stoppingDistance) {
            animador.SetBool("andando", false);
        }
    }

    private void ManageMouseClick() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rch;
        bool hasTouch = Physics.Raycast(ray, out rch);
        if (hasTouch) {
            targetCircle.transform.position = rch.point;
            targetCircle.transform.rotation = Quaternion.LookRotation(rch.normal);
            agente.destination = targetCircle.transform.position;
            animador.SetBool("andando", true);
        }
    }
}
