using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoalaController : MonoBehaviour
{
    public CharacterController cc;
    GameManager gm;

    public Animator koalaAnimator;

    public GameObject key;
    public GameObject branches;
    public GameObject launchPos;
    public GameObject finalPhaseCam;
    public GameObject winPanel;
    public GameObject losePanel;

    public float launchForce;

    public float moveSpeed = 40;

    bool pickUpKey = false;

    bool haveKey = false;

    public bool disableMovement = false; 
    [SerializeField] GameObject portalEnd; 

    //float rotXAmount; 
    //float rotYAmount; 

    // Start is called before the first frame update
    void Start()
    {
        gm = GetComponent<GameManager>();

        //GameObject leafObj = Instantiate(leaf, leaf.transform.position, Quaternion.identity);
        //leaf.transform.position = new Vector3 (-120.300003f,73.5999985f,66.6900024f);

        GameObject keyObj = Instantiate(key, key.transform.position, Quaternion.identity);
        key.transform.position = new Vector3(-13.1999998f, 507.600006f, -29.3999996f);

        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {

        //if (hAxis > 0)
        //{
        //    koalaAnimator.SetBool("isWalking", true);
        //}
        //else
        //{
        //    koalaAnimator.SetBool("isWalking", false);
        //}

        //if(hAxis < 0)
        //{
        //    koalaAnimator.SetBool("walkingLeft", true);
        //}
        //else
        //{
        //    koalaAnimator.SetBool("walkingLeft", false);
        //}

       
    }

    private void FixedUpdate()
    {
        if (disableMovement == false)
        {
            PlayerMovement();
        }
    }

    public void PlayerMovement()
    {
        float hAxis = Input.GetAxis("Horizontal");

        cc.Move(transform.forward * moveSpeed * hAxis * Time.deltaTime);

        if (Mathf.Abs(hAxis) > 0)
        {
            koalaAnimator.SetBool("isWalking", true);
        }
        else
        {
            koalaAnimator.SetBool("isWalking", false);
        }
    }

   public void ThrowBranchButton()
    {
        GameObject branchProj = Instantiate(branches, launchPos.transform.position, Quaternion.identity);
        Rigidbody rb = branchProj.GetComponent<Rigidbody>();
        //branchProj.transform.Translate(rotXAmount, rotYAmount, 0);
        rb.AddForce(branchProj.transform.forward * launchForce);
        Destroy(branchProj, .5f);
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
        if(collision.gameObject.tag == "owlEnemy1")
        {
            Destroy(GameObject.FindWithTag("Player"));
            losePanel.SetActive(true);
        }

        if (collision.gameObject.tag == "owlEnemy2")
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

