using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{
    Vector2 startPos;   //현재 마우스 좌표
    float moveSpeed = 0f;
    public bool isClicked = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetMouseButtonDown(0) && isClicked.Equals(false))
        {
            startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0) && isClicked.Equals(false))
        {   
            // 마우스 버튼에서 손가락을 때었을떄 좌표
            Vector2 endPos = Input.mousePosition;

            //스와이프 된 거리 구하기
            float swipeLength = endPos.x - startPos.x;
            
           
            float swipelength = Mathf.Clamp(swipeLength, 0, 1000f);

             //스와이프 길이를 처음 속도로 변경 500으로 나누는 이유는 씨발 존나 빨라 
            moveSpeed = swipeLength / 500f;

            //효과음을 재생한다.
            GetComponent<AudioSource>().Play();
            isClicked = true;
        }

        transform.Translate(moveSpeed, 0, 0);   //이동
        moveSpeed *= 0.98f; //감속

        if(transform.position.x == 0f)
        {
            moveSpeed = 0.998f;
        }
    }
}

//Translate 메서드를 사용하면 이동 방향은 월드 좌표계가 아니라 로컬 좌표계로 계산됩니다.
//따라서 오브젝트가 회전하면 방향이 회전한 좌표계로 계산됩니다.
//오브젝트가 회전하면 동시에 이동할 때는 조심해야 합니다.

//그럼 퀴즈
//회전된 상태의 오브젝트가 있는데, 이것을 로컬 좌표계로 이동되지 않고 월드 좌표계로 움직이게 하고 싶을때 어캐 해야 할까?
//로컬 좌표가 아니라 로컬 좌표를 갖고 있는 오브젝트의 상위 오브젝트(얘는 월드 좌표계랑 같은 좌표를 가지고 있다)를 움직이게 하면 간단하다.
//Event System
// Ui text를 추가하면 Hierarchy창에 Canvas와 EventSystem이 추가됩니다.
//이 이벤트 시스템은 사용자의 입려과 UI를 중간에서 모여주는거

//ui에서 좌표를 표시하는데 transform 이 아닌 RectTransform을 사용합니다/ Transform에서 위치, 회전 크기를 변경할수 있고, Rect Transform에서는 위치, 회전, 크기는 물론 피벗과 앵커 변경 가능
//피벗은 회전 또는 확대나 축소를 할 때 쓰는 중심 좌표임다.
//앵커는 UI 리소스를 배치할 떄 기준이 되는 위치를 지정함다.