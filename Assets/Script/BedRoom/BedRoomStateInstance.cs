using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedRoomStateInstance : MonoBehaviour
{
    // Start is called before the first frame update

    public static BedRoomStateInstance instance;

    public float BGMVolumn;
    public float EffectMusicVolum;


    private void Awake()
    {
        BGMVolumn = 1;
        EffectMusicVolum = 1;
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
