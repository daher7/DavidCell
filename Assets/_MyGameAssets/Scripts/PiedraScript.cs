using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiedraScript : MonoBehaviour {
   
    public EnemigoScript enemigo;
   
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            LlamarEnemigo();
            Destroy(this.gameObject);
        }
    }

    void LlamarEnemigo() {
        enemigo.SetTarget(transform.position);
    }
}
