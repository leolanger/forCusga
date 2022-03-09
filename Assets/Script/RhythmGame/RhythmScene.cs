using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

//���ν�����ƽű�
public class RhythmScene : MonoBehaviour
{
    public static RhythmScene instance;

    public Transform pausePanel;
    public Transform resultPanel;
    public Transform game;

    Stack<NoteObject> noteObjectPool = new Stack<NoteObject>();
    //����
    public NoteObject noteObject;
    [Tooltip("����Ŀ�����ɵĹ��")]
    [EventID]
    public string eventID;
    public bool isPause = false;
    public AudioSource audioCom;
    public List<RhythmButtonController> noteLanes = new List<RhythmButtonController>();
    
    [Tooltip("�����������䴰�ڣ���λ��ms")]
    [Range(8f,300f)]
    public float hitWindowRangeInMS;
    //�����ٶ�
    private float noteSpeed;
    public float getNoteSpeed { get { return noteSpeed; } }
    //��ǰ�Գ���Ϊ��λ�����д��ڵĴ�С
    public float WindowSizeInUnits { get { return noteSpeed * (hitWindowRangeInMS * 0.001f); } }
    //����������Ϊ��λ�����д��ڴ�С
    private int hitWindowRangeInSamples;
    //������
    public int SampleRate { get { return playingKoreo.SampleRate; } }
    public int HitWindowSampleWidth { get { return hitWindowRangeInSamples; } }

    Koreography playingKoreo;

    [Tooltip("��ʼ������Ƶ֮ǰ�ṩ��ʱ����")]
    public float leadInTime;
    //��Ƶ����֮ǰ��ʣ��ʱ��
    private float leadInTimeLeft;
    //���ֿ�ʼ֮ǰ�ļ�ʱ��
    private float timeLeftToPlay;
    //��ǰ�Ĳ���ʱ�䣬�����κα�Ҫ���ӳ�
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

        //��ȡKoreography����
        playingKoreo = Koreographer.Instance.GetKoreographyAtIndex(0);
        //��ȡ�¼��켣
        KoreographyTrackBase rhythmTrack = playingKoreo.GetTrackByID(eventID);
        //��ȡ�¼�
        List<KoreographyEvent> rawEvents =  rhythmTrack.GetAllEvents();

        for(int i= 0; i <rawEvents.Count;i++)
        {
            KoreographyEvent evt = rawEvents[i];
            int noteID = evt.GetIntValue();

            //������������
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

        //��������ʱ��
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

    //�Ӷ����ȡ����
    public NoteObject GetFreshNoteObject()
    {
        NoteObject retObj;
        if(noteObjectPool.Count >0)
        {
            retObj = noteObjectPool.Pop();
        }
        else
        {
            //��ԴԴ
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
