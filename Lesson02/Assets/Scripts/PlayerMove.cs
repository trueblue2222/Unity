using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    const float SPEED_JUMP = 5.0f;
    const float SPEED_MOVE = 3.0f;

    Rigidbody2D rb;
    bool leftPressed = false;
    bool rightPressed = false;
    bool aPressed = false;
    bool dPressed = false;
 


    // Start is called bvefore the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb != null)
        {
            float dist = SPEED_MOVE * Time.deltaTime;
            Vector2 pos = transform.position;

            // 왼쪽 이동
            if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                leftPressed = true;
                aPressed = true;
            }
            if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
            {
                leftPressed = false;
                aPressed = false;
            }
            if(leftPressed || aPressed)
            {
                pos.x -= dist;
            }

            // 오른쪽 이동
            if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                rightPressed = true;
                dPressed = true;
            }
            if(Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
            {
                rightPressed = false;
                dPressed = false;
            }
            if(rightPressed || dPressed)
            {
                pos.x += dist;
            }
            transform.position = pos;
            // 점프
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.W))
            {
                Vector2 moveVelocity = rb.linearVelocity;
                moveVelocity.y = SPEED_JUMP;
                rb.linearVelocity = moveVelocity;
            }

            // 순간이동
            if(Input.GetMouseButtonDown(1))
            {
                Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = newPos;
                rb.linearVelocity = Vector2.zero;
            }
        }
    }
}

