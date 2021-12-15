using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    /// <summary>
    /// Длина уровня
    /// </summary>
    private float lengthLvlZ, lengthLvlX;

    [SerializeField] private Register register;
    [SerializeField] private GameObject ground;
    

    void Start()
    {
        register = GetComponentInChildren<Register>();
        var bounds = GetComponent<Collider>().bounds;
        lengthLvlZ = bounds.size.z;
        lengthLvlX = bounds.size.x;
        register.OnRegistre += GenerateActiveted;
    }

    public void GenerateActiveted()
    {
        if (register.index == 0)
        {
            Vector3 placeGenertionZ = new Vector3(transform.position.x, transform.position.y, transform.position.z + lengthLvlZ - 0.03f);
            ground = Instantiate(ground, placeGenertionZ, Quaternion.identity);
        }
        if (register.index == 1)
        {
            Vector3 placeGenertionX = new Vector3(transform.position.x + lengthLvlX - 0.03f, transform.position.y, transform.position.z);
            ground = Instantiate(ground, placeGenertionX, Quaternion.identity);
        }
    }
}
