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
        // ���� �ٸ� ������ ȯ�濡���� ������ �̵��ӵ��� �����Ϸ���? 
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;

        /* ���� ���ϴ� �̵�
        rigid.AddForce(inputVec);

        �ӵ� ��� ���� �̵�
        rigid.linearVelocity = inputVec; */

        // ��ġ ������ ���� �̵�
        rigid.MovePosition(rigid.position + nextVec);
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>(); // ���⼭ normalized �ڵ����� ����
    }
}
