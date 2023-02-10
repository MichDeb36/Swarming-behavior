using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlPanel : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private GameObject panelStartInfo;
    [SerializeField] private GameObject panelInfo;
    [SerializeField] private GameObject itemToControl;
    [SerializeField] private float speed = 1.0f;

    private bool _isWithinRange = false;
    private bool canMove = false;
    private Vector3 startPlayerPosition;
    private float valuePlayerUp = 2.0f;

    void moveItem()
    {
        if (canMove)
        {
            float x = Input.GetAxis("Horizontal");
            itemToControl.transform.Rotate(Vector3.up * x * speed * Time.deltaTime);
        }
    }

    void movePlayerUp()
    {
        startPlayerPosition = player.transform.position;
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + valuePlayerUp, player.transform.position.z);
    }

    void CheckingIfPlayerIsWithinRange()
    {
        if (_isWithinRange && Input.GetKeyDown(KeyCode.E) && !canMove)
        {
            panelStartInfo.SetActive(false);
            panelInfo.SetActive(true);
            player.SetPlayerMove(false);
            canMove = true;
            movePlayerUp();
        }
        else if (_isWithinRange && Input.GetKeyDown(KeyCode.Escape) && canMove)
        {
            panelStartInfo.SetActive(true);
            panelInfo.SetActive(false);
            player.SetPlayerMove(true);
            canMove = false;
            player.transform.position = startPlayerPosition;
        }
    }

    void Update()
    {
        CheckingIfPlayerIsWithinRange();
        moveItem();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _isWithinRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _isWithinRange = false;
        }
    }
}
