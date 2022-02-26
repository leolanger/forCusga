using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScript : MonoBehaviour
{
    public Transform mainPanel;
    public Transform loadPanel;
    public int currentButton = -1;
    public Button[] saves = new Button[3];
    private Vector3 lastMousPos;

    // Start is called before the first frame update
    void Start()
    {
        lastMousPos = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        if((lastMousPos != Input.mousePosition) && (currentButton != -1))
        {
            EventSystem.current.SetSelectedGameObject(null);
            currentButton = -1;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if(currentButton != -1)
            {
                currentButton = (currentButton + 2) % 3;
            }
            else if(currentButton == -1)
            {
                currentButton = 2;
                saves[currentButton].GetComponent<Button>().Select();
            }
            //saves[currentButton].GetComponent<Button>().Select();
            lastMousPos = Input.mousePosition;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            //saves[currentButton].GetComponent<Button>().Select();
            if (currentButton != -1)
            {
                currentButton = (currentButton + 1) % 3;
            }
            else if (currentButton == -1)
            {
                currentButton = (currentButton + 1) % 3;
                saves[currentButton].GetComponent<Button>().Select();
            }
            //saves[currentButton].GetComponent<Button>().Select();
            lastMousPos = Input.mousePosition;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            if(currentButton != -1)
            {
                saves[currentButton].onClick.Invoke();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackToMainMenu();
        }
    }

    public void LoadSave()
    {
        SceneManager.LoadScene("TempGameSence");
    }

    public void BackToMainMenu()
    {
        mainPanel.GetComponent<CanvasGroup>().alpha = 1;
        mainPanel.GetComponent<CanvasGroup>().interactable = true;
        mainPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
        loadPanel.GetComponent<CanvasGroup>().alpha = 0;
        loadPanel.GetComponent<CanvasGroup>().interactable = false;
        loadPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
        EventSystem.current.SetSelectedGameObject(null);
    }



}
