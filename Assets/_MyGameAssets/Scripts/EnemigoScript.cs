using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoScript : MonoBehaviour {

    [SerializeField] Transform playerTransform;
    NavMeshAgent;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = playerTransform.position;
	}
}
