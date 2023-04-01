using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoalaController : MonoBehaviour
{
    public CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        //transform.Rotate(0, 60 * hAxis * Time.deltaTime, 0);

        cc.Move(transform.forward * 20 * vAxis * Time.deltaTime);
    }

   public void ThrowBranchButton()
    {
        Debug.Log("Throw that branch!");
    }

    public void CollectButton()
    {
        Debug.Log("Collect that thing!");
    }
}
