using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyhthmGameManger : MonoBehaviour
{
    // Start is called before the first frame update
    public static RyhthmGameManger instance;

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
