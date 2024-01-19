using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class CharacterController : Singleton<CharacterController>
{
    [SerializeField]
    private float moveSpeed = 3f;

    private Rigidbody2D rig;
    private CapsuleCollider2D col;
    private Animator anim;

    private float h, v;
    private bool isHorizonMove;
    private Vector3 dir;


    private TownManager town;

    private GameObject obj;
    private GameObject scanObj;
    public GameObject SCANOBJ
    {
        get => scanObj;
    }



    private void Awake()
    {
        town = GameObject.Find("TownManager").GetComponent<TownManager>();
        rig = GetComponent<Rigidbody2D>();
        rig.GetComponent<Rigidbody2D>().gravityScale = 0f;
        col = GetComponent<CapsuleCollider2D>();
        if(!TryGetComponent<Animator>(out anim))
        {
            Debug.Log("CharacterController.cs - Awake() - anim 참조 실패");
        }

        obj = GameObject.Find("text");
    }

    // Update is called once per frame
    void Update()
    {
        UserInput();
        UserAction();
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


        // Raycast 방향 전환
        if (v == 1)
        {
            dir = Vector3.up;
        }
        else if (v == -1)
        {
            dir = Vector3.down;
        }
        else if (h == -1)
        {
            dir = Vector3.left;
        }
        else if (h == 1)
        {
            dir = Vector3.right;
        }




    }



    

    private void UserAction()
    {
        // ScanObject
        if (Input.GetKeyDown(KeyCode.G) && scanObj != null)
        {
            Interaction.Inst.Closed();

            // 집으로 가는 액션
            if(scanObj.name == "House")
            {
                GameManager.Inst.AsyncLoadingNextScene(SceneName.HomeScene);
            }
            else if(scanObj.name == "Water")
            {
                PlayerAction.Inst.Action();
            }

            else if(scanObj.name == "Tree")
            {
                PlayerAction.Inst.Action();
            }
            else if(scanObj.name == "Flower")
            {
                PlayerAction.Inst.Action();
            }
        }
    }

    

    private void FixedUpdate()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v); // 대각선 이동 방지
        rig.velocity = moveVec * moveSpeed;


        // RayCast로 object 감지
        Debug.DrawRay(rig.position, dir * 0.7f, new Color(0, 1, 0));
        // Object Layer 외에 감지 안함
        RaycastHit2D rayHit = Physics2D.Raycast(rig.position, dir, 0.7f, LayerMask.GetMask("Object"));

        if(rayHit.collider != null)
        {
            scanObj = rayHit.collider.gameObject;
        }
        else
        {
            scanObj = null;
        }

    }
}
