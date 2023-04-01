using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandaController : MonoBehaviour
{
    public CharacterController pandaController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        pandaController.Move(transform.forward * 20 * vAxis * Time.deltaTime);
    }

    public void ThrowBambooButton()
    {
        Debug.Log("Throw that bamboo!");
    }

    public void CollectButton()
    {
        Debug.Log("Collect that thing!");
    }
}
