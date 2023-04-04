using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript2 : MonoBehaviour
{
    public NavMeshAgent predAgent2;

    public Transform player;

    float enemy2Health = 14;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        predAgent2.SetDestination(player.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("inflictDamage"))
        {
            enemy2Health = enemy2Health - 1;

            if (enemy2Health <= 0)
            {
                Destroy(GameObject.FindWithTag("owlEnemy2"));
                Destroy(GameObject.FindWithTag("leopardEnemy2"));
            }

        }
    }
}
