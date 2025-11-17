//using UnityEngine;


//public class SocketTracker : MonoBehaviour
//{
//    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket; // Drag your socket here
//    public GameObject target;         // Drag the specific object to track here

//    private void OnEnable()
//    {
//        socket.onSelectEntered.AddListener(OnObjectAttached);
//        socket.onSelectExited.AddListener(OnObjectDetached);
//    }

//    private void OnDisable()
//    {
//        socket.onSelectEntered.RemoveListener(OnObjectAttached);
//        socket.onSelectExited.RemoveListener(OnObjectDetached);
//    }

//    private void OnObjectAttached(UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable interactable)
//    {
//        if (interactable.gameObject == target)
//        {
//            Debug.Log($"{target.name} was attached!");
//            // Add any additional behavior here
//        }
//    }

//    private void OnObjectDetached(UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable interactable)
//    {
//        if (interactable.gameObject == target)
//        {
//            Debug.Log($"{target.name} was detached!");
//        }
//    }
//}
