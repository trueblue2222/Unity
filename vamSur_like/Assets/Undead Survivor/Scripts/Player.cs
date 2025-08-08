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
        // GetAxis�� ���������� GetAxisRaw�� �̻�������
        // GetAxis�� �� �̲������� ����, GetAxisRaw�� ���� ���߰� �� �� ����.
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // ���� �ٸ� ������ ȯ�濡���� ������ �̵��ӵ��� �����Ϸ���? 
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;

        /* ���� ���ϴ� �̵�
        rigid.AddForce(inputVec);

        �ӵ� ��� ���� �̵�
        rigid.linearVelocity = inputVec; */

        // ��ġ ������ ���� �̵�
        rigid.MovePosition(rigid.position + nextVec);
    }
}
