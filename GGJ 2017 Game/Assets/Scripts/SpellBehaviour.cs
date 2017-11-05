using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBehaviour : MonoBehaviour {

    public float speed;

    private Rigidbody body;
    private string colour;
    

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
        colour = gameObject.tag;
	}
	
	// Update is called once per frame
	void Update () {
        body.velocity = transform.forward * speed;
	}
}
