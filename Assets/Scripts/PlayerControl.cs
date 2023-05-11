using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpd = 1f;
    public float jumpFrc = 1f;
    public Rigidbody gravity;
    public BoxCollider hitbox;
    private bool direction;

    private void Awake()
    {
        hitbox = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            gravity.AddForce(Vector3.up * jumpFrc, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        float xInput = Input.GetAxis("Horizontal");
        gravity.velocity = new Vector3(xInput*moveSpd, gravity.velocity.y, gravity.velocity.z);
        if (xInput < 0)
        {
            direction = false;
            this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if(xInput > 0)
        {
            direction = true;
            this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.rotation.eulerAngles.x == 180f)
        {
            gravity.AddForce(Vector3.left * jumpFrc * 10f, ForceMode.Impulse);
        }
        else if(other.gameObject.transform.rotation.eulerAngles.x == 0f)
        {
            gravity.AddForce(Vector3.right * jumpFrc * 10f, ForceMode.Impulse);
        }
    }
}
