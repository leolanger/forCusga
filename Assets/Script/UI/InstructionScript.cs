using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InstructionScript : MonoBehaviour
{
    public Transform mainPanel;
    public Transform instructionPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackToMainMenu();
        }
    }

    public void BackToMainMenu()
    {
        mainPanel.GetComponent<CanvasGroup>().alpha = 1;
        mainPanel.GetComponent<CanvasGroup>().interactable = true;
        mainPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
        instructionPanel.GetComponent<CanvasGroup>().alpha = 0;
        instructionPanel.GetComponent<CanvasGroup>().interactable = false;
        instructionPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
        EventSystem.current.SetSelectedGameObject(null);
    }
}
