using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonClickedTwiceScript : MonoBehaviour
{
    private bool isClick;//是否点击
    private float tempTime = 0;//计时器
    private Button Btn;//按钮
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        
        Btn = this.GetComponent<Button>();
        Btn.onClick.AddListener(OnClick);//注册按钮事件
    }

    // Update is called once per frame
    void Update()
    {
        if (isClick)//如果被点击
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
