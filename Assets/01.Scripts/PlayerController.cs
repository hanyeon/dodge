using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed = 8f;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        // ���ӿ�����Ʈ���� �����ٵ� ������Ʈ�� ã�� �÷��̸�����ٵ� �Ҵ�
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        // �������� �������� �Է°��� �����Ͽ� ����

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;
        // ���� �̵� �ӵ��� �Է°��� �̵��ӷ��� ����ؼ� ����

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        // ����3 �ӵ��� (x  ) ����

        playerRigidbody.linearVelocity = newVelocity;


    }
        public void Die()
        { 
        gameObject.SetActive(false);

        GameManager gameManager = FindAnyObjectByType<GameManager>();
        gameManager.EndGame();


        }
    }
