using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundOff : MonoBehaviour
{
    private void Start()
    {
        var player = GetComponent<InputPlayer>();
        player.OnDeath += Player_OnDeath;
    }

    private void Player_OnDeath()
    {
        StartCoroutine(CorDeath());
    }
    IEnumerator CorDeath()
    {
        yield return new WaitForSeconds(0);
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
