using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rb2;
    // InputActionAsset�ւ̎Q��
    [SerializeField] private InputActionReference _moveAction;
    //���͒l��x���Wy���W�ɕ����Ċi�[����ϐ�
    float MoveX;
    float MoveY;
    //�e�𔭎˂���ʒu
    Vector3 bulletpoint;
    //�e�̃I�u�W�F�N�g���A�^�b�`����ꏊ
    public GameObject Bullet;
    //���P�b�g�̃I�u�W�F�N�g���A�^�b�`����ꏊ
    public GameObject Rocket;
    public Image gage;
    




    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        gage.GetComponent<MagneticGage>();

    }

    public void RailChange_To_N(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (gage.fillAmount >= 0.05f)
            {
                rb2.gravityScale = -3.0f;
                gage.fillAmount -= 0.05f;
            }
        }
    }
    public void RailChange_To_S(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (gage.fillAmount >= 0.05f)
            {
                rb2.gravityScale = +3.0f;
                gage.fillAmount -= 0.05f;
            }
        }
    }
    public void Zerogravity (InputAction.CallbackContext context)
    {
        if(context.performed)
        {

           

            
            if (gage.fillAmount >= 0.1f)
            {

                rb2.gravityScale /=12.0f;
                gage.fillAmount -= 0.05f;
                Invoke("zero", 0.5f);
                
                
            }
        }
    }
    void zero()
    {
        Debug.Log("zero");
        rb2.gravityScale = 0.0f;
    }

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

        print($"move:{move}");

        MoveX = move.x;
        MoveY = move.y;

    }
    private void Update()
    {
        Vector2 pos = transform.position;
        pos.x += MoveX / 100;

        if (rb2.gravityScale == 0)
        {
            pos.y += MoveY / 100;
        }
        transform.position = pos;
        if (gage.fillAmount <= 0.03)
        {
            rb2.gravityScale = -3.0f;
        }
        Debug.Log(rb2.gravityScale);
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
}

