using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3f;

    private Rigidbody2D rig;
    private CapsuleCollider2D col;
    private Animator anim;

    private float h, v;
    private bool isHorizonMove;
    private Vector3 dir;
    
    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.GetComponent<Rigidbody2D>().gravityScale = 0f;
        col = GetComponent<CapsuleCollider2D>();
        if(!TryGetComponent<Animator>(out anim))
        {
            Debug.Log("CharacterController.cs - Awake() - anim 참조 실패");
        }
    }

    // Update is called once per frame
    void Update()
    {
        UserInput();

    }

    private void UserInput()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");


        bool right = Input.GetButtonUp("Horizontal");
        bool left = Input.GetButtonDown("Horizontal");
        bool up = Input.GetButtonUp("Vertical");
        bool down = Input.GetButtonDown("Vertical");

        if (left)
        {
            isHorizonMove = true;
        }
        else if (down)
        {
            isHorizonMove = false;
        }
        else if (up || right)
        {
            isHorizonMove = h != 0;
        }

        // 애니메이션
        if(anim.GetInteger("hAxisRaw") != h)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if(anim.GetInteger("vAxisRaw") != v)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else
        {
            anim.SetBool("isChange", false);
        }

        if (down && v == 1)
        {
            dir = Vector3.up;
            Debug.Log("1");
        }
        else if (down && v == -1)
        {
            dir = Vector3.down;
            Debug.Log("2");
        }
        else if (left && h == -1)
        {
            dir = Vector3.left;
            Debug.Log("3");
        }
        else if (left && h == 1)
        {
            dir = Vector3.right;
            Debug.Log("4");
        }

    }

    private void FixedUpdate()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v); // 대각선 이동 방지
        rig.velocity = moveVec * moveSpeed;

        Debug.DrawRay(rig.position, dir * 0.7f, new Color(0, 1, 0));

    }
}
