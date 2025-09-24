using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public static PlayerInteraction instance;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private Vector3 lastpos;
    [SerializeField] private float rayDistance;
    public GameObject[] stationsObject;
    public bool isInteracting;

    void Awake()
    {
        instance = this;
        isInteracting = false;
    }
    void Update()
    {
        if (isInteracting) return;
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            lastpos = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, lastpos, rayDistance, interactableLayer);
        Debug.DrawRay(transform.position, lastpos * rayDistance, Color.red);
        if (hit.collider != null && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("hit " + hit.collider.gameObject.name);
            switch (hit.collider.gameObject.name)
            {
                case "BabyCrib":
                    // get baby data.
                    break;
                case "Milk Station":
                    stationsObject[0].SetActive(true);
                    startInteraction();
                    break;
                case "Diaper Station":
                    stationsObject[1].SetActive(true);
                    startInteraction();
                    break;
                case "Bathing Station":
                    stationsObject[2].SetActive(true);
                    startInteraction();
                    break;
            }
        }
    }

    public void startInteraction()
    {
        GetComponent<Collider2D>().enabled = false;
        isInteracting = true;
    }

    public void StopInteraction()
    {
        GetComponent<Collider2D>().enabled = true;
        isInteracting = false;
    }   
}
