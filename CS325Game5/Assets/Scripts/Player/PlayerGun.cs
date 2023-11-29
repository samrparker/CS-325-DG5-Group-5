using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{

    public GameObject reticle;
    private Transform reticleTransform;
    private Rigidbody2D reticleBody;

    // Start is called before the first frame update
    void Start()
    {
        reticleTransform = reticle.GetComponent<Transform>();
        reticleBody = reticle.GetComponent<Rigidbody2D>();
    }

    public void UpdateReticle(){
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        newPosition.z = 0;
        reticleTransform.position = newPosition;
    }
}
