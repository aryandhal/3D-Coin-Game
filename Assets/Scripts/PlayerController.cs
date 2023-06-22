using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public TextMeshProUGUI countText, winText;
    private Rigidbody rb;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
     float moveHorizontal = Input.GetAxis("Horizontal");
     float moveVertical   = Input.GetAxis("Vertical");

     Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
     rb.AddForce(movement * speed);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("coin"))
        {
           other.gameObject.SetActive(false); 
           count++;
           countText.text ="Count - " + count.ToString();
           if(count >= 6)
           winText.gameObject.SetActive(true);
        }
        
    }
}
