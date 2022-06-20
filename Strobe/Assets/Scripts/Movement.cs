using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject self;

    public float forwardForce = 1000f;
    public float HorizontalForce = 0f;
    public float VerticalForce = 0f;
    public bool ForwardThrust = true;
    public bool LeftThrust = false;
    public bool RightThrust = false;
    public bool UpwardsThrust = false;
    public bool DownwardsThrust = false;
    public bool Anticlock = false;
    public bool Clock = false;
    public float RotateForce = 0f;
    public float RotatePoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
    //Left
        if (Input.GetKey("a"))
        {
            LeftThrust = true;
        }
        else
        {
            LeftThrust = false;
        }
    //Right
        if (Input.GetKey("d"))
        {
            RightThrust = true;
        }
        else
        {
            RightThrust = false;
        }
    //Upwards
        if (Input.GetKey("w"))
        {
            UpwardsThrust = true;
        }
        else
        {
            UpwardsThrust = false;
        }
    //Downwards
        if (Input.GetKey("s"))
        {
            DownwardsThrust = true;
        }
        else
        {
            DownwardsThrust = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    // Thrust
        rb.AddForce(0,0,forwardForce * Time.deltaTime);
    // Left and right
        if (LeftThrust == true)
        {
            rb.AddForce(-HorizontalForce * Time.deltaTime,0,0, ForceMode.VelocityChange);

        }
        if (RightThrust == true)
        {
            rb.AddForce(HorizontalForce * Time.deltaTime,0,0, ForceMode.VelocityChange);

        }
    //Up and Down
        if (UpwardsThrust == true)
        {
            rb.AddForce(0,VerticalForce * Time.deltaTime,0, ForceMode.VelocityChange);
        }
        else
        {
            rb.AddForce(0,-VerticalForce * Time.deltaTime,0, ForceMode.VelocityChange);
        }
        
        if (DownwardsThrust == true)
        {
            rb.AddForce(0,-VerticalForce * Time.deltaTime,0, ForceMode.VelocityChange);
        }
        else
        {
            rb.AddForce(0,VerticalForce * Time.deltaTime,0, ForceMode.VelocityChange);
        }
    //Velocity = rotation
        if (rb.velocity.x > 2)
        {
            RotateForce = rb.velocity.x * 8;
            RotatePoint = -rb.velocity.x;
        }
        else if (rb.velocity.x < -2)
        {
            RotateForce = (rb.velocity.x * -1) * 8;
            RotatePoint = -rb.velocity.x;
        }
        else
        {
            RotateForce = 50f;
            RotatePoint = -rb.velocity.x;
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(RotatePoint * 6, -90, 0), RotateForce * Time.deltaTime);
    }
}
