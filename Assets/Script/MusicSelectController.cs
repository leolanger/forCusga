using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSelectController : MonoBehaviour
{
    public static MusicSelectController instance;

    [Range(1,4)]
    public int musicID;
    public bool isComeFromRoom = true;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
