using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using UnityEngine.EventSystems;

public class test : MonoBehaviour, ISelectHandler
{
    private Animator ani;

    void ISelectHandler.OnSelect(BaseEventData eventData)
    {
        Debug.Log(ani.name);
        ani.SetTrigger("Selected");
    }

    // Start is called before the first frame update
    void Start()
    {
        ani = this.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
