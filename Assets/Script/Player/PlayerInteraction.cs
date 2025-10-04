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

    private StationUIHandler lastStation;

    // Baby being Held

    public Baby babyBeingHeld;

    void Awake()
    {
        instance = this;
        isInteracting = false;
    }

    void Start()
    {
        babyBeingHeld = null;
    }
    void Update()
    {
        if (isInteracting) return;
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            lastpos = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        }
        RaycastHit2D hit = Physics2D.Raycast(transform.position, lastpos, rayDistance, interactableLayer);
        // Debug.DrawRay(transform.position, lastpos * rayDistance, Color.red);
        if (hit.collider != null)
        {
            StationUIHandler station = hit.collider.GetComponent<StationUIHandler>();
            if (station != null)
            {
                station.ShowUI();
                lastStation = station;
            }
        }
        else
        {
            if (lastStation != null)
            {
                lastStation.HideUI();
                lastStation = null;
            }
        }
        if (hit.collider != null && Input.GetKeyDown(KeyCode.E))
            {
                // Debug.Log("hit " + hit.collider.gameObject.name);
                switch (hit.collider.gameObject.name)
                {
                    case "BabyCrib":
                        // Debug.Log("current baby being held : " + babyBeingHeld);
                        if (babyBeingHeld == null)
                        {
                            if (hit.collider.GetComponent<BabyCrib>().currentBaby.currentNeed != Baby.BabyNeeds.None)
                            {
                                babyBeingHeld = hit.collider.GetComponent<BabyCrib>().GiveBaby();
                            }
                            else
                            {
                                // Debug.Log("Baby has no needs");
                            }
                        }
                        else
                        {
                            hit.collider.GetComponent<BabyCrib>().AcceptBaby(babyBeingHeld);
                            // Debug.Log("Baby returned to crib");
                            babyBeingHeld = null;
                        }
                        break;
                    case "Milk Station":
                        if(babyBeingHeld != null && babyBeingHeld.currentNeed == Baby.BabyNeeds.Milk)
                        {
                            stationsObject[0].SetActive(true);
                            startInteraction();
                        }
                        else
                        {
                            // Debug.Log("No baby being held or baby does not need milk");
                            return;
                        }
                        break;
                    case "Diaper Station":
                        if (babyBeingHeld != null && babyBeingHeld.currentNeed == Baby.BabyNeeds.Diaper)
                        {
                            stationsObject[1].SetActive(true);
                            startInteraction();
                        }
                        else
                        {
                            // Debug.Log("No baby being held or baby does not need diaper change");
                            return;
                        }
                        break;
                    case "Bathing Station":
                        if (babyBeingHeld != null && babyBeingHeld.currentNeed == Baby.BabyNeeds.Bath)
                        {
                            stationsObject[2].SetActive(true);
                            startInteraction();
                        }
                        else
                        {
                            // Debug.Log("No baby being held or baby does not need bath");
                            return;
                        }
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
