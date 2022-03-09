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
    //上下边界
    public Transform targetTopTrans;
    public Transform targetBottomTrans;

    [Tooltip("此按钮对应的编号")]
    public int buttonID;
    //包含在此音轨中的所有事件列表
    List<KoreographyEvent> laneEvents = new List<KoreographyEvent>();
    //包含此音轨当前活动的所有音符对象的队列
    Queue<NoteObject> trackNotes = new Queue<NoteObject>();
    //检测此音轨中的生成的下一个事件的索引
    private int pendingEventIndex = 0;
    public Vector3 TargetPosition { get { return targetTopTrans.transform.position; } }

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

        CheckSpawnNext();
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

    //音符在音谱上产生的位置偏移量
    int GetSpawnSampleOffSet()
    {
        //出生位置与目标点的位置
        float spawnDisToTarget = targetTopTrans.position.y - transform.position.y;
        //到达目标点的时间
        float spawnPosToTargetTime = spawnDisToTarget / RhythmScene.instance.getNoteSpeed;

        return (int)spawnPosToTargetTime * RhythmScene.instance.SampleRate;
    }

    //检测是否生成下一个新音符
    void CheckSpawnNext()
    {
        int sampleToTarget = GetSpawnSampleOffSet();

        int currentTime = RhythmScene.instance.DelayedSampleTime;

        while(pendingEventIndex < laneEvents.Count && laneEvents[pendingEventIndex].StartSample < currentTime + sampleToTarget)
        {
            KoreographyEvent evt = laneEvents[pendingEventIndex];
            int noteNum = evt.GetIntValue();
            NoteObject newObj = RhythmScene.instance.GetFreshNoteObject();
            bool isLongNoteStart = false;
            bool isLongNoteEnd = false;
            if(noteNum > 6)
            {
                isLongNoteStart = true;
                noteNum = noteNum - 6;
                if(noteNum > 6)
                {
                    isLongNoteEnd = true;
                    isLongNoteStart = false;
                    noteNum = noteNum - 6;
                }
            }

            newObj.Initialize(evt,noteNum,this,isLongNoteStart,isLongNoteEnd);
            trackNotes.Enqueue(newObj);
            pendingEventIndex++;
        }
        //Debug.Log("LaneEvents:" + laneEvents.Count);
        //Debug.Log("PendingIndex:" + pendingEventIndex);
    }
}
