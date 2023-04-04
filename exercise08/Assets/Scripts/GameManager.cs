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

    public GameObject chooseTxt;
    public GameObject koalaPanel;
    public GameObject pandaPanel;
    public GameObject cameraObj;
    public GameObject pandaCharacter;
    public GameObject koalaCharacter;
    public GameObject koalaPlatformer;
    public GameObject pandaPlatformer;
    public GameObject platform1;
    public GameObject platform2;
    public GameObject firstPhaseLight;
    public GameObject owlEnemy;

    bool characterSelected; 

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

        characterSelected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (characterSelected == false)
        {
            MenuSelection();
        }
    }

    public void MarsSelectButton()
    {
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
    }

    public void CameraMovement()
    {
            cameraObj.transform.position = new Vector3(302.967773f, 587.84f, -28.8339901f);
            cameraObj.transform.Rotate(8.595f, 91f, 0);
    }

    public void MenuSelection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray) == false)
            {
                if (selectedKoala != null)
                {
                    selectedKoala.selected = false;
                    selectedKoala.koalaRend.material.color = selectedKoala.defaultColor;

                    selectedKoala = null;

                    characterPanelAnimator.SetTrigger("fadeOut");
                    titleAnimator.SetTrigger("title_fadeOut");
                    chooseTxt.SetActive(true);
                }

                if (selectedPanda != null)
                {
                    selectedPanda.selected = false;
                    selectedPanda.pandaRend.material.color = selectedPanda.defaultColor;

                    selectedPanda = null;

                    booCharacterPanelAnimator.SetTrigger("fadeOut");
                    titleAnimator.SetTrigger("title_fadeOut");
                    chooseTxt.SetActive(true);
                }
            }
        }
    }
}
