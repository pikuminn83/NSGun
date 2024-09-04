using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;
using static UnityEditor.PlayerSettings;
using JetBrains.Annotations;

public class Player : MonoBehaviour
{
    
    Rigidbody2D rb2;
    // InputActionAssetへの参照
    [SerializeField] private GameObject player;
    [SerializeField] private Sprite NtoS;
    [SerializeField] private Sprite StoN;

    [SerializeField] private InputActionReference _moveAction;
    //入力値をx座標y座標に分けて格納する変数
    float MoveX;
    float MoveY;
    //弾を発射する位置
    Vector3 bulletpoint;
    Vector3 razerpoint;
    //弾のオブジェクトをアタッチする場所
    public GameObject Bullet;
    //ロケットのオブジェクトをアタッチする場所
    public GameObject Rocket;
    //レールガンのオブジェクトをアタッチする場所
    public GameObject RailGun;
    //特殊磁石のオブジェクトをアタッチする場所
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

        if (context.performed)
        {
            if (gage.fillAmount >= 0.09f&&Nflag==false)
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
    public void RailChange_To_S(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (gage.fillAmount >= 0.09f&&Sflag == false)
            {
                rb2.gravityScale = +3.0f;
                gage.fillAmount -= 0.05f;
                var spriteRenderer = player.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = NtoS;
                sprite.flipY = true;
                
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

        

        MoveX = move.x;
        MoveY = move.y;

    }
    private void Update()
    {
        
           
            Vector2 pos = transform.position;
            pos.x += MoveX / 100;

            if (rb2.gravityScale == 0)
            {
                pos.y += MoveY / 100 ;
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

            //ゆっくりと回転してレーン移動するモーション（仕様書とは違う動き）
        //if (rb2.gravityScale < 0) 
        //{

        //    tfz = Mathf.Clamp(tfz, 0.0f, 180.0f);
        //    tf.eulerAngles = new Vector3(0, 0, tfz);
        //    tfz -= 0.5f;
        //    if(tfz < 1.0)
        //    {
        //        tfz = 0;
        //    }
            
        //}
        //else if(rb2.gravityScale > 0 )
        //{
        //    tfz = Mathf.Clamp(tfz, 0.0f, 180.0f);
        //    tf.eulerAngles = new Vector3(0,0,tfz);
        //    tfz += 0.5f;
        //    if (tfz > 179)
        //    {
        //        tfz = 180;
        //    }
        //}
        //if(tfz == 180)
        //{ sprite.flipX = true; }
        //if (tfz == 0)
        //{ sprite.flipX = false; }
        
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
        GameObject childObject = Instantiate(RailGun, transform.position + razerpoint + new Vector3(7.5f,0,0), Quaternion.identity);
        childObject.transform.parent = this.transform;
    }
    public void Uniquemagnet()
    {
        bulletpoint = transform.Find("Bulletpoint").localPosition;
        Instantiate(UniqueMagnet, transform.position + bulletpoint, Quaternion.identity);
        

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (sc.MagLiquid)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Destroy(collision.gameObject);
            }

        }
    }


}

