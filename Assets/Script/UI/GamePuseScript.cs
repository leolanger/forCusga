using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePuseScript : MonoBehaviour
{
    public GameObject pasuePanel;
    public GameObject loadPanel;
    public GameObject savePanel;
    public GameObject settingPanel;
    public int isPause = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause == 0)
            {
                
                Time.timeScale = 0;
                //pasuePanel.GetComponent<CanvasGroup>().alpha = 1;
                //pasuePanel.GetComponent<CanvasGroup>().interactable = true;
                //pasuePanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
                pasuePanel.SetActive(true);
                isPause = 1;
            }
            else if(isPause == 1)
            {
                Time.timeScale = 1f;
                //pasuePanel.GetComponent<CanvasGroup>().alpha = 0;
                //pasuePanel.GetComponent<CanvasGroup>().interactable = false;
                //pasuePanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
                pasuePanel.SetActive(false);
                isPause = 0;
            }
            else if (isPause == 2)
            {
                
                //pasuePanel.GetComponent<CanvasGroup>().alpha = 1;
                //pasuePanel.GetComponent<CanvasGroup>().interactable = true;
                //pasuePanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
                pasuePanel.SetActive(true);
                //loadPanel.GetComponent<CanvasGroup>().alpha = 0;
                //loadPanel.GetComponent<CanvasGroup>().interactable = false;
                //loadPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
                loadPanel.SetActive(false);
                isPause = 1;
            }
            else if (isPause == 3)
            {
                //pasuePanel.GetComponent<CanvasGroup>().alpha = 1;
                //pasuePanel.GetComponent<CanvasGroup>().interactable = true;
                //pasuePanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
                pasuePanel.SetActive(true);
                //loadPanel.GetComponent<CanvasGroup>().alpha = 0;
                //loadPanel.GetComponent<CanvasGroup>().interactable = false;
                //loadPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
                savePanel.SetActive(false);
                isPause = 1;
            }
            else if (isPause == 4)
            {
                //pasuePanel.GetComponent<CanvasGroup>().alpha = 1;
                //pasuePanel.GetComponent<CanvasGroup>().interactable = true;
                //pasuePanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
                pasuePanel.SetActive(true);
                //loadPanel.GetComponent<CanvasGroup>().alpha = 0;
                //loadPanel.GetComponent<CanvasGroup>().interactable = false;
                //loadPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
                settingPanel.SetActive(false);
                isPause = 1;
            }
        }

    }

    public void BackToGameButton()
    {
        
        Time.timeScale = 1f;
        //pasuePanel.GetComponent<CanvasGroup>().alpha = 0;
        //pasuePanel.GetComponent<CanvasGroup>().interactable = false;
        //pasuePanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
        pasuePanel.SetActive(false);
        isPause = 0;
    }

    public void LoadButton()
    {
        
        //pasuePanel.GetComponent<CanvasGroup>().alpha = 0;
        //pasuePanel.GetComponent<CanvasGroup>().interactable = false;
        //pasuePanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
        pasuePanel.SetActive(false);
        //loadPanel.GetComponent<CanvasGroup>().alpha = 1;
        //loadPanel.GetComponent<CanvasGroup>().interactable = true;
        //loadPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
        loadPanel.SetActive(true);
        isPause = 2;
    }

    public void SaveButton()
    {
        //pasuePanel.GetComponent<CanvasGroup>().alpha = 0;
        //pasuePanel.GetComponent<CanvasGroup>().interactable = false;
        //pasuePanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
        pasuePanel.SetActive(false);
        //loadPanel.GetComponent<CanvasGroup>().alpha = 1;
        //loadPanel.GetComponent<CanvasGroup>().interactable = true;
        //loadPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
        savePanel.SetActive(true);
        isPause = 3;
    }

    public void SettingButton()
    {
        //pasuePanel.GetComponent<CanvasGroup>().alpha = 0;
        //pasuePanel.GetComponent<CanvasGroup>().interactable = false;
        //pasuePanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
        pasuePanel.SetActive(false);
        //loadPanel.GetComponent<CanvasGroup>().alpha = 1;
        //loadPanel.GetComponent<CanvasGroup>().interactable = true;
        //loadPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
        settingPanel.SetActive(true);
        isPause = 4;
    }

    public void QuitButton()
    {
        Application.Quit();
    }

}
