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
        m_isJumped = isJumped ? true : false;
        Jump();

        Move();
    }

    Vector3 moveDir;
    /// <summary>
    /// 플레이어 움직임
    /// </summary>
    private void Move()
    {

        float h = Input.GetAxis("Horizontal") * m_Speed * Time.deltaTime;
        float v = Input.GetAxis("Vertical") * m_Speed * Time.deltaTime;

        moveDir = transform.right * h + transform.forward * v;
        if (player.isGrounded)
        {
            moveDir.y = 0f;
        }
        else
        {
            moveDir.y -= Time.deltaTime * -Physics.gravity.y;
        }


        player.Move(moveDir);
    }

    private void Jump()
    {
        if (player.isGrounded && m_isJumped)
        {
            print("Jumping");
            moveDir.y = Mathf.Lerp(0, 10f, Time.deltaTime);
        }
    }
}
