using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//歌曲选择界面控制脚本
public class SelectMusic : MonoBehaviour
{
    public Button[] musics = new Button[4];

    private int index = -1;
    private Vector3 lastMousPos;

    // Start is called before the first frame update
    void Start()
    {
        lastMousPos = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        if ((lastMousPos != Input.mousePosition) && (index != -1))
        {
            EventSystem.current.SetSelectedGameObject(null);
            index = -1;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (index != -1)
            {
                index = (index + 3) % 4;
            }
            else if (index == -1)
            {
                index = 3;
                musics[index].GetComponent<Button>().Select();
            }
            lastMousPos = Input.mousePosition;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (index != -1)
            {
                index = (index + 1) % 4;
            }
            else if (index == -1)
            {
                index = (index + 1) % 4;
                musics[index].GetComponent<Button>().Select();
            }
            lastMousPos = Input.mousePosition;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            if(index != -1)
            {
                musics[index].onClick.Invoke();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("BedRoom");
        }
    }

    public void LoadFirstMusic()
    {
        MusicSelectController.instance.musicID = 1;
        MusicSelectController.instance.isComeFromRoom = false;
        SceneManager.LoadScene("prepare");
    }
    public void LoadSecondMusic()
    {
        MusicSelectController.instance.musicID = 2;
        MusicSelectController.instance.isComeFromRoom = false;
        SceneManager.LoadScene("prepare");
    }
    public void LoadThirdMusic()
    {
        MusicSelectController.instance.musicID = 3;
        MusicSelectController.instance.isComeFromRoom = false;
        SceneManager.LoadScene("prepare");
    }
    public void LoadForthMusic()
    {
        MusicSelectController.instance.musicID = 4;
        MusicSelectController.instance.isComeFromRoom = false;
        SceneManager.LoadScene("prepare");
    }
}
