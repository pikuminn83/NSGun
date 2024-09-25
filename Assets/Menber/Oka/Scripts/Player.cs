using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    Rigidbody2D rb2;
    // InputActionAsset�ւ̎Q��
    [SerializeField] private GameObject player;
    [SerializeField] public Sprite NtoS;
    [SerializeField] public Sprite StoN;

    [SerializeField] private InputActionReference _moveAction;
    //���͒l��x���Wy���W�ɕ����Ċi�[����ϐ�
    float MoveX;
    float MoveY;
    //�e�𔭎˂���ʒu
    Vector3 bulletpoint;
    Vector3 razerpoint;
    //�e�̃I�u�W�F�N�g���A�^�b�`����ꏊ
    public GameObject Bullet;
    //���P�b�g�̃I�u�W�F�N�g���A�^�b�`����ꏊ
    public GameObject Rocket;
    //���[���K���̃I�u�W�F�N�g���A�^�b�`����ꏊ
    public GameObject RailGun;
    //���ꎥ�΂̃I�u�W�F�N�g���A�^�b�`����ꏊ
    public GameObject UniqueMagnet;
    public Image gage;
    public bool Nflag;
    public bool Sflag;
    UniqueMagnet um;
    public GameObject skillmanager;
    SkillChoose sc;
    GameObject Enemy;
    Transform tf;
    //float tfz = 0;
    SpriteRenderer sprite;
    public bool RailGunFlag;




    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        gage.GetComponent<MagneticGage>();
        um = UniqueMagnet.GetComponent<UniqueMagnet>();
        sc = skillmanager.GetComponent<SkillChoose>();
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        tf = GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();

    }

    public void RailChange_To_N(InputAction.CallbackContext context)
    {
        if (RailGunFlag == false)
        {
            if (context.performed)
            {
                if (gage.fillAmount >= 0.09f && Nflag == false)
                {
                    rb2.gravityScale = -3.0f;
                    gage.fillAmount -= 0.05f;
                    tf.eulerAngles = Vector3.zero;
                    var spriteRenderer = player.GetComponent<SpriteRenderer>();
                    spriteRenderer.sprite = StoN;
                    sprite.flipY = false;

                }
            }
        }
    }
    public void RailChange_To_S(InputAction.CallbackContext context)
    {
        if (RailGunFlag == false)
        {
            if (context.performed)
            {
                if (gage.fillAmount >= 0.09f && Sflag == false)
                {
                    rb2.gravityScale = +3.0f;
                    gage.fillAmount -= 0.05f;
                    var spriteRenderer = player.GetComponent<SpriteRenderer>();
                    spriteRenderer.sprite = NtoS;
                    sprite.flipY = true;

                }
            }
        }
    }
    //public void ZeroGravity(InputAction.CallbackContext context)
    //{
    //    if (context.phase == InputActionPhase.Performed)
    //    {
    //        if(gage.fillAmount >0.1f)
    //        {
    //            rb2.gravityScale = 0.0f;
    //        }
    //    }
    //}



    // �R�[���o�b�N�̓o�^�E����
    private void Awake()
    {
        // ���͒l��0�ȊO�̒l�ɕω������Ƃ��ɌĂяo�����R�[���o�b�N
        _moveAction.action.performed += OnMove;

        // ���͒l��0�ɖ߂����Ƃ��ɌĂяo�����R�[���o�b�N
        _moveAction.action.canceled += OnMove;
    }

    private void OnDestroy()
    {
        _moveAction.action.performed -= OnMove;
        _moveAction.action.canceled -= OnMove;
    }

    // InputAction�̗L�����E������
    private void OnEnable() => _moveAction.action.Enable();
    private void OnDisable() => _moveAction.action.Disable();

    // �R�[���o�b�N�̎���
    private void OnMove(InputAction.CallbackContext context)
    {
        // 2�����͂��󂯎��
        var move = context.ReadValue<Vector2>();



        MoveX = move.x;
        MoveY = move.y;
        //�L�����N�^�[�ɍ��킹��Flip������
        //if(move.x < 0)
        //{
        //    sprite.flipX = true;
        //}
        //else
        //{
        //    sprite.flipX = false;
        //}


    }
    private void FixedUpdate()
    {


        Vector2 pos = transform.position;
        pos.x += MoveX / 10;

        if (rb2.gravityScale == 0)
        {
            pos.y += MoveY / 10;
        }
        transform.position = pos;
        


    }
    public void Atack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (gage.fillAmount >= 0.05f)
            {
                float a = 0;
                for (int i = 0; i < 3; i++)
                {
                    Invoke("Shot", 0 + a);
                    a += 0.1f;
                }
                gage.fillAmount -= 0.05f;
            }
        }

    }
    public void Shot()
    {
        bulletpoint = transform.Find("Bulletpoint").localPosition;
        Instantiate(Bullet, transform.position + bulletpoint, Quaternion.identity);
    }
    public void SpecialAtack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (gage.fillAmount >= 0.05f)
            {
                bulletpoint = transform.Find("Bulletpoint").localPosition;
                Instantiate(Rocket, transform.position + bulletpoint, Quaternion.identity);
                gage.fillAmount -= 0.05f;
            }
        }
    }
    public void Railgun()
    {
        razerpoint = transform.Find("Razerpoint").localPosition;
        GameObject childObject = Instantiate(RailGun, transform.position + razerpoint + new Vector3(7.5f, 0, 0), Quaternion.identity);
        childObject.transform.parent = this.transform;
    }
    public void Uniquemagnet()
    {
        bulletpoint = transform.Find("Bulletpoint").localPosition;
        Instantiate(UniqueMagnet, transform.position + bulletpoint, Quaternion.identity);


    }

    


}

