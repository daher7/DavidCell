using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiedraScript : MonoBehaviour {

    private EnemigoScript enemigo;
    private bool miPrimeraVez = true;
    [SerializeField] float timeToDestroy = 3.5f;

    private void Start() {
        enemigo = GameObject.Find("Enemigo").GetComponent<EnemigoScript>();
    }

    private void OnCollisionEnter(Collision collision) {
        if (miPrimeraVez) {
            enemigo.SetDistraccion(transform.position);
            miPrimeraVez = false;
            Destroy(gameObject, timeToDestroy);
        }
    }
}
