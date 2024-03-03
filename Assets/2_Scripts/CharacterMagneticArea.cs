using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMagneticArea : MonoBehaviour
{
    public List<Transform> ObjectsInsideSphere;
    private void OnTriggerEnter(Collider other)
    {
        ObjectsInsideSphere.Add(other.transform);
    }
    private void OnTriggerExit(Collider other)
    {
        ObjectsInsideSphere.Remove(other.transform);
    }
    public Transform GetClosestObject()
    {
        if (ObjectsInsideSphere.Count == 0) return null;

        float minDistance = 1000f;
        Transform closestObject = null;
        foreach (var magneticObject in ObjectsInsideSphere)
        {
            float distance = Vector3.Distance(magneticObject.position, transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestObject = magneticObject;
            }
        }

        return closestObject;
    }
}
