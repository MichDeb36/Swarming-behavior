using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 12f;
    private CharacterController controller;
    private bool canMove = true;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    public void SetPlayerMove(bool move)
    {
        canMove = move;
    }
    void movePlayer()
    {
        if(canMove)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * speed * Time.deltaTime);
        }
        
    }
    void Update()
    {
        movePlayer();
    }
}
