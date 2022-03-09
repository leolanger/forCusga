using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class RhythmButtonController : MonoBehaviour
{
    //���ι�����ƽű�
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;
    public KeyCode keyToPress;
    //���±߽�
    public Transform targetTopTrans;
    public Transform targetBottomTrans;

    [Tooltip("�˰�ť��Ӧ�ı��")]
    public int buttonID;
    //�����ڴ������е������¼��б�
    List<KoreographyEvent> laneEvents = new List<KoreographyEvent>();
    //���������쵱ǰ���������������Ķ���
    Queue<NoteObject> trackNotes = new Queue<NoteObject>();
    //���������е����ɵ���һ���¼�������
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

    //����¼��Ƿ�ƥ�䵱ǰ��ŵ�����
    public bool DoesMatch(int noteID)
    {
        return noteID == buttonID;
    }

    //���ƥ�䣬��ѵ�ǰ�¼���ӽ����������е��¼��б�
    public void AddEventToLane(KoreographyEvent evt)
    {
        laneEvents.Add(evt);
    }

    //�����������ϲ�����λ��ƫ����
    int GetSpawnSampleOffSet()
    {
        //����λ����Ŀ����λ��
        float spawnDisToTarget = targetTopTrans.position.y - transform.position.y;
        //����Ŀ����ʱ��
        float spawnPosToTargetTime = spawnDisToTarget / RhythmScene.instance.getNoteSpeed;

        return (int)spawnPosToTargetTime * RhythmScene.instance.SampleRate;
    }

    //����Ƿ�������һ��������
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
