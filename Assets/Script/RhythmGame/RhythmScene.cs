using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

//音游界面控制脚本
public class RhythmScene : MonoBehaviour
{
    public static RhythmScene instance;

    public Transform pausePanel;
    public Transform resultPanel;
    public Transform game;

    Stack<NoteObject> noteObjectPool = new Stack<NoteObject>();
    //音符
    public NoteObject noteObject;
    [Tooltip("用于目标生成的轨道")]
    [EventID]
    public string eventID;
    public bool isPause = false;
    public AudioSource audioCom;
    public List<RhythmButtonController> noteLanes = new List<RhythmButtonController>();
    
    [Tooltip("音符命中区间窗口，单位：ms")]
    [Range(8f,300f)]
    public float hitWindowRangeInMS;
    //音符速度
    private float noteSpeed;
    public float getNoteSpeed { get { return noteSpeed; } }
    //当前以长度为单位的命中窗口的大小
    public float WindowSizeInUnits { get { return noteSpeed * (hitWindowRangeInMS * 0.001f); } }
    //以音乐样本为单位的命中窗口大小
    private int hitWindowRangeInSamples;
    //采样率
    public int SampleRate { get { return playingKoreo.SampleRate; } }
    public int HitWindowSampleWidth { get { return hitWindowRangeInSamples; } }

    Koreography playingKoreo;

    [Tooltip("开始播放音频之前提供的时间量")]
    public float leadInTime;
    //音频播放之前的剩余时间
    private float leadInTimeLeft;
    //音乐开始之前的计时器
    private float timeLeftToPlay;
    //当前的采样时间，包括任何必要的延迟
    public int DelayedSampleTime { get { return playingKoreo.GetLatestSampleTime() - SampleRate*(int)leadInTimeLeft; } }

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializeLeadIn();

        noteSpeed = RhythmGameManger.instance.speed;

        //获取Koreography对象
        playingKoreo = Koreographer.Instance.GetKoreographyAtIndex(0);
        //获取事件轨迹
        KoreographyTrackBase rhythmTrack = playingKoreo.GetTrackByID(eventID);
        //获取事件
        List<KoreographyEvent> rawEvents =  rhythmTrack.GetAllEvents();

        for(int i= 0; i <rawEvents.Count;i++)
        {
            KoreographyEvent evt = rawEvents[i];
            int noteID = evt.GetIntValue();

            //遍历所有音轨
            for(int j = 0; j < noteLanes.Count;j++)
            {
                RhythmButtonController lane = noteLanes[j];
                if(noteID>6)
                {
                    noteID = noteID - 6;
                    if (noteID > 6)
                    {
                        noteID = noteID - 6;
                    }
                }
                Debug.Log("noteId:" +noteID);
                Debug.Log("buttonId:" + lane.buttonID);
                if (lane.DoesMatch(noteID))
                {
                    lane.AddEventToLane(evt);
                    break;
                }
            }
        }

        hitWindowRangeInSamples = (int) (SampleRate * hitWindowRangeInMS * 0.001f);
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeftToPlay>0)
        {
            timeLeftToPlay -= Time.unscaledDeltaTime;
            if(timeLeftToPlay<=0)
            {
                audioCom.Play();
                timeLeftToPlay = 0;
            }
        }

        //倒数引导时间
        if(leadInTimeLeft > 0)
        {
            leadInTimeLeft = Mathf.Max(leadInTimeLeft - Time.unscaledDeltaTime, 0); 
        }

        if(Input.GetKeyDown(KeyCode.Escape) && !isPause)
        {
            Time.timeScale = 0;
            isPause = true;
            pausePanel.GetComponent<CanvasGroup>().alpha = 1;
            pausePanel.GetComponent<CanvasGroup>().interactable = true;
            pausePanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
            game.GetComponent<CanvasGroup>().alpha = 0;
            game.GetComponent<CanvasGroup>().interactable = false;
            game.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        if (!isPause)
            Time.timeScale = 1;
    }

    void InitializeLeadIn()
    {
        if(leadInTime>0)
        {
            leadInTimeLeft = leadInTime;
            timeLeftToPlay = leadInTime;
        }
        else
        {
            audioCom.Play();
        }
    }

    //从对象池取对象
    public NoteObject GetFreshNoteObject()
    {
        NoteObject retObj;
        if(noteObjectPool.Count >0)
        {
            retObj = noteObjectPool.Pop();
        }
        else
        {
            //资源源
            //retObj = Instantiate<NoteObject>(noteObject);
            retObj = Instantiate(noteObject);
        }

        retObj.gameObject.SetActive(true);
        retObj.enabled = true;

        return retObj;
    }

    public void ReturnNoteObjectToPool(NoteObject obj)
    {
        if(obj != null)
        {
            obj.enabled = false;
            obj.gameObject.SetActive(false);
            noteObjectPool.Push(obj);
        }
    }
}
