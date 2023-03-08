using UnityEngine;

public class FPSControl : MonoBehaviour
{
    public float velocidadMovimiento = 3f;
    public float sensibilidadMouse = 100f;
    public Transform playerBody;
    public float xRotacion;
    public float yRotacion;
    public float RotationSpeed;
    public AudioSource _AudSource;



    void Start()
    {

    }


    void Update()
    {
        Move();
        BloqueoCusor();
        MouseLook();

    }


    void Move()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 inputPlayer = new Vector3(hor, 0, ver);
        transform.Translate(new Vector3(hor, 0, ver) * velocidadMovimiento * Time.deltaTime);
        // rb.AddForce(inputPlayer * velocidadMovimiento * Time.deltaTime);
    }
   
    public void BloqueoCusor()//----------------BLOQUEAR CURSOR-----------//
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void MouseLook()

    {

        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse * Time.deltaTime;

        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse * Time.deltaTime;



        xRotacion -= mouseY;

        xRotacion = Mathf.Clamp(xRotacion, -70, 70);



        yRotacion += mouseX;



        transform.localRotation = Quaternion.Euler(xRotacion, yRotacion, 0);

    }
}
