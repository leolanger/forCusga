using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingScript : MonoBehaviour
{

    public Slider[] sliders = new Slider[2];

    // Start is called before the first frame update
    void Start()
    {
        sliders[0].GetComponent<Slider>().value = BedRoomStateInstance.instance.BGMVolumn;
        sliders[1].GetComponent<Slider>().value = BedRoomStateInstance.instance.EffectMusicVolum;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BGMVolumnChanged()
    {
        BedRoomStateInstance.instance.BGMVolumn = (int)sliders[0].GetComponent<Slider>().value;
        Debug.Log("BGMVolumn:" + BedRoomStateInstance.instance.BGMVolumn);
    }

    public void EffectMusicVolumnChanged()
    {
        BedRoomStateInstance.instance.EffectMusicVolum = (int)sliders[1].GetComponent<Slider>().value;
        Debug.Log("EffectVolumn:" + BedRoomStateInstance.instance.EffectMusicVolum);
    }
}
