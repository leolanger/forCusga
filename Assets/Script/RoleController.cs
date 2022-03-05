using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleController : MonoBehaviour
{

    private bool isRight = false;//判断人物朝向，测试用
    private float Speed = 10f;
    private Rigidbody2D player;
    private Vector2 movePosition = new Vector2(0,0);
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {


    }

    void filp()
    {
        isRight = !isRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void FixedUpdate()
    {
        if (movePosition.x == 0)
        {
            movePosition.x = Input.GetAxis("Horizontal");
            //人物方向改变，测试使用
            if ((movePosition.x > 0 && !isRight) || (movePosition.x < 0 && isRight))
            {
                filp();
            }
        }
        if (movePosition.y == 0)
        {
            movePosition.y = Input.GetAxis("Vertical");
        }
        if (movePosition.x != 0 || movePosition.y != 0)
        {
            Vector2 pos = transform.position;
            pos.x += movePosition.x * Time.deltaTime * Speed;
            pos.y += movePosition.y * Time.deltaTime * Speed;
            player.MovePosition(pos);
        }
        movePosition = new Vector2(0, 0);

    }


}
