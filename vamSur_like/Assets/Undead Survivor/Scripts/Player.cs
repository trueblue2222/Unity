using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // GetAxis는 연속적으로 GetAxisRaw는 이산적으로
        // GetAxis는 좀 미끄러지는 느낌, GetAxisRaw는 딱딱 멈추게 할 수 있음.
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // 서로 다른 프레임 환경에서도 동일한 이동속도를 구현하려면? 
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;

        /* 힘을 가하는 이동
        rigid.AddForce(inputVec);

        속도 제어를 통한 이동
        rigid.linearVelocity = inputVec; */

        // 위치 변경을 통한 이동
        rigid.MovePosition(rigid.position + nextVec);
    }
}
