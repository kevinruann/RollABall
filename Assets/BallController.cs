using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody sphereRigidbody;
    public float ballSpeed = 2f;

    private bool isCollidingWithGround = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            inputVector += Vector2.up;
        }

        if (Input.GetKey(KeyCode.S))
        {
            inputVector += Vector2.down;
        }

        if (Input.GetKey(KeyCode.D))
        {
            inputVector += Vector2.right;
        }

        if (Input.GetKey(KeyCode.A))
        {
            inputVector += Vector2.left;
        }
        
        if (Input.GetKey(KeyCode.Space) && isCollidingWithGround == true)
        {
            sphereRigidbody.AddForce(Vector3.up * ballSpeed, ForceMode.Impulse);

        }
        
        Vector3 inputXZPlane = new Vector3(inputVector.x, 0, inputVector.y);
        sphereRigidbody.AddForce(inputXZPlane * ballSpeed);
        Debug.Log("Resultant Vector: " + inputVector);
        Debug.Log("Resultant 3D Vector: " + inputXZPlane);

    }

    void OnCollisionEnter(Collision collision)
    {
        isCollidingWithGround = true;
    }
}
