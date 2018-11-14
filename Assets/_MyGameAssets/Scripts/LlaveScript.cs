using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlaveScript : MonoBehaviour {

    public Animator animatorPuerta;
    [SerializeField] GameObject puerta;
    [SerializeField] protected ParticleSystem particulas;

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Player")){
            print("ERES EL PLAYER");
            AbrirPuerta();    
            Destroy(this.gameObject);
        }
    }

    void AbrirPuerta() {
        animatorPuerta.SetBool("AbreteSesamo", true);
        ParticleSystem ps = Instantiate(particulas, transform.position, Quaternion.identity);
        ps.Play();
    }
}
