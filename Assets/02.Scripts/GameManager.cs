using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public GameObject car;
    public GameObject flag;
    public Text distance_text;

    void Update()
    {
        float length = flag.transform.position.x - car.transform.position.x;

        if (length >= 0)
        {
            distance_text.text = "목표 지점까지 " + length.ToString("F3") + "m";
        }
        else
        {
            distance_text.text = "게임 오버 예~";
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            length = 0;
        }
        
    }
}


//거리를 알아야 한다는 말은 Car와 Flag 오브젝트의 위치값을 알고 Car와 Flag 오브젝트의 x좌표를 알아내서 그 차이를 우리가 만든 Distance_text 오브젝트의 teext란에 표시

//ToString은 값을 문자열로 변환하는 메서드
//인수에는 값을 표시할 형식 지정할수 있음
//    인수에 넣을수 있는 형식 대표적인건 다음과 같음

//    정수형 d[자릿수] 정수를 표시할때 마다 사용, 지정 자리수 않채우면 왼쪽에 0 삽입 예:(456)ToString("D5") => 00456
//    고정 소수점형F[자릿수] 소수점 이하 자릿수를 지정할때 사용, 예:(12.3456)ToString("F3") => 12.346

//유니티에서는 AudioSource 컴포넌트로 효과음을 냅니다.
//audioSource 컴포넌트를 써서 스와이프 할때 '붕~' 하는 효과음을 넣어봅시다
// 효과음을 낼 떄는 다음 세 단계를 거칩니다.

//효과음을 낼 오브젝트에 auioSource 컴포넌트를 추가합니다.
//audioSource 컴포넌트의 효과음 설정
//효과음 울리고 싶은 시간은 스와이프로 결정