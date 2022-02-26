using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtonScript : MonoBehaviour
{

    public Transform mainPanel;
    public Transform loadPanel;
    public Transform instructionPanel;

    private GameObject emptyPanel;
    private GameObject temp;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        emptyPanel = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Perfab/EmptyPanel.prefab");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadButton()
    {
        temp = Instantiate(emptyPanel);
        Invoke("ChangeMenuToLoad", 1.5f);
    }

    public void StartButton()
    {
        temp = Instantiate(emptyPanel);
        Invoke("StartGame", 1.5f);
    }

    public void QuitButton()
    {
        temp = Instantiate(emptyPanel);
        Invoke("QuitGame", 1.5f);
    }

    public void InstructionButton()
    {
        temp = Instantiate(emptyPanel);
        Invoke("ChangeMenuToInstruction", 1.5f);
    }

    private void ChangeMenuToLoad()
    {
        Destroy(temp);
        mainPanel.GetComponent<CanvasGroup>().alpha = 0;
        mainPanel.GetComponent<CanvasGroup>().interactable = false;
        mainPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
        loadPanel.GetComponent<CanvasGroup>().alpha = 1;
        loadPanel.GetComponent<CanvasGroup>().interactable = true;
        loadPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
        EventSystem.current.SetSelectedGameObject(null);
    }
    private void StartGame()
    {
        Destroy(temp);
        SceneManager.LoadScene("TempGameSence");
    }
    private void ChangeMenuToInstruction()
    {
        Destroy(temp);
        mainPanel.GetComponent<CanvasGroup>().alpha = 0;
        mainPanel.GetComponent<CanvasGroup>().interactable = false;
        mainPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
        instructionPanel.GetComponent<CanvasGroup>().alpha = 1;
        instructionPanel.GetComponent<CanvasGroup>().interactable = true;
        instructionPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
        EventSystem.current.SetSelectedGameObject(null);
    }
    private void QuitGame()
    {
        Destroy(temp);
        Application.Quit();
    }
}
