using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_InputSys : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        // 서로 다른 프레임 환경에서도 동일한 이동속도를 구현하려면? 
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;

        /* 힘을 가하는 이동
        rigid.AddForce(inputVec);

        속도 제어를 통한 이동
        rigid.linearVelocity = inputVec; */

        // 위치 변경을 통한 이동
        rigid.MovePosition(rigid.position + nextVec);
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>(); // 여기서 normalized 자동으로 해줌
    }
}
