using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MusicButtonAnimController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator ani;

    public void OnPointerEnter(PointerEventData eventData)
    {
        ani.SetTrigger("Highlighted");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ani.SetTrigger("Normal");
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
