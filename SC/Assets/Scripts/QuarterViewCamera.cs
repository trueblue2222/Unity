using UnityEngine;

public class QuarterViewCamera : MonoBehaviour
{
    [Header("Camera Settings")]
    public float height = 20f; // ī�޶� ���� (y��)
    public float angle = 45f; // ī�޶� ���ͺ� ����
    public float distance = 8f; // ī�޶� ���� ȭ�� ����

    [Header("Movement")]
    public float moveSpeed = 7f; // ī�޶� �̵� �ӵ�
    public float edgeScrollSize = 10f; // ���콺�� �̵��� �ش�Ǵ� ȭ�� ����

    private Camera cam; // ī�޶� ������Ʈ
    private float fixedHeight; // ������ ���� (y��)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GetComponent<Camera>();

        transform.rotation = Quaternion.Euler(angle, 45f, 0f); // ���ͺ� ī�޶� ���� ����
        cam.orthographic = true; // ���� �������� ���� (�Ÿ��� ������� ������Ʈ ũ�� ����)
        cam.orthographicSize = distance; // ī�޶� ���� ȭ�� ���� ����

        fixedHeight = height; // y�� ��ǥ ������
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleCameraMovement();

        // (�߿�) �� �����Ӹ��� y�� ��ǥ ����
        Vector3 pos = transform.position; 
        pos.y = fixedHeight;
        transform.position = pos; // �̵� ó�� �� fixedHeight�� y�� ��ǥ�� ����
    }

    void HandleCameraMovement()
    {
        // �����Ӹ��� �̵��ؾ� �� ���Ͱ� ��� ���� ���� �� �ʱ�ȭ
        Vector3 moveDirection = Vector3.zero;

        // Ű���� �Է� �̵�
        if (Input.GetKey(KeyCode.UpArrow))
            moveDirection += GetQuarterViewDirection("forward");
        if (Input.GetKey(KeyCode.DownArrow))
            moveDirection += GetQuarterViewDirection("back");
        if (Input.GetKey(KeyCode.LeftArrow))
            moveDirection += GetQuarterViewDirection("left");
        if (Input.GetKey(KeyCode.RightArrow))
            moveDirection += GetQuarterViewDirection("right");

        // ���콺 �Է� �̵� (ȭ�� �����ڸ�)
        Vector3 mousePos = Input.mousePosition;
        if (mousePos.x < edgeScrollSize)
            moveDirection += GetQuarterViewDirection("left");
        if (mousePos.x > Screen.width - edgeScrollSize)
            moveDirection += GetQuarterViewDirection("right");
        if (mousePos.y < edgeScrollSize)
            moveDirection += GetQuarterViewDirection("back");
        if (mousePos.y > Screen.height - edgeScrollSize)
            moveDirection += GetQuarterViewDirection("forward");

        // x, z�����θ� �̵��ϰ� ���� (y���� �����ؾ� ��)
        Vector3 movement = moveDirection * moveSpeed * Time.deltaTime;
        transform.Translate(movement.x, 0, movement.z, Space.World);
    }

    Vector3 GetQuarterViewDirection(string direction)
    {
        switch (direction)
        {
            case "forward":
                return new Vector3(1, 0, 1).normalized;

            case "back":
                return new Vector3(-1, 0, -1).normalized;

            case "left":
                return new Vector3(-1, 0, 1).normalized;

            case "right":
                return new Vector3(1, 0, -1).normalized;

            default:
                return Vector3.zero;
        }
    }
}
