using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript2 : MonoBehaviour
{
    public NavMeshAgent owlAgent2;

    public Transform player;

    float owl2Health = 14;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        owlAgent2.SetDestination(player.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("inflictDamage"))
        {
            owl2Health = owl2Health - 1;

            if (owl2Health <= 0)
            {
                Destroy(GameObject.FindWithTag("owlEnemy2"));
            }

        }
    }
}
