using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandaScript : MonoBehaviour
{
    public Renderer pandaRend;

    public Color hoverColor;
    public Color selectedColor;
    public Color defaultColor;

    public bool selected = false;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        defaultColor = pandaRend.material.color;

        GameObject gameObj = GameObject.Find("GameManager");
        gameManager = gameObj.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseEnter()
    {
        if (selected == false)
        {
            pandaRend.material.color = hoverColor;
        }
    }

    private void OnMouseExit()
    {
        if (selected == false)
        {
            pandaRend.material.color = defaultColor;
        }
    }

    private void OnMouseDown()
    {
        if (gameManager.selectedPanda != null)
        {
            gameManager.selectedPanda.selected = false;
            gameManager.selectedPanda.pandaRend.material.color = gameManager.selectedPanda.defaultColor;
        }

        selected = true;
        pandaRend.material.color = selectedColor;

        if (gameManager.selectedPanda == null)
        {
            gameManager.booCharacterPanelAnimator.SetTrigger("boo_fadeIn");
            gameManager.titleAnimator.SetTrigger("title_fadeIn");
            gameManager.chooseTxt.SetActive(false);
        }
    }
}