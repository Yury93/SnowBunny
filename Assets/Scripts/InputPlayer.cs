using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Готовый скрипт zigzag для анимированого персонажа
/// </summary>
public class InputPlayer : MonoBehaviour
{
    [SerializeField] private float speedUp, timerSpeed, startTimer;
    
    public float SpeedUp => speedUp;
    private Animator anim;
    public Animator Anim => anim;
    [SerializeField]private LayerMask layerMask;

    public delegate void DelegateDeath();
    public event DelegateDeath OnDeath;
    public enum Direction
    {
        right,
        left
    }
    Direction dir;

    private void Start()
    {
        //StartCoroutine(cor());
        startTimer = timerSpeed;
        anim = GetComponent<Animator>();
        TapToScreen.Instance.OnTap += InputKey;
    }
    private void Update()
    {
        timerSpeed -= Time.deltaTime;
        if (timerSpeed < 0)
        {
            anim.speed += speedUp;
            timerSpeed = startTimer;
        }

        if (Physics.OverlapSphere(transform.position, 0.1f, layerMask).Length == 0)
        {
            Debug.Log("DEATH ");
            OnDeath();
            //SceneManager.LoadScene(0);
        }
    }
    IEnumerator cor()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            go.transform.localScale *= 1;
            go.transform.position = transform.position;
        }
    }
    private void InputKey()
    {
        if (dir == Direction.right && transform.eulerAngles.y <= 0f)
        {
            transform.eulerAngles += new Vector3(0, 90f, 0);
            print("Right");
            TapToScreen.Instance.OnTap += InputState;
        }
        else
        {
            dir = Direction.left;
            print("Left");
        }
        if (dir == Direction.left && transform.eulerAngles.y <= 90f)
        {
            transform.eulerAngles += new Vector3(0, -90f, 0);
            print("Left");
            TapToScreen.Instance.OnTap += InputState;
        }
    }

    private void InputState()
    {
        if (dir == Direction.right)
        {
            dir = Direction.left;
        }
        else if (dir == Direction.left)
        {
            dir = Direction.right;
        }
    }
}
