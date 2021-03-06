﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Missile : MonoBehaviour
{
    [SerializeField]
    float missileSpeed;
    [SerializeField]
    Transform player1Transform;

    private NavMeshAgent[] navAgents;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<NavMeshAgent>().speed = missileSpeed;
        player1Transform = GameObject.FindGameObjectWithTag("Player1").transform;

        navAgents = FindObjectsOfType(typeof(NavMeshAgent)) as NavMeshAgent[];
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();

        foreach (NavMeshAgent agent in navAgents)
        {
            agent.destination = player1Transform.position;
        }
    }

    void Rotate()
    {
        // Only update the rotation if the tank has moved
        if (player1Transform.transform.position != Vector3.zero)
        {
            this.transform.LookAt(player1Transform);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.tag + "not coliding");
        // Removes object if colliding tank or another bullet
        if (collision.collider.tag == "Player1" || collision.collider.tag == "Player2" || collision.collider.tag == "bullet" || collision.collider.tag == "tank" || collision.collider.tag == "Wall")
        {
            Debug.Log(collision.collider.tag);
            this.gameObject.SetActive(false);
        }
    }

}
