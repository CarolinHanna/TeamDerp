using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
    public GameObject camera;
    private Camera playercamera;
    Vector3 input = Vector3.zero;
    private float CameraShakeX = 0.5f;
    private float CameraShakeY = 0.5f;
    [SerializeField]
    private float shakenessX = 0.1f;
    [SerializeField]
    private float shakenessY = 0.1f;
    private Vector3 rotate;
    private float z;
    private float acceler = 0.001f;
    private float speed = 0;
    // Use this for initialization
    void Start () {
        playercamera = camera.GetComponent<Camera>();
	}

    // Update is called once per frame
    void Update()
    {
        input = Vector3.zero;
        rotate = Vector3.zero;
        //input
        input.x = Input.GetAxis("Horizontal");
        input.z = Input.GetAxis("Vertical");
        rotate.x = Input.GetAxis("Vertical1");
        rotate.y = Input.GetAxis("Horizontal1");
       // transform.position += input;
        if (Mathf.Abs(input.x)>0.001f)
        {
            shakenessX = 0.01f;
        }   
        else
        {
            //print(input.x);
            shakenessX = 0.001f;
        }
        if (Mathf.Abs(input.y) > 0.001f)
            shakenessY = 0.01f;
        else
            shakenessY = 0.0066f;


        CameraShakeX += 0.05f;
        CameraShakeY += 0.05f;
        camerashake();
    }

    void camerashake()
    {
        float y = transform.position.y;
        //the movement part 
        if (input.x == 0 && input.z == 0)
            speed = 0;
        if (input.x >= 0)
        {
            checkspeed();
            transform.position += transform.right * speed;
        }
        if (input.x <= 0)
        {
            checkspeed();
            transform.position -= transform.right * speed; }

        if (input.z >= 0)
        {
            checkspeed();
            transform.position += transform.forward * speed; }
        if (input.z <= 0)
        {
            checkspeed();
            transform.position -= transform.forward * speed;
        }
        //the camera rotation
        z = transform.eulerAngles.z;
        transform.position = new Vector3(transform.position.x + shakenessX * Mathf.Sin(CameraShakeX), y, transform.position.z + shakenessY * Mathf.Sin(CameraShakeY));
        transform.Rotate(-rotate.x,rotate.y, -z);
    }
    //accelerate
    void checkspeed()
    {
        if (speed < 0.2f)
            speed += acceler;
    }
}
