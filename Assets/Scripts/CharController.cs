using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    
    public Transform rayStart;
    public GameObject crystalEffect;

    private Animator anim;
    private Rigidbody rb;
    private bool walkingRight = true;
    private GameManager gameManager;
    

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
        if (!gameManager.gameStarted)
            return;
        else
        {
            anim.SetTrigger("gameStarted");
        }
        rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Switch();
        }

        UnderChecking();

        gameManager.EndGame(transform);
    }

    private void UnderChecking()
    {
        RaycastHit hit;

        if (!Physics.Raycast(rayStart.position, -transform.up, out hit, Mathf.Infinity))
        {
            anim.SetTrigger("isFalling");
        }
        else
        {
            anim.SetTrigger("notFallingAnymore");
        }
    }

    private void Switch()
    {
        if (!gameManager.gameStarted)
        {
            return;
        }
        walkingRight = !walkingRight;

        if (walkingRight)
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Crystal")
        {
            gameManager.ScoreIncrease();
            GameObject g = Instantiate(crystalEffect, rayStart.transform.position, Quaternion.identity);
            Destroy(g, 2f);
            Destroy(other.gameObject);
        }
    }
}
