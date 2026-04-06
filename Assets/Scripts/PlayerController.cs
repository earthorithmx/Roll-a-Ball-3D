using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{

    public float speed = 15f;
    public float count;
    public Text winText;
    public Text countText;
    private Rigidbody rBody;
    void Start()
    {
        count = 0;

        //handle to the rigidbody             
        rBody = GetComponent<Rigidbody>();

    }
    void FixedUpdate()
    {
        //A, D, or right arrow, left arrow
        float horizontalInput = Input.GetAxis("Horizontal");
        //W, S or up arrow, down arrow
        float verticalInput = Input.GetAxis("Vertical");

        rBody.AddForce(new Vector3(horizontalInput, 0, verticalInput) * speed);
    }
    void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.CompareTag("PickUp"))
        {
            Destroy(target.gameObject);
            Count();
        }
    }
    void Count()

    {
        count = count + 1;
        countText.text = "Count: " + count.ToString();
        if (count >= 4)
        {
            winText.text = "You Win";

        }
    }
}
