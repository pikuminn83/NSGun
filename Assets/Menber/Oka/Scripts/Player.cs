using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;
using static UnityEditor.PlayerSettings;

public class Player : MonoBehaviour
{
    Rigidbody2D rb2;
    // InputActionAssetへの参照
    [SerializeField] private InputActionReference _moveAction;
    //入力値をx座標y座標に分けて格納する変数
    float MoveX;
    float MoveY;
    //弾を発射する位置
    Vector3 bulletpoint;
    //弾のオブジェクトをアタッチする場所
    public GameObject Bullet;
    //ロケットのオブジェクトをアタッチする場所
    public GameObject Rocket;
    public Image gage;
    public bool Nflag;
    public bool Sflag;
    
    




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
            if (gage.fillAmount >= 0.09f&&Nflag==false)
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
            if (gage.fillAmount >= 0.09f&&Sflag == false)
            {
                rb2.gravityScale = +3.0f;
                gage.fillAmount -= 0.05f;
            }
        }
    }
    
    

    // コールバックの登録・解除
    private void Awake()
    {
        // 入力値が0以外の値に変化したときに呼び出されるコールバック
        _moveAction.action.performed += OnMove;

        // 入力値が0に戻ったときに呼び出されるコールバック
        _moveAction.action.canceled += OnMove;
    }

    private void OnDestroy()
    {
        _moveAction.action.performed -= OnMove;
        _moveAction.action.canceled -= OnMove;
    }

    // InputActionの有効化・無効化
    private void OnEnable() => _moveAction.action.Enable();
    private void OnDisable() => _moveAction.action.Disable();

    // コールバックの実装
    private void OnMove(InputAction.CallbackContext context)
    {
        // 2軸入力を受け取る
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
            if (pos.y > -0.75)
            {
                rb2.gravityScale = -3.0f;
            }
            if (pos.y < -0.75)
            {
                rb2.gravityScale = 3.0f;
            }
        }
      
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

