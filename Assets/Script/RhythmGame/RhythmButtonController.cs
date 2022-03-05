using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class RhythmButtonController : MonoBehaviour
{
    //音游轨道控制脚本
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode keyToPress;

    [Tooltip("此按钮对应的事件的编号")]
    public int buttonID;
    //包含在此音轨中的所有事件列表
    List<KoreographyEvent> laneEvents = new List<KoreographyEvent>();

    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!RhythmScene.instance.isPause)
        {
            if (Input.GetKeyDown(keyToPress))
            {
                theSR.sprite = pressedImage;
            }
            if (Input.GetKeyUp(keyToPress))
            {
                theSR.sprite = defaultImage;
            }
        }

    }

    //检测事件是否匹配当前编号的音轨
    public bool DoesMatch(int noteID)
    {
        return noteID == buttonID;
    }

    //如果匹配，则把当前事件添加进音轨所持有的事件列表
    public void AddEventToLane(KoreographyEvent evt)
    {
        laneEvents.Add(evt);
    }
}
