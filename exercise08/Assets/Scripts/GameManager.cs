using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public KoalaScript selectedKoala;
    public PandaScript selectedPanda;
    public EnemyScript enemyS;

    public Animator characterPanelAnimator;
    public Animator booCharacterPanelAnimator; 
    public Animator titleAnimator;
    public Animator marsAnimator;
    public Animator booAnimator;

    public GameObject chooseTxt;
    public GameObject koalaPanel;
    public GameObject pandaPanel;
    public GameObject booPanel;
    public GameObject cameraObj;
    public GameObject pandaCharacter;
    public GameObject koalaCharacter;
    public GameObject koalaPlatformer;
    public GameObject pandaPlatformer;
    public GameObject platform1;
    public GameObject platform2;
    public GameObject firstPhaseLight;
    public GameObject owlEnemy;
    public GameObject leopardEnemy;
    

    bool characterSelected;
    
    public GameObject leafFloor;
    public int leavesPerLoop;
    public float spawnDelay = 1f;

    private GameObject[] clones;
    private bool shouldStopLoop = false; 

    // Start is called before the first frame update
    void Start()
    { 

        chooseTxt.SetActive(true);
        cameraObj.transform.position = new Vector3 (-1.11814857f, 18.9626865f, 227.366669f);

        pandaCharacter.SetActive(true);
        koalaCharacter.SetActive(true);

        pandaPlatformer.SetActive(false);
        koalaPlatformer.SetActive(false);

        platform1.SetActive(false);
        platform2.SetActive(false);

        koalaPanel.SetActive(false);
        pandaPanel.SetActive(false);

        firstPhaseLight.SetActive(false);
        
        owlEnemy.SetActive(false);
        leopardEnemy.SetActive(false);

        characterSelected = false;
        booPanel.SetActive(true);

        clones = new GameObject[leavesPerLoop];
        StartCoroutine(CreateClones());

    }

    // Update is called once per frame
    void Update()
    { 
        if (characterSelected == false)
        {
            MenuSelection();
        }

        

    }

    private IEnumerator CreateClones()
    {
        for (int i=0; i < leavesPerLoop; i++)
        {
            float leafFloorX = Random.Range(258.3f, -233.3f);
            float leafFloorY = 0;
            float leafFloorZ = Random.Range(208.7f, -291f);
            float rotXAmount = Random.Range(0, 360);
            float rotYAmount = 0;
            float rotZAmount = Random.Range(0, 360);
            clones[i] = Instantiate(leafFloor, transform.position, Quaternion.identity);
            transform.position = new Vector3(leafFloorX, leafFloorY, leafFloorZ);
            clones[i].transform.Rotate(rotXAmount, rotYAmount, rotZAmount);

            yield return null;

            if (shouldStopLoop)
            {
                break;
            }
        }
    }

    private void DestroyClones()
    {
        for (int i=0; i < clones.Length; i++)
        {
            Destroy(clones[i]);
        }
    }

    public void MenuSelection()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray) == false)
            {
                if (selectedPanda != null)
                {
                    selectedPanda.selected = false;
                    selectedPanda.pandaRend.material.color = selectedPanda.defaultColor;

                    selectedPanda = null;
                    booAnimator.SetBool("selected", false);

                    booCharacterPanelAnimator.SetTrigger("fadeOut");
                    titleAnimator.SetTrigger("title_fadeOut");
                    chooseTxt.SetActive(true);
                }

                if (selectedKoala != null)
                {
                    selectedKoala.selected = false;
                    selectedKoala.koalaRend.material.color = selectedKoala.defaultColor;

                    selectedKoala = null;
                    marsAnimator.SetBool("isSelected", false);

                    characterPanelAnimator.SetTrigger("fadeOut");
                    titleAnimator.SetTrigger("title_fadeOut");
                    chooseTxt.SetActive(true);

                }

            }
        }
    }

    public void MarsSelectButton()
    {
        booPanel.SetActive(false);

        CameraMovement();

        characterPanelAnimator.SetTrigger("fadeOut");

        koalaCharacter.SetActive(false);
        pandaCharacter.SetActive(false);

        koalaPlatformer.SetActive(true);

        platform1.SetActive(true);
        platform2.SetActive(true);

        koalaPanel.SetActive(true);

        characterSelected = true;

        firstPhaseLight.SetActive(true);
        owlEnemy.SetActive(true);

        shouldStopLoop = true;
        DestroyClones();
        RenderSettings.fog = false;
    }

    public void BooSelectButton()
    {
        CameraMovement();

        booCharacterPanelAnimator.SetTrigger("fadeOut");

        koalaCharacter.SetActive(false);
        pandaCharacter.SetActive(false);

        pandaPlatformer.SetActive(true);

        platform1.SetActive(true);
        platform2.SetActive(true);

        pandaPanel.SetActive(true);

        characterSelected = true;

        firstPhaseLight.SetActive(true);
        leopardEnemy.SetActive(true);

        shouldStopLoop = true;
        DestroyClones();
        RenderSettings.fog = false;
    }

    public void CameraMovement()
    {
            cameraObj.transform.position = new Vector3(302.967773f, 587.84f, -28.8339901f);
            cameraObj.transform.Rotate(8.595f, 91f, 0);
    }
  
}
