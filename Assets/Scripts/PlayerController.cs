using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    public float speed = 0;
    private float movementX;
    private float movementY;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject retryTextObject;
    public float jumpForce = 5f;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();

        }

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        winTextObject.SetActive(false);
        retryTextObject.SetActive(false);
        count = 0;
        rb = GetComponent<Rigidbody>();
        SetCountText();
    }

    // Update is called once per frame
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 13)
        {
            winTextObject.SetActive(true);
            retryTextObject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }

    void OnJump()
    {
        if (IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    bool IsGrounded()
    {
        float sphereRadius = GetComponent<SphereCollider>().radius;
        Vector3 checkPosition = rb.position + Vector3.down * (sphereRadius + 0.05f);
        return Physics.CheckSphere(checkPosition, groundCheckRadius, groundLayer);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the current object
            Destroy(gameObject);
            // Update the winText to display "You Lose!"
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
            retryTextObject.SetActive(true);
    }
    }
}

