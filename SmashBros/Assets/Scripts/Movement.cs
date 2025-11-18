using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10.0f;
    private float horizontalInput;
    private float upwardInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        upwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector2.up * upwardInput * speed * Time.deltaTime);
        transform.Translate(Vector2.right * horizontalInput * speed * Time.deltaTime);
    }
}
