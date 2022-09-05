using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private CharacterController player;

    private float m_Speed = 5f; //Defalut Speed

    bool m_isJumped;

    private bool isJumped => Input.GetKey(KeyCode.Space);


    private void Update()
    {
        Jump();

        Move();
    }

    Vector3 moveDir;
    /// <summary>
    /// 플레이어 움직임
    /// </summary>
    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (player.isGrounded)
        {
            moveDir.y = 0f;
        }
        else
        {
            moveDir.y -= Time.deltaTime * 9.8f;
        }

        moveDir = new Vector3(h * m_Speed, moveDir.y, v * m_Speed);

        moveDir = transform.TransformDirection(moveDir);

        player.Move(moveDir * Time.deltaTime);
    }

    private void Jump()
    {
        if (isJumped)
        {
            moveDir.y = 5f;
        }
    }
}
