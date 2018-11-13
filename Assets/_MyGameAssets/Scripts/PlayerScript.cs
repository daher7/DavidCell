using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerScript : MonoBehaviour {

    NavMeshAgent agente;
    public Transform targetCircle;

    void Start() {
        agente = GetComponent<NavMeshAgent>();
    }

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            ManageMouseClick();
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
        }
    }
}
