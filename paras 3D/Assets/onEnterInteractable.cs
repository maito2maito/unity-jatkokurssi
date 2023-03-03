using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;//vaaditaan eventin toimimiseen 

public class onEnterInteractable : MonoBehaviour
{
    public UnityEvent onEnterEvents;
    public UnityEvent onExitEvents;

    public void onEnterInteract()
    {   //k‰ynist‰‰ on entereventin
     onEnterEvents.Invoke();
    }


    public void onExitInteract()
    {   //k‰ynist‰‰ onExitInteract eventin 
        onExitEvents.Invoke(); 
    }


}
