using System;
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
    public bool isGameOver;

    private StationUIHandler lastStation;

    // Baby being Held

    public Baby babyBeingHeld;
    // new boolean flag to indicate whether player is carrying a baby
    public bool isCarryingBaby;

    void Awake()
    {
        instance = this;
        isInteracting = false;
        isGameOver = false;
    }

    void Start()
    {
        babyBeingHeld = null;
        isCarryingBaby = false;
    }
    void Update()
    {
        if (isInteracting || isGameOver) return;
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
            Debug.Log("Interacting with " + hit.collider.gameObject.name);
            switch (hit.collider.gameObject.name)
            {
                case "BabyCrib":
                    // Debug.Log("current baby being held : " + babyBeingHeld);
                    if (!isCarryingBaby)
                    {
                        if (hit.collider.GetComponent<BabyCrib>().currentBaby.currentNeed != Baby.BabyNeeds.None)
                        {
                            try
                            {
                                babyBeingHeld = hit.collider.GetComponent<BabyCrib>().GiveBaby();
                                isCarryingBaby = babyBeingHeld != null;
                            }
                            catch (NullReferenceException)
                            {
                                Debug.Log("where da baby go bro");
                            }
                        }
                        else
                        {
                            // Debug.Log("Baby has no needs");
                        }
                    }
                    else
                    {
                        // if (babyBeingHeld.currentNeed != Baby.BabyNeeds.None) return;
                        if (hit.collider.GetComponent<BabyCrib>().currentBaby != null) return;
                        hit.collider.GetComponent<BabyCrib>().AcceptBaby(babyBeingHeld);
                        Debug.Log("Baby returned to crib");
                    }
                    break;
                case "Milk Station":
                    if (isCarryingBaby && babyBeingHeld.currentNeed == Baby.BabyNeeds.Milk)
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
                    if (isCarryingBaby && babyBeingHeld.currentNeed == Baby.BabyNeeds.Diaper)
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
                    if (isCarryingBaby && babyBeingHeld.currentNeed == Baby.BabyNeeds.Bath)
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

                case "Door":
                    Debug.Log("current baby being held : " + babyBeingHeld);
                    if (isCarryingBaby && babyBeingHeld.currentNeed == Baby.BabyNeeds.GoHome)
                    {
                        Debug.Log("sending baby home");
                        babyBeingHeld = null;
                        isCarryingBaby = false;
                    }
                    else if (!isCarryingBaby && DoorHandler.instance.currentBaby != null)
                    {
                        Debug.Log("taking baby from door");
                        babyBeingHeld = DoorHandler.instance.GiveBaby();
                        isCarryingBaby = babyBeingHeld != null;
                    }

                    if (EvaluationHandler.instance.CheckIfGameIsFinished())
                    {
                        isGameOver = true;
                        PlayerMovement.instance.canMove = false;
                        EvaluationHandler.instance.CalculateScore();
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
