using UnityEngine;

public class CarController : MonoBehaviour
{
    bool translate = false; // 이동 중인지 여부를 나타내는 변수
    float moveSpeed = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        translate = true;
        if (Input.GetMouseButtonDown(0))
        {
            moveSpeed = 0.2f; // 마우스 클릭 시 이동 속도 설정

        }
        transform.Translate(moveSpeed, 0, 0); // 이동 속도에 따라 자동차를 이동시킴
        moveSpeed *= 0.98f; // 이동 속도를 점점 줄임

    }

}