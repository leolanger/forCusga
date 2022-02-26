using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PrepareScene : MonoBehaviour
{
    public Slider [] setUp = new Slider[3];

    private Vector3 lastMousPos;
    private int index = -1;

    // Start is called before the first frame update
    void Start()
    {
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
            }
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            if (index != -1)
            {
                setUp[index].GetComponent<Slider>().value--;
            }
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("RyhthmGame");
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("BedRoom");
        }
    }

    public void BGMVolumnChanged()
    {
        RyhthmGameManger.instance.BGMVolumn = setUp[0].GetComponent<Slider>().value;
        Debug.Log("BGMVolumn: " + RyhthmGameManger.instance.BGMVolumn);
    }

    public void SpeedChanged()
    {
        RyhthmGameManger.instance.speed = setUp[1].GetComponent<Slider>().value;
        Debug.Log("Speed: " + RyhthmGameManger.instance.speed);
    }

    public void ClickSoundVolumnChanged()
    { 
        RyhthmGameManger.instance.clickSoundVolumn = setUp[2].GetComponent<Slider>().value;
        Debug.Log("ClickSoundVoumn: " + RyhthmGameManger.instance.clickSoundVolumn);
    }
}


