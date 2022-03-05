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

    [Tooltip("�˰�ť��Ӧ���¼��ı��")]
    public int buttonID;
    //�����ڴ������е������¼��б�
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
}
