using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSelectController : MonoBehaviour
{
    //ȷ��ѡ������ֵ�ID
    public static MusicSelectController instance;

    [Range(1,4)]
    public int musicID = 1;
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
