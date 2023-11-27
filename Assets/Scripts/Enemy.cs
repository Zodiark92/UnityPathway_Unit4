using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;

    private GameObject player;
    private Rigidbody enemyBody;

    void Start()
    {
        player = GameObject.Find("Player");
        enemyBody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyBody.AddForce(lookDirection * speed);

        if(transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }
}
