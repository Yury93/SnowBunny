using UnityEngine;

public class Bonus : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Instance.ScoreAdd();
            gameObject.SetActive(false);
        }
    }
}
