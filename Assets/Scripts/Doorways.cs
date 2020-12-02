using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Doorways : MonoBehaviour
{
    public GameObject doorways;
    // Start is called before the first frame update
    void Start()
    {
        doorways = GameObject.FindGameObjectWithTag("Doorways");
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        doorways.SetActive(false);
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        doorways.SetActive(true);
    }
}
