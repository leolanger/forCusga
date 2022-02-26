using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonClickedTwiceScript : MonoBehaviour
{
    private bool isClick;//�Ƿ���
    private float tempTime = 0;//��ʱ��
    private Button Btn;//��ť
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        
        Btn = this.GetComponent<Button>();
        Btn.onClick.AddListener(OnClick);//ע�ᰴť�¼�
    }

    // Update is called once per frame
    void Update()
    {
        if (isClick)//��������
        {
            //EventSystem.current.SetSelectedGameObject(Btn.gameObject);
            tempTime += Time.deltaTime;
            if (tempTime > 2)
            {
                tempTime = 0;
                isClick = false;
                
            }
        }
    }
    private void OnClick()
    {
        isClick = true;
        
        //Btn.enabled = false;
    }

}
