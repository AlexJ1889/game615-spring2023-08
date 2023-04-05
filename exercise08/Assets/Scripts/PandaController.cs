using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandaController : MonoBehaviour
{
    public GameObject key;

    public CharacterController pandaController;

    bool pickUpKey = false;

    bool haveKey = false;

    public float moveSpeed = 40;
    public float launchForce;

    public bool disableMovement = false;
    [SerializeField] GameObject portalEnd;

    public GameObject finalPhaseCam;
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject bamboo;
    public GameObject launchStart; 

    // Start is called before the first frame update
    void Start()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (disableMovement == false)
        {
            PlayerMovement();
        }
    }

    public void PlayerMovement()
    {
        float hAxis = Input.GetAxis("Horizontal");

        pandaController.Move(transform.forward * moveSpeed * hAxis * Time.deltaTime);
    }

        public void ThrowBambooButton()
    {
        GameObject bambooProj = Instantiate(bamboo, launchStart.transform.position, Quaternion.identity);
        Rigidbody rb = bambooProj.GetComponent<Rigidbody>();
        //branchProj.transform.Translate(rotXAmount, rotYAmount, 0);
        rb.AddForce(bambooProj.transform.forward * launchForce);
        Destroy(bambooProj, .5f);
    }

    public void CollectButton()
    {
        if (pickUpKey == true)
        {
            Destroy(GameObject.FindWithTag("getKey"));
            haveKey = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("getKey"))
        {
            pickUpKey = true;
        }

        if (other.CompareTag("portal") && haveKey == true)
        {
            StartCoroutine(TeleportDelay());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "leopardEnemy1")
        {
            //Destroy(GameObject.FindWithTag("Player"));
            losePanel.SetActive(true);
        }

        if (collision.gameObject.tag == "leopardEnemy2")
        {
            Destroy(GameObject.FindWithTag("Player"));
            losePanel.SetActive(true);
        }
    }

    IEnumerator TeleportDelay()
    {
        disableMovement = true;
        yield return null;
        gameObject.transform.position = portalEnd.transform.position;

        finalPhaseCam.transform.position = new Vector3(272.123962f, 973.724365f, -63.3047752f);
        finalPhaseCam.transform.Rotate(0, 0, 0);

        yield return new WaitForSeconds(2);

        winPanel.SetActive(true);


        //yield return null;
        //disableMovement = false;
    }
}
