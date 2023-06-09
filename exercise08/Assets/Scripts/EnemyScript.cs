using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public NavMeshAgent predAgent1;

    public Animator enemyAnim; 

    public Transform player;
    public Vector3 respawnSpot; 

    public int maxHealth = 10;
    public int maxRespawns;
    public int currentRespawns = 0;

    private int currentHealth;

    private GameObject playerRef;

    // Start is called before the first frame update
    void Start()
    {
        //Enemy2.SetActive(false);

        predAgent1 = GetComponent<NavMeshAgent>();
        playerRef = GameObject.FindGameObjectWithTag("Player");

        currentHealth = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerRef != null)
        {
            predAgent1.SetDestination(player.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("inflictDamage"))
        {
            currentHealth = currentHealth - 1;

            if (currentHealth <= 0)
            {
                if (currentRespawns < maxRespawns)
                {
                    Respawn();
                }

                else
                {
                    Destroy(GameObject.FindWithTag("owlEnemy1"));
                    Destroy(GameObject.FindWithTag("leopardEnemy1"));
                }
                
            }
        }
    }

    void Respawn()
    {
        currentHealth = maxHealth;
        currentRespawns++;
        transform.position = respawnSpot;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            playerRef = null;
        }
    }

    //void StopEnemyMovement()
    //{
    //    predAgent1.isStopped = true;
    //}

    //Enemy2.SetActive(true);

    //Destroy(GameObject.FindWithTag("owlEnemy1"));
    //Destroy(GameObject.FindWithTag("leopardEnemy1"));

    //enemyAnim.SetBool("noHealth", true);
    //        gameObject.transform.position = respawnSpot.transform.position;
    //        enemy1Health = 12;

    //        yield return new WaitForSeconds(2);

    //        respawn = true;



}
