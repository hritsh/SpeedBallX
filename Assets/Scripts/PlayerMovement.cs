using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardForce = 1000f;
    public float maxSpeed = 75f;
    public bool changePosition = true;
    public float switchSpeed = 7f;
    public Rigidbody rb;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
        {
            changePosition = !changePosition;
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(Vector3.forward * forwardForce * Time.deltaTime);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        if (changePosition == true)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(1,transform.position.y,transform.position.z), switchSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(-1,transform.position.y,transform.position.z), switchSpeed * Time.deltaTime);
        }
    }
}
