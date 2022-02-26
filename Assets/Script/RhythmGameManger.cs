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
