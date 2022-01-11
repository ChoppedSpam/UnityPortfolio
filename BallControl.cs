using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Link to Demo Vid : https://drive.google.com/file/d/17Bc7UOwBQ47Be8MAdGUKdln4xXZvUlDc/view

public class BallControl : MonoBehaviour
{
    public float power = 10f;
    public float maxDrag = 5f;
    public Rigidbody2D rb;
    public LineRenderer lr;
    public bool IsHolding;
    public GameObject player;

    Vector3 dragStartpos;
    //Vector3 Posi;
    Touch touch;

    private void Start()
    {
        player.GetComponent<KeyboardMovement>().enabled = true;
        //Posi = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        if (Input.touchCount > 1)
        { 
            if (IsHolding == true)
            {
                touch = Input.GetTouch(1); 

                if (touch.phase == TouchPhase.Began)
                {
                    DragStart();
                }
                if (touch.phase == TouchPhase.Moved)
                {
                    Dragging();

                }
                if (touch.phase == TouchPhase.Ended)
                {
                    this.GetComponent<PlayerMovement>().enabled = false;
                    DragRelease();
                }
            }
        }
    }
    void DragStart()
    {
        dragStartpos = Camera.main.ScreenToWorldPoint(touch.position);
        dragStartpos.z = 0f;
        lr.positionCount = 1;
        lr.SetPosition(0, dragStartpos);
    }
    void Dragging()
    {
        player.GetComponent<KeyboardMovement>().enabled = false;
        Vector3 draggingPos = Camera.main.ScreenToWorldPoint(touch.position);
        draggingPos.z = 0f;
        lr.positionCount = 2;
        lr.SetPosition(1, draggingPos);
    }
    void DragRelease()
    {
        lr.positionCount = 0;
        Vector3 dragReleasePos = Camera.main.ScreenToWorldPoint(touch.position);
        dragReleasePos.z = 0f;

        Vector3 force = dragStartpos - dragReleasePos;
        Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;

        rb.AddForce(clampedForce, ForceMode2D.Impulse);
    }
}
