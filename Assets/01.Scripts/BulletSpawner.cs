using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; //  생성할 탄알의 원본 프리팹
    public float spawnRateMin = 0.5f; // 최소 생성주기
    public float spawnRateMax = 3f;  // 최대 생성주기

    private Transform target; // 발사할 대상 (위치값: 플레이어)
    private float spawnRate;  // 생성주기
    private float timeAfterSpawn;  // 최근 생성시점에서 지난시간 (게임이 지난 시간 누적)

    void Start()
    {
        // 최근 생성이후의 누적 시간을 0으로 초기화
        timeAfterSpawn = 0f;
        // 탄환생성 간격을  알 최소율과 알 최대사이에서 램덤
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        //게임자제어 기능자를 가진 게임객체를 찾아 조준대상 설정
        target = FindAnyObjectByType<PlayerController>().transform;
        //gameObject= "player" 
        
    }

    // Update is called once per frame
    void Update()
    {
        // 알생성후 경과시간  tas= tas+time.deltatime
        timeAfterSpawn += Time.deltaTime;
        // 최근 생성된 시점에서 부터 누적된 시간이 생성주기보다 크거나 같다면
        if(timeAfterSpawn >= spawnRate)
        {
            // 누적된 기간을 리셋
            timeAfterSpawn = 0f;

            // 총알 부속품 보관창고에서 복제본을 위치정보(현재위치,회전값)으로 생성
            GameObject bullet
                = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);

            // 다음번 생성간격을  알생성최소, 알생성 최대, 사이에서 램덤지정
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);


        }
    }
}
