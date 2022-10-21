using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactor : MonoBehaviour
{

    Transform actorCamera;
    LayerMask layerMask;

    [SerializeField]
    private float maxDistFromCam = 10f;

    [SerializeField]
    private float maxIntDist = 3f;
    private float distFromActor;

    // Start is called before the first frame update
    void Start()
    {
        layerMask = gameObject.layer;
    }

    // Update is called once per frame
    void Update()
    {
        Interact();
    }

    public void Interact()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            actorCamera = Camera.main.transform;
            Debug.Log("Live Camera " + actorCamera.name);

            Ray ray = new Ray(actorCamera.position, actorCamera.forward);

            if(Physics.Raycast(ray, out RaycastHit raycastHit, maxDistFromCam, layerMask))
            {
                if(raycastHit.transform != null)
                {
                    distFromActor = Vector3.Distance(transform.position, raycastHit.transform.position);
                    if (distFromActor <= maxIntDist)
                    {
                        Debug.Log("In range " + raycastHit.transform.name + " (" + distFromActor.ToString("0.00") + " units)");
                        Item item = raycastHit.transform.GetComponent<Item>();
                        if(item != null)
                        {
                            item.Interact();
                        }
                    }
                }//raycasthit
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxIntDist);
    }


}
