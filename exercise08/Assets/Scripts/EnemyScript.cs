using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public NavMeshAgent owlAgent1;
   
    public GameObject owlEnemy2;

    public Transform player;

    float owl1Health = 10;

    // Start is called before the first frame update
    void Start()
    {
        owlEnemy2.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        owlAgent1.SetDestination(player.position);
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("inflictDamage"))
        {
            owl1Health = owl1Health - 1;

            if (owl1Health <= 0)
            {
                owlEnemy2.SetActive(true);
                Destroy(GameObject.FindWithTag("owlEnemy1"));
            }
        }
    }
}
