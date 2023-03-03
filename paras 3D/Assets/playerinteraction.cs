using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerinteraction : MonoBehaviour
{
    public float rayDistance;


    // Update is called once per frame

    private void Update()
        {
            // Kun pelaaja p�iv�� E n�pp�int�
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Tallennetaan osuma objekti t�h�n jos osutaan s�teell�
                RaycastHit hit;

            // ammutaan s�de pelaajan sijainnista, suoraan eteenp�in ja tallennetaan mahdollinen osuma
            if (Physics.Raycast(this.transform.position + transform.up * 0.5f, transform.forward * rayDistance, out hit))
                {
                    // Kirjoitetaan consoleen tieto siit� mihin osuttiin
                    Debug.Log("Osuttiin objektiin: " + hit.transform.name);

                    // ESIM: Jos osuma objektissa Rigidbody komponentti
                    if (hit.transform.GetComponent<Rigidbody>())
                    {
                        // annetaan rigidbodylle johon osuttiin Forcea eteenp�in * 200 yksik�ll�
                        hit.transform.GetComponent<Rigidbody>().AddForce(transform.forward * 200);
                    }
                }
            }
        }
    


    private void OnTriggerEnter(Collider other)
    {
        //jos objwektiin johon t�rm�tiin sis�lt� skripitiin niin 
        if(other.GetComponent<onEnterInteractable>())
        {   //toteutaa objektin onEnterInteraction toimino k�ynist�� eventin
            other.GetComponent<onEnterInteractable>().onEnterInteract();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //jos objwektiin johon t�rm�tiin sis�lt� skripitiin niin 
        if (other.GetComponent<onEnterInteractable>())
        {   //toteutaa objektin onExitInteraction toimino k�ynist�� eventin
            other.GetComponent<onEnterInteractable>().onExitInteract();
        }
    }
}
