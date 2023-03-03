using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerinteraction : MonoBehaviour
{
    public float rayDistance;


    // Update is called once per frame

    private void Update()
        {
            // Kun pelaaja päivää E näppäintä
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Tallennetaan osuma objekti tähän jos osutaan säteellä
                RaycastHit hit;

            // ammutaan säde pelaajan sijainnista, suoraan eteenpäin ja tallennetaan mahdollinen osuma
            if (Physics.Raycast(this.transform.position + transform.up * 0.5f, transform.forward * rayDistance, out hit))
                {
                    // Kirjoitetaan consoleen tieto siitä mihin osuttiin
                    Debug.Log("Osuttiin objektiin: " + hit.transform.name);

                    // ESIM: Jos osuma objektissa Rigidbody komponentti
                    if (hit.transform.GetComponent<Rigidbody>())
                    {
                        // annetaan rigidbodylle johon osuttiin Forcea eteenpäin * 200 yksiköllä
                        hit.transform.GetComponent<Rigidbody>().AddForce(transform.forward * 200);
                    }
                }
            }
        }
    


    private void OnTriggerEnter(Collider other)
    {
        //jos objwektiin johon törmätiin sisältä skripitiin niin 
        if(other.GetComponent<onEnterInteractable>())
        {   //toteutaa objektin onEnterInteraction toimino käynistää eventin
            other.GetComponent<onEnterInteractable>().onEnterInteract();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //jos objwektiin johon törmätiin sisältä skripitiin niin 
        if (other.GetComponent<onEnterInteractable>())
        {   //toteutaa objektin onExitInteraction toimino käynistää eventin
            other.GetComponent<onEnterInteractable>().onExitInteract();
        }
    }
}
