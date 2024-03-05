using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystemChecker : MonoBehaviour
{
    //public GameObject eventSystem;

	// Use this for initialization
	void Awake ()
	{
	    if(!FindObjectOfType<EventSystem>())
        {
           //Instantiate(eventSystem);
            GameObject obj = new GameObject("EventSystem");
            obj.AddComponent<EventSystem>();
#pragma warning disable CS0618 // O tipo ou membro � obsoleto
            obj.AddComponent<StandaloneInputModule>().forceModuleActive = true;
#pragma warning restore CS0618 // O tipo ou membro � obsoleto
        }
	}
}
