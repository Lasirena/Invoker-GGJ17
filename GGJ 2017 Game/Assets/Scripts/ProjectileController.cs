using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileController : MonoBehaviour
{

    public float damage = 10;
    public float speed = 2.5f;

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    void OnCollisionEnter()
    {
        Destroy(this.gameObject);
    }
}