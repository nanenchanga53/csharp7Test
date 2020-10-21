using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace csharp8test
{
        //Pass by value : 파라매터 값을 넘기지만 메서드에서 값이 바껴도 원본 값은 변하지않음
        //int Foo(int x, int y) => x = y; //호출한곳에서는 파라매터 값이 유지
        //Pass by reference : 파라매터를 넘기면 메서드에서 값이 변경하면 원본 값도 바뀜
        //int Foo(ref int x, ref int y) => x = y; 혹은 int Foo(out int x, int y) => x = y;
        //호출한 곳에서의 파라매터로 보냈던 변수역시 값이 변환
        //void Check(Triangle tri) // 호출한 파라메터를 tri 안에 전부 복사하는데 Triangle이 복잡할시 전부 복사해 넣으면 시간이 오래걸림
        //void Check(ref Triangle tri) // 파라매터 주소값을 넘기고 호출할 때의 파라매터를 참조하면서 확인하는 것이기에 Triangle이 복잡하면 이쪽을 사용

        public class StructReadOnly
        {
                //이전 C# 버전에서 구조체(struct) 전체를 readonly로 만들 수 있었는데, 
                //C# 8.0부터는 구조체의 각 멤버에 대해 개별적으로 readonly로 정의할 수 있게 되었다. 
                //만약 구조체의 메서드나 속성이 구조체의 상태를 변경하지 않는다면 readonly로 적용할 수 있고,
                //readonly 멤버가 다른 non-readonly 멤버를 엑세스하면 컴파일러가 Warning을 표시한다.

                //C# 7.2에서 도입된 in 파라미터는 Value 타입의 파라미터를 Pass by reference로 전달할 수 있게 하는 기능을 제공한다. 
                //만약 파라미터로 전달하는 구조체가(Value 타입) 큰 사이즈라면, Pass by value로 복사해서 전달하는 
                //것보다 위치 정보만을 전달하는 Pass by reference를 사용하는 것이 성능면에서 효율적이다. 
                //이러한 목적으로 in 파라미터는 구조체를 Pass by value로 전달할 수 있는 기능을 제공한다.

                //만약 구조체 전체가 readonly라면, 즉 구조체 내부의 모든 멤버가 readonly라면, 
                //in 파라미터를 사용하여 Pass by reference로 전달할 지라도 호출된 메서드(Callee)에서 구조체의 
                //내부 상태를 변경하는 행위를 할 수 없으므로, 호출자(Caller)의 구조체는 변경되지 않을 것이 확실하다.
                //이러한 측면에 큰 사이즈의 구조체를 in 파라미터로 전달하기 위해, 
                //(가능하다면) 구조체를 readonly로 만들 것이 좋을 것이다.
                //하지만, 경우에 따라 구조체가 상태를 변경하는 멤버를 가질 수도 있다.이러한 경우에는 
                //일부 멤버들에 대해 readonly 멤버를 사용하는 것을 고려해 볼 수 있다.

                //Non-readonly 구조체인 경우 in 파라미터로 전달되면, 
                //컴파일러는 호출된 메서드(Callee)에서 전달된 구조체의 멤버(메서드나 속성 등)을 
                //호출할 때마다 구조체 파라미터를 복사하게 된다.
                //이는 컴파일러가 구조체의 멤버가 상태를 변경하는지 미리 알 수 없기 때문에, 
                //방어적으로 구조체를 다시 복사(defensive copy or hidden copy)하여 사용하는 것이다.
                //구조체의 크기가 큰 경우 Callee 에서 그 구조체에 대해 10개의 메서드/속성을 호출한다면, 
                //10번의 복사가 읽어나는데 이는 성능을 저하시키는 원인이 될 수 있다.

                //예를 들어, 아래 예제를 보면, Triangle 구조체가 정의되어 있고, 
                //이 Triangle 인스턴스를 Check(in Triangle) 메서드에 in 파라미터로 전달하고 있다.

                public StructReadOnly()
                {
                        Triangle t = new Triangle(3, 4, 5);
                        Check(t);                        
                        Console.WriteLine($"t.IsEquilatrea : {t.IsEquilateral}");
                        t.a = 4;
                        t.b = 4;
                        t.c = 4;
                        Console.WriteLine($"t.IsEquilatrea : {t.IsEquilateral}");
                        Check(t);
                        t = new Triangle(5, 5, 5);
                        Check(ref t,1);
                        Console.WriteLine($"t.IsEquilatrea : {t.IsEquilateral}");

                        Triangle2 t2 = new Triangle2(3, 3, 3);
                        Check2(ref t2);
                        Console.WriteLine($"t2.IsEquilatrea : {t2.IsEquilateral}");
                }


                
                public struct Triangle
                {
                        public int a, b, c;

                        public Triangle(int a, int b, int c)
                        {
                                this.a = a;
                                this.b = b;
                                this.c = c;
                        }

                        //위와 같은 복사(hidden copy) 이슈를 해결하기 위해서, 
                        //만약 그 멤버가 구조체의 상태를 변화시키지 않을 경우 멤버 앞에 readonly를 붙여 컴파일러에게 hidden copy를 만들 
                        //필요가 없음을 알려 줄 수 있다. 즉, Perimeter와 IsEquilateral 멤버 앞에 아래와 같이 readonly를 표시할 수 있다.
                        public readonly int Perimeter => a + b + c; //public int -> public readonly int
                        public readonly bool IsEquilateral => a == b && b == c; //public bool => public readonly bool
                }

                //원래 readonly struct
                public readonly struct Triangle2
                {
                        public int a { get; }
                        public int b { get; }
                        public int c { get; }

                        public Triangle2(int a, int b, int c)
                        {
                                this.a = a;
                                this.b = b;
                                this.c = c;
                        }

                        public int Perimeter => a + b + c;
                        public bool IsEquilateral => a == b && b == c;
                }

                //Check() 메서드에서 Triangle 구조체의 Perimeter와 IsEquilateral 멤버를 2번 호출하고 있는데, 
                //이렇게 멤버를 호출할 때마다 직전에 Triangle 인스턴스를 로컬변수에 복사하게 된다.
                //아래 예제는 위 코드를 컴파일했을 때의 코드를 표현한 것으로 멤버 호출 직전에 구조체 파라미터를 복사하고 있다.
                //private void Check([In][IsReadOnly] ref Triangle tri)
                //{
                //        Triangle triangle = tri;
                //        int perimeter = triangle.Perimeter;
                //        triangle = tri;
                //        bool isEquilateral = triangle.IsEquilateral;
                //        Console.WriteLine(string.Format("{0}, {1}", perimeter, isEquilateral));
                //}

                //Check() 메서드에서 readonly로 표시된 Perimeter와 IsEquilateral 멤버를 호출할 경우, 
                //컴파일러는 아래와 같이 별도의 hidden copy를 필요로 하지 않는 코드를 그대로 만들게(emit) 된다.
                private void Check(in Triangle tri)
                {
                        int perim = tri.Perimeter;
                        bool equi = tri.IsEquilateral;

                        Console.WriteLine($"{perim}, {equi}");


                }

                private void Check(ref Triangle tri, int ver2)
                {
                        int perim = tri.Perimeter;
                        bool equi = tri.IsEquilateral;

                        Console.WriteLine($"{perim}, {equi}");
                }
                
                private void Check2(ref Triangle2 tri)
                {
                        int perim = tri.Perimeter;
                        bool equi = tri.IsEquilateral;

                        Console.WriteLine($"{perim}, {equi}");


                }


                int Foo(int x,int y) => x = y;
                int Foo(ref int x, int y) => x = y;
                //int Foo(out int x, int y) => x = y;
        }
}