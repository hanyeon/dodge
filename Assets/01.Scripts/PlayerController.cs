using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed = 8f;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        // 게임오브젝트에서 리즈드바디 컴포넌트를 찾아 플레이리지드바디에 할당
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        // 수평측과 수직축의 입력값을 감지하여 저장

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;
        // 실제 이동 속도를 입력값과 이동속력을 사용해서 결정

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        // 벡터3 속도를 (x  ) 생성

        playerRigidbody.linearVelocity = newVelocity;


    }
        public void Die()
        { 
        gameObject.SetActive(false);

        GameManager gameManager = FindAnyObjectByType<GameManager>();
        gameManager.EndGame();


        }
    }
