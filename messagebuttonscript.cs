using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class messagebuttonscript : MonoBehaviour
{

    public Rigidbody2D rb;
    public Vector2 phonePosition;
    public Vector2 upPosition;
    bool mouseClicked = false;
    bool up = false;
    thingDoer thingdoer;
    public Vector2 startPos = new Vector2(0.17f, -3.58f);
    public GameObject[] textphase;
    public GameObject blocker1;
    public GameObject blocker2;
    public GameObject nextPhase;

    private void Start()
    {
        thingdoer = GameObject.Find("thingDoerr").GetComponent<thingDoer>();
    }

    private void OnMouseDown()
    {
        if (gameObject.tag != "sent")
        {
            thingdoer.messages.Add(gameObject.GetComponent<Rigidbody2D>());
            thingdoer.mesPos.Add(new Vector2(startPos.x, startPos.y + (1.1f * thingdoer.messages.Count)));
        }

        StartCoroutine(Waiterrr());

        mouseClicked = true;
    }

    void Update()
    {
        if (mouseClicked == true)
        {
            StartCoroutine(Waiterr());
        }
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(0.5f);
        mouseClicked = false;
    }

    IEnumerator Waiterr()
    {
        yield return new WaitForSeconds(0.002f);
        gameObject.tag = "sent";
    }

    IEnumerator Waiterrr()
    {
        yield return new WaitForSeconds(0.45f);
        foreach (GameObject msg in textphase)
        {
            if (msg.tag != "sent")
            {
                msg.SetActive(false);
                Debug.Log("TRUE");
            }
        }

        blocker1.SetActive(true);
        blocker2.SetActive(false);

        nextPhase.SetActive(true);
    }
}