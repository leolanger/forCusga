using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class NoteObject : MonoBehaviour
{
    private SpriteRenderer visuals;
    public Sprite shorImage;
    public Sprite longImage;

    private KoreographyEvent trackEvent;

    public bool isLongNoteStart;
    public bool isLongNoteEnd;

    private RhythmButtonController laneController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }

    public void Initialize (KoreographyEvent evt, int noteNum, RhythmButtonController buttonController, bool isLongStart, bool isLongEnd)
    {
        trackEvent = evt;
        laneController = buttonController;
        isLongNoteStart = isLongStart;
        isLongNoteEnd = isLongEnd;
        int spriteNum = noteNum;
        //if (isLongNoteEnd || isLongNoteEnd)
        //    visuals.sprite = longImage;
        //else
        //    visuals.sprite = shorImage;
        
    }

    //��Note��������
    public void ResetNote()
    {
        trackEvent = null;
        laneController = null;
    }

    //���ض����
    void ReturnToPool()
    {
        RhythmScene.instance.ReturnNoteObjectToPool(this);
        ResetNote();
    }

    //������������
    public void OnHit()
    {
        ReturnToPool();
    }

    //����λ��
    void UpdatePosition()
    {
        Vector3 pos = laneController.TargetPosition;

        pos.y -= (RhythmScene.instance.DelayedSampleTime - trackEvent.StartSample) / (float)RhythmScene.instance.SampleRate * RhythmScene.instance.getNoteSpeed;

        transform.position = pos;
    }
}
