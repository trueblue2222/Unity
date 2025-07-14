using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed = 0.1f;
    private Vector3 vector;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);

            if(vector.x != 0)
            {
                transform.Translate(vector.x * speed, 0, 0);

            }
            else if (vector.y != 0)
            {
                transform.Translate(0, vector.y * speed, 0);
            }
        }
    }
}
