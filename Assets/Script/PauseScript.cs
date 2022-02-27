using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public Selectable[] options = new Selectable[5];
    public Transform game;
    public Transform pause;

    public int index = -1;
    private Vector3 lastMousPos;
    private float tempBGM;
    private float tempPlay;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        lastMousPos = Input.mousePosition;
        tempBGM = RhythmGameManger.instance.BGMVolumn; 
        tempPlay = RhythmGameManger.instance.clickSoundVolumn;

        options[0].GetComponent<Slider>().value = tempBGM;
        options[1].GetComponent<Slider>().value = tempPlay;
    }

    // Update is called once per frame
    void Update()
    {
        if ((lastMousPos != Input.mousePosition) && (index != -1) || Input.GetMouseButtonUp(0))
        {
            EventSystem.current.SetSelectedGameObject(null);
            index = -1;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (index != -1)
            {
                index = (index + 4) % 5;
            }
            else if (index == -1)
            {
                index = 4;
                options[index].GetComponent<Selectable>().Select();
            }
            lastMousPos = Input.mousePosition;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (index != -1)
            {
                index = (index + 1) % 5;
            }
            else if (index == -1)
            {
                index = (index + 1) % 5;
                options[index].GetComponent<Selectable>().Select();
            }
            lastMousPos = Input.mousePosition;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (index == 0 || index == 1)
            {
                options[index].GetComponent<Slider>().value++;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (index == 0 || index == 1)
            {
                options[index].GetComponent<Slider>().value--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            if(index == 2 || index == 3 || index == 4)
            {
                options[index].GetComponent<Button>().onClick.Invoke();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && RhythmScene.instance.isPause)
        {
            OnContinueClicked();
        }
    }

    public void BGMVolumnChanged()
    {
        RhythmGameManger.instance.BGMVolumn = (int)options[0].GetComponent<Slider>().value;
        //Debug.Log("BGMVolumn: " + RhythmGameManger.instance.BGMVolumn);
    }

    public void PlayVolumnChanged()
    {
        RhythmGameManger.instance.clickSoundVolumn = (int)options[1].GetComponent<Slider>().value;
        //Debug.Log("PlayVolumn: " + RhythmGameManger.instance.clickSoundVolumn);
    }

    public void OnContinueClicked()
    {
        index = -1;
        game.GetComponent<CanvasGroup>().alpha = 1;
        game.GetComponent<CanvasGroup>().interactable = true;
        game.GetComponent<CanvasGroup>().blocksRaycasts = true;
        pause.GetComponent<CanvasGroup>().alpha = 0;
        pause.GetComponent<CanvasGroup>().interactable = false;
        pause.GetComponent<CanvasGroup>().blocksRaycasts = false;
        RhythmScene.instance.isPause = false;
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void OnRestartClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnExitClicked()
    {
        SceneManager.LoadScene("BedRoom");
    }
}
