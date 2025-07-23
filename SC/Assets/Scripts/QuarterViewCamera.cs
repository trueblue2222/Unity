using UnityEngine;

public class QuarterViewCamera : MonoBehaviour
{
    [Header("Camera Settings")]
    public float height = 20f; // 카메라 높이 (y축)
    public float angle = 45f; // 카메라 쿼터뷰 각도
    public float distance = 8f; // 카메라가 보는 화면 범위

    [Header("Movement")]
    public float moveSpeed = 7f; // 카메라 이동 속도
    public float edgeScrollSize = 10f; // 마우스로 이동시 해당되는 화면 영역

    private Camera cam; // 카메라 컴포넌트
    private float fixedHeight; // 고정된 높이 (y축)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GetComponent<Camera>();

        transform.rotation = Quaternion.Euler(angle, 45f, 0f); // 쿼터뷰 카메라 각도 설정
        cam.orthographic = true; // 직교 투영으로 설정 (거리에 상관없이 오브젝트 크기 동일)
        cam.orthographicSize = distance; // 카메라가 보는 화면 범위 설정

        fixedHeight = height; // y축 좌표 고정값
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleCameraMovement();

        // (중요) 매 프레임마다 y축 좌표 고정
        Vector3 pos = transform.position; 
        pos.y = fixedHeight;
        transform.position = pos; // 이동 처리 후 fixedHeight를 y축 좌표로 설정
    }

    void HandleCameraMovement()
    {
        // 프레임마다 이동해야 할 벡터값 담는 변수 선언 및 초기화
        Vector3 moveDirection = Vector3.zero;

        // 키보드 입력 이동
        if (Input.GetKey(KeyCode.UpArrow))
            moveDirection += GetQuarterViewDirection("forward");
        if (Input.GetKey(KeyCode.DownArrow))
            moveDirection += GetQuarterViewDirection("back");
        if (Input.GetKey(KeyCode.LeftArrow))
            moveDirection += GetQuarterViewDirection("left");
        if (Input.GetKey(KeyCode.RightArrow))
            moveDirection += GetQuarterViewDirection("right");

        // 마우스 입력 이동 (화면 가장자리)
        Vector3 mousePos = Input.mousePosition;
        if (mousePos.x < edgeScrollSize)
            moveDirection += GetQuarterViewDirection("left");
        if (mousePos.x > Screen.width - edgeScrollSize)
            moveDirection += GetQuarterViewDirection("right");
        if (mousePos.y < edgeScrollSize)
            moveDirection += GetQuarterViewDirection("back");
        if (mousePos.y > Screen.height - edgeScrollSize)
            moveDirection += GetQuarterViewDirection("forward");

        // x, z축으로만 이동하게 설정 (y축은 고정해야 함)
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
