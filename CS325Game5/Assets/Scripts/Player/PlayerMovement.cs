using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject camera;

    private Camera cam;

    private Transform cameraTransform;

    private Rigidbody2D rigidBody;

    private Transform trans;
    private Vector3 previousAngle;

    private PlayerGun playerGun;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        cameraTransform = camera.GetComponent<Transform>();

        cam = Camera.main;

        rigidBody = this.GetComponent<Rigidbody2D>();

        trans = this.GetComponent<Transform>();
        previousAngle = new Vector3(0, 0, 0);

        playerGun = this.GetComponent<PlayerGun>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 relative = trans.InverseTransformPoint(cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)));
        relative.z = 0;
        float angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;

        if(angle != 0){

            Quaternion target = Quaternion.Euler(0, 0, -angle+previousAngle.z);
            transform.rotation = target;
            previousAngle.z = (-angle + previousAngle.z) % 360;
        }

        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");

        rigidBody.velocity = new Vector2(directionX * 7f, directionY * 7f);

        playerGun.UpdateReticle();

        /*if(Input.GetKeyDown("W")){
            rigidBody.velocity = new Vector3(0, 1, 0);
        }
        else{
            rigidBody.velocity = new Vector3(0, 0, 0);
        }*/
        Vector3 cameraPosition = trans.position;
        cameraPosition.z = -10;
        cameraTransform.position = cameraPosition;

    }
}
