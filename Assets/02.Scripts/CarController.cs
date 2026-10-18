using UnityEngine;

public class CarController : MonoBehaviour
{
    Vector2 startPos; // 시작 마우스 좌표
    float moveSpeed = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition; // 마우스 클릭 시 시작 좌표 저장
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //마우스 버튼에서 손가락을 떄었을떄 좌표
            Vector2 endPos = Input.mousePosition;

            // 스와이프 된 거리를 구한다
            float swipeLength = endPos.x - startPos.x;
          
            // 스와이프 길이를 처음 속도로 변경 500으로 나눈 이유는 그냐 거리 상태면 값이 너무 커져서 차가 너무 빠름
            moveSpeed = swipeLength / 500f;

        }
        transform.Translate(moveSpeed, 0, 0); // 이동 속도에 따라 자동차를 이동시킴
        moveSpeed *= 0.98f; // 이동 속도를 점점 줄임

    }

}