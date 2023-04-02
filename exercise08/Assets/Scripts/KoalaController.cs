using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoalaController : MonoBehaviour
{
    public CharacterController cc;

    public GameObject leaf;
    public GameObject key; 

    bool leafPile = false;
    bool haveKey = false;
    bool buttonPressed = false; 

    // Start is called before the first frame update
    void Start()
    {
        //GameObject leafObj = Instantiate(leaf, leaf.transform.position, Quaternion.identity);
        //leaf.transform.position = new Vector3(104.199997f, 121.260002f, 66.6900024f);
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        //transform.Rotate(0, 60 * hAxis * Time.deltaTime, 0);

        cc.Move(transform.forward * 20 * hAxis * Time.deltaTime);
    }

   public void ThrowBranchButton()
    {
        Debug.Log("Throw that branch!");
    }

    public void CollectButton()
    {
        buttonPressed = true;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("collectMe") && buttonPressed == true)
        {
            leafPile = true;
 
        }
    }
}

