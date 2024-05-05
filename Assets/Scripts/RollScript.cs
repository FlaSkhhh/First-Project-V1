using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollScript : MonoBehaviour
{
    public Camera cam;
    private Vector3 offset;
    public CharacterController controller;
    public void Invincible()
    {
        GetComponentInParent<PlayerHealth>().enabled = false;
        offset = new Vector3(cam.transform.position.x,cam.transform.position.y-0.7f,cam.transform.position.z);
        cam.transform.position = offset;
        //Vector3 move = cam.transform.right;
        //controller.Move(move * 2f);
    }

    public void Vincible()
    {
        GetComponentInParent<PlayerHealth>().enabled = true;
        offset = new Vector3(cam.transform.position.x, cam.transform.position.y + 0.7f, cam.transform.position.z);
        cam.transform.position = offset;
        GetComponentInParent<PlayerMovement>().isRolling = false;
    }
}
