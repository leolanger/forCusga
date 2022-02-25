using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonScript : MonoBehaviour
{

    public Transform mainPanel;
    public Transform loadPanel;
    public Transform instructionPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadButton()
    {
        Invoke("ChangeMenuToLoad", 1.25f);
    }

    public void StartButton()
    {
        Invoke("StartGame", 1.25f);
    }

    public void QuitButton()
    {
        Invoke("QuitGame", 1.25f);
    }

    public void InstructionButton()
    {
        Invoke("ChangeMenuToInstruction", 1.25f);
    }

    private void ChangeMenuToLoad()
    {
        mainPanel.gameObject.SetActive(false);
        loadPanel.gameObject.SetActive(true);
    }
    private void StartGame()
    {
        
    }
    private void ChangeMenuToInstruction()
    {
        mainPanel.gameObject.SetActive(false);
        instructionPanel.gameObject.SetActive(true);
    }
    private void QuitGame()
    {
        Application.Quit();
    }
}
