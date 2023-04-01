using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoalaScript : MonoBehaviour
{
    public Renderer koalaRend;

    public Color hoverColor;
    public Color selectedColor;
    public Color defaultColor;

    public bool selected = false;

    GameManager gm; 

    // Start is called before the first frame update
    void Start()
    {
        defaultColor = koalaRend.material.color;

        GameObject gmObj = GameObject.Find("GameManager");
        gm = gmObj.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        if (selected == false)
        {
            koalaRend.material.color = hoverColor;
        }
    }

    private void OnMouseExit()
    {
        if (selected == false)
        {
            koalaRend.material.color = defaultColor;
        }
    }

    private void OnMouseDown()
    {
        if(gm.selectedKoala != null)
        {
            gm.selectedKoala.selected = false;
            gm.selectedKoala.koalaRend.material.color = gm.selectedKoala.defaultColor;
        }

        selected = true;
        koalaRend.material.color = selectedColor;

        if (gm.selectedKoala == null)
        {
            gm.characterPanelAnimator.SetTrigger("fadeIn");
            gm.titleAnimator.SetTrigger("title_fadeIn");
            gm.chooseTxt.SetActive(false);
        }

        gm.selectedKoala = this;
    }
}
