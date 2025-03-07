using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; //  ������ ź���� ���� ������
    public float spawnRateMin = 0.5f; // �ּ� �����ֱ�
    public float spawnRateMax = 3f;  // �ִ� �����ֱ�

    private Transform target; // �߻��� ��� (��ġ��: �÷��̾�)
    private float spawnRate;  // �����ֱ�
    private float timeAfterSpawn;  // �ֱ� ������������ �����ð� (������ ���� �ð� ����)

    void Start()
    {
        // �ֱ� ���������� ���� �ð��� 0���� �ʱ�ȭ
        timeAfterSpawn = 0f;
        // źȯ���� ������  �� �ּ����� �� �ִ���̿��� ����
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        //���������� ����ڸ� ���� ���Ӱ�ü�� ã�� ���ش�� ����
        target = FindAnyObjectByType<PlayerController>().transform;
        //gameObject= "player" 
        
    }

    // Update is called once per frame
    void Update()
    {
        // �˻����� ����ð�  tas= tas+time.deltatime
        timeAfterSpawn += Time.deltaTime;
        // �ֱ� ������ �������� ���� ������ �ð��� �����ֱ⺸�� ũ�ų� ���ٸ�
        if(timeAfterSpawn >= spawnRate)
        {
            // ������ �Ⱓ�� ����
            timeAfterSpawn = 0f;

            // �Ѿ� �μ�ǰ ����â���� �������� ��ġ����(������ġ,ȸ����)���� ����
            GameObject bullet
                = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);

            // ������ ����������  �˻����ּ�, �˻��� �ִ�, ���̿��� ��������
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);


        }
    }
}
