using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Interactables;


public class SocketTracker : MonoBehaviour
{
    public XRSocketInteractor socket;
    public GameObject target;
    //Receiver should be the gameobject witht he FNAK script
    public FNAK receiver;

    private bool isAttached;

    private void Start()
    {
        isAttached = false;
    }

    private void Update()
    {
        IXRSelectInteractable selected = socket.GetOldestInteractableSelected();

        isAttached = (selected.transform.gameObject == target);
        Debug.Log("Target not attached");

        if (isAttached)
        {
            afterAttach();
            Debug.Log("Target attached");
        } else
        {
            afterDettach();
        }

    }

    private void afterAttach()
    {
        //Can add a way to alert the user like a sound or a UI elemeent
        if (receiver != null)
        {
            receiver.SetAttached(true);
        }

    }

    private void afterDettach()
    {
        if (receiver != null)
        {
            receiver.SetAttached(false);
        }
    }
}
