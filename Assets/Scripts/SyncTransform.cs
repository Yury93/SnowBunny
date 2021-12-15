using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncTransform : MonoBehaviour
{
    [SerializeField] private GameObject target;
    public GameObject Target => target;
    [SerializeField] private float posZ,posX;
    private void Update()
    {
        transform.position = new Vector3(target.transform.position.x- posX, transform.position.y, target.transform.position.z - posZ);
    }
    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }
}
