using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//音游脚本，用于存储各种数据
public class RhythmGameManger : MonoBehaviour
{
    // Start is called before the first frame update
    public static RhythmGameManger instance;

    public float BGMVolumn;
    public float speed;
    public float clickSoundVolumn;

    private void Awake()
    {
        BGMVolumn = 5;
        speed = 5;
        clickSoundVolumn = 5;
        instance = this;
    }

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
