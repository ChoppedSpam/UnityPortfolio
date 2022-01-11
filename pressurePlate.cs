using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressurePlate : MonoBehaviour
{
    public GameObject example;
    public Animator anim;

    List<GameObject> boxCount = new List<GameObject>();

    void Start()
    {
        example.SetActive(true);
    }

    private void Update()
    {
        if (boxCount.Count > 0)
        {
            example.SetActive(false);
            anim.Play("goDown");
        }

        if (boxCount.Count == 0)
        {
            example.SetActive(true);
            anim.Play("goUp");
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        boxCount.Add(other.gameObject);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        boxCount.Remove(other.gameObject);
    }

}
