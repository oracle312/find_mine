# 지뢰찾기 월핵 구현
<br/>

#### 👨🏻‍👩🏻‍👧🏻‍👦🏻 개인 프로젝트
---  
<br/>


  
### 📢 소개
---
+ 지뢰의 위치를 찾아 칸에 그려주는 프로그램
<br/><br/><br/>

### 🛠️ 개발환경
---
+ C#
+ VisualStudio, CheatEngine, GitHub
<br/><br/><br/>



### 💡목표
---
+ 지뢰찾기 칸 수에 맞게 DrawRectangle 해주기
+ 핸들을 얻어 메모리에 접근해서 읽어오기
+ 지뢰가 저장된 메모리를 2차원 배열로 읽어와, 지뢰가 존재하는 위치에만 DrawRectangle 해주기
+ decimal type 으로 저장된 메모리를 보았을때 65는 눌렀을때, 15는 누르지않았고 지뢰가 없는 곳, 143은 지뢰의 위치인 걸 알 수 있다
+ 16(hex10) 을 기점으로 시작과 끝을 나눈다.
+ 143은 hex type 으로 8F 이므로 메모리를 읽어와 8F일때에만 DrawRectangle을 해주자
<br/><br/><br/>
![10](https://github.com/oracle312/find_mine/assets/72733953/b151fe7c-ab85-4f46-9b8c-31c966d600ea)
![11](https://github.com/oracle312/find_mine/assets/72733953/d369ba30-8eff-4e93-bf63-3b1bad8405b1)
<br/>
배열에 잘 들어가는 모습을 볼 수 있다. 이걸 토대로 그려주기만 하면 된다.
<br/><br/><br/>

![15](https://github.com/oracle312/find_mine/assets/72733953/21508828-1a5f-47db-a4eb-2829d04a92e7)
<br/>


### ⚡기능
---
+ Overlay 이용 DrawRectangle
+ ReadProcessMemory 를 통해 Memory 읽어오기
  
  <br/><br/><br/>

### 🖥️ 결과물
---
우선 격자에 맞게 그려주었다.<br/>
![13](https://github.com/oracle312/find_mine/assets/72733953/abf1aaf3-f263-45d9-b3df-ee44a5fe768a)
![12](https://github.com/oracle312/find_mine/assets/72733953/798ca7f6-221e-4fce-af5b-31c5debbbbf5)
![9](https://github.com/oracle312/find_mine/assets/72733953/8a12e080-3565-41e1-a3ad-47646565741f)
<br/>
![14](https://github.com/oracle312/find_mine/assets/72733953/a5cadc14-5042-4c41-a9c0-ece59345788a)
<br/><br/><br/> 지뢰가 존재하는 위치에만 표시해주었다.<br/>
![18](https://github.com/oracle312/find_mine/assets/72733953/1ffd2f16-4dbf-45f1-846d-bed407ede12b)
![19](https://github.com/oracle312/find_mine/assets/72733953/4b7d17a6-1bef-4fbf-bf3d-57e9d5dd70b8)
<br/><br/><br/> 지뢰의 수를 변경하여도 잘 인식한다.<br/>
![20](https://github.com/oracle312/find_mine/assets/72733953/9c8b2692-b27c-4f96-bba5-9d36d99403ba)
![21](https://github.com/oracle312/find_mine/assets/72733953/84c91655-806b-45a9-9aa5-9493a4412da7)
<br/><br/><br/> 작동 모습.<br/>
![22](https://github.com/oracle312/find_mine/assets/72733953/eb5f587f-227f-46c7-a672-226bcf48373c)
