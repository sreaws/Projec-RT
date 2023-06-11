using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleControllerP2 : MonoBehaviour
{
    [SerializeField] private CharacterController2D controller;
    [SerializeField] private GameObject player;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;

    [SerializeField] private MassProduceP2 MassProduce;
    private Rigidbody2D m_Rigidbody2D;
    private Vector3 m_Velocity = Vector3.zero;
    public bool isRun = false;


    private void Start()
    {
        Physics2D.IgnoreCollision(player.GetComponent<CircleCollider2D>(), GetComponent<CircleCollider2D>());
    }
    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        if (!isRun)
        {
            Chill();
        }

        isRun = false;
        
    }

    public void Move(Vector2 move, bool isSlow = false)
    {
        float smoothing = m_MovementSmoothing;
        Vector3 targetVelocity = new Vector2(move.x * 100f, move.y * 100f);

        if (isSlow)
        {
             smoothing = m_MovementSmoothing * 2f;
        }
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, smoothing);
    }

    private void Chill()
    {
        Vector3 targetVelocity = new Vector2(0, 0);
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing*2f);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            controller.IncreaseScoreBy1();
            MassProduce.DecreaseCollectibleCount();

        }
    }


}


