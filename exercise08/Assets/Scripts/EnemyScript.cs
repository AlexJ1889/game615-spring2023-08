using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public NavMeshAgent predAgent1;
   
    public GameObject Enemy2;

    public Transform player;

    float enemy1Health = 10;

    // Start is called before the first frame update
    void Start()
    {
        Enemy2.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        predAgent1.SetDestination(player.position);
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("inflictDamage"))
        {
            enemy1Health = enemy1Health - 1;

            if (enemy1Health <= 0)
            {
                Enemy2.SetActive(true);
                Destroy(GameObject.FindWithTag("owlEnemy1"));
                Destroy(GameObject.FindWithTag("leopardEnemy1"));
            }
        }
    }
}
