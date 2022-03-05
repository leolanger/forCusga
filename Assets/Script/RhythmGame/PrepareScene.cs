using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PrepareScene : MonoBehaviour
{
    //音游准备界面控制脚本
    public Slider [] setUp = new Slider[3];

    private Vector3 lastMousPos;
    private int index = -1;

    // Start is called before the first frame update
    void Start()
    {
        setUp[0].GetComponent<Slider>().value = RhythmGameManger.instance.BGMVolumn;
        setUp[1].GetComponent<Slider>().value = RhythmGameManger.instance.speed;
        setUp[2].GetComponent<Slider>().value = RhythmGameManger.instance.clickSoundVolumn;

        lastMousPos = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        if ((lastMousPos != Input.mousePosition) && (index != -1) || Input.GetMouseButtonUp(0))
        {
            EventSystem.current.SetSelectedGameObject(null);
            index = -1;
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            if (index != -1)
            {
                index = (index + 2) % 3;
            }
            else if (index == -1)
            {
                index = 2;
                setUp[index].GetComponent<Slider>().Select();
            }
            lastMousPos = Input.mousePosition;
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            if (index != -1)
            {
                index = (index + 1) % 3;
            }
            else if (index == -1)
            {
                index = (index + 1) % 3;
                setUp[index].GetComponent<Slider>().Select();
            }
            lastMousPos = Input.mousePosition;
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            if(index != -1)
            {
                setUp[index].GetComponent<Slider>().value++;
                Debug.Log("1");
            }
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            if (index != -1)
            {
                Debug.Log("2");
                setUp[index].GetComponent<Slider>().value--;
            }
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("RhythmGameMusic" + MusicSelectController.instance.musicID);
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (MusicSelectController.instance.isComeFromRoom)
                SceneManager.LoadScene("BedRoom");
            else
                SceneManager.LoadScene("SelectMusic");
        }
    }

    public void BGMVolumnChanged()
    {
        RhythmGameManger.instance.BGMVolumn = (int)setUp[0].GetComponent<Slider>().value;
        Debug.Log("BGMVolumn: " + RhythmGameManger.instance.BGMVolumn);
    }

    public void SpeedChanged()
    {
        RhythmGameManger.instance.speed = (int)setUp[1].GetComponent<Slider>().value;
        Debug.Log("Speed: " + RhythmGameManger.instance.speed);
    }

    public void ClickSoundVolumnChanged()
    { 
        RhythmGameManger.instance.clickSoundVolumn = (int)setUp[2].GetComponent<Slider>().value;
        Debug.Log("ClickSoundVoumn: " + RhythmGameManger.instance.clickSoundVolumn);
    }
}


