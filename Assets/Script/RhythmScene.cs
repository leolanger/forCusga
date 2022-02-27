using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmScene : MonoBehaviour
{
    public static RhythmScene instance;

    public Transform pausePanel;
    public Transform resultPanel;
    public Transform game;
    public bool isPause = false;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !isPause)
        {
            Time.timeScale = 0;
            isPause = true;
            pausePanel.GetComponent<CanvasGroup>().alpha = 1;
            pausePanel.GetComponent<CanvasGroup>().interactable = true;
            pausePanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
            game.GetComponent<CanvasGroup>().alpha = 0;
            game.GetComponent<CanvasGroup>().interactable = false;
            game.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        if (!isPause)
            Time.timeScale = 1;
    }
}
