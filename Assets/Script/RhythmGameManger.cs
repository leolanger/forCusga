using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmGameManger : MonoBehaviour
{
    // Start is called before the first frame update
    public static RhythmGameManger instance;

    public float BGMVolumn;
    public float speed;
    public float clickSoundVolumn;

    private void Awake()
    {
        BGMVolumn = 1;
        speed = 1;
        clickSoundVolumn = 1;
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
