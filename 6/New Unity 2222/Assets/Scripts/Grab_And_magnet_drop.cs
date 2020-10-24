using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab_And_magnet_drop : MonoBehaviour
{
    GameObject grabbedObject;
    float grabbedObjectSize;
    float magnetMultiplayer = 1.0f;
    

    GameObject  GetMouseHoverObject(float range)
        //find object to grab by mouse position
    {
        RaycastHit raycastHit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit))
            return raycastHit.collider.gameObject;
        return null;
    }

    void TryGrabObject(GameObject grabObject)
        //if it possible grab object
    {
        if (grabObject == null || !grabObject.CompareTag("Moveable"))
            return;
        grabbedObject = grabObject;
        grabbedObjectSize = grabObject.GetComponent<Renderer>().bounds.size.magnitude;
    }
    
    void DropObject()
        //if it needed drop object
    {
        if (grabbedObject == null)
            return;
        grabbedObject = null;
    }

    Vector3 SearchBase(Vector3 center, float radius)
        //search point to magnet grabbed object
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        //find object around
        Vector3 nearest_top_point = center;
        float shortest_distance = radius;
        
        foreach (var hitCollider in hitColliders)
            //find nearest point
        {
            if (hitCollider == grabbedObject.GetComponent<Collider>()) { continue; }
            if (((hitCollider.bounds.center + new Vector3(0, hitCollider.bounds.extents.y, 0)) - center).magnitude < shortest_distance)
            {
                nearest_top_point = hitCollider.bounds.center + new Vector3(0, hitCollider.bounds.extents.y, 0);
                shortest_distance = ((hitCollider.bounds.center + new Vector3(0, hitCollider.bounds.extents.y, 0)) - center).magnitude;
            }
        }
        return nearest_top_point;
    }
    

    void Update()
    {
           if (Input.GetMouseButtonDown(0))
            //LMB - grab object
           {
            if (grabbedObject == null)
                TryGrabObject(GetMouseHoverObject(15));
            else
                //LMA again - drop object
                DropObject();
           }

           if (grabbedObject != null)
            //update grabbed objetc position
           {
            grabbedObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1)) + Camera.main.transform.forward * grabbedObjectSize;
            grabbedObject.transform.position = SearchBase(grabbedObject.transform.position, grabbedObjectSize * magnetMultiplayer);
           }
    }
}
