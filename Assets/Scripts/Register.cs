using System.Collections;
using UnityEngine;

public class Register : MonoBehaviour
{
    public delegate void RegisterOn();
    public event RegisterOn OnRegistre;
    public int index;
    //[SerializeField] private GameObject partical;
    [SerializeField] private GameObject goParent;
    private void Start()
    {
        //partical.transform.position = gameObject.transform.position;
        //partical.Stop();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            index = Random.Range(0, 2);
            OnRegistre();
            StartCoroutine(CorDestroyer());
        }
    }
    IEnumerator CorDestroyer()
    {
        //yield return new WaitForSeconds(2f);
        //partical.Play();
        yield return new WaitForSeconds(5f);
        Destroy(goParent);
    }
}
