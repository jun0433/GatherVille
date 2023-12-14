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

    private float x, y;
    private bool isHorizonMove;
    
    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.GetComponent<Rigidbody2D>().gravityScale = 0f;
        col = GetComponent<CapsuleCollider2D>();
        /*if(!TryGetComponent<Animator>(out anim))
        {
            Debug.Log("CharacterController.cs - Awake() - anim 참조 실패");
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        UserInput();
    }

    private void UserInput()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");


        bool right = Input.GetKey(KeyCode.RightArrow);
        bool left = Input.GetKey(KeyCode.LeftArrow);
        bool up = Input.GetKey(KeyCode.UpArrow);
        bool down = Input.GetKey(KeyCode.DownArrow);

        if (right || left)
        {
            isHorizonMove = true;
        }
        else if (down || up)
        {
            isHorizonMove = false;
        }
    }

    private void FixedUpdate()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(x, 0) : new Vector2(0, y); // 대각선 이동 방지
        rig.velocity = moveVec * moveSpeed;
    }
}
