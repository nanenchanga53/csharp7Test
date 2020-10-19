using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csharp8test
{
    public class PatternMatching
    {
        public PatternMatching()
        {
            Console.WriteLine("종류를 선택하시오");
            Console.WriteLine("1. switch expression (switch 식)");
            Console.WriteLine("2. Property Pattern (속성 패턴)");
            Console.WriteLine("3. Tuple Pattern (튜플 패턴)");
            Console.WriteLine("4. Positional pattern (위치 패턴)");
            Console.WriteLine("5. Recursive pattern (재귀 패턴)");
            int selectNum = Convert.ToInt32(Console.ReadLine());

            switch(selectNum)
            {
                case 1:
                    Console.WriteLine("1. NULL, 2. Line, 3. Rectangle, 4. Circle");

                    Console.WriteLine(@"
                    switch문 (switch statement)은 각 case 별로 값을 체크하여 분기하게 된다. 
                    switch식 (switch expression)은 기존의 case 블럭들을 보다 간결하게 식(expression)으로 표현한 것으로, 
                    기존의 case, break, default 등과 같은 키워드를 사용하지 않고 각 case를 '(패턴/값) => (수식)' 와 같은 expression 으로 표현한다.
                    
                    static double GetArea(Shape shape)
                    {
                        // C# 8.0 switch expression
                        double area = shape switch
                        {
                            null => 0, //shape가 null인경우
                            Line _ => 0,  //shape가 Line인경우
                            Rectangle r => r.Width * r.Height,  //shape가 Rectangle인경우
                            Circle c => Math.PI * c.Radius * c.Radius, //shape가 Circle인 경우
                            _ => throw new ArgumentException()  //defalut
                        };
                        return area;
                    }");
                    int selectedShape = Convert.ToInt32(Console.ReadLine());

                    Shape shape = null;
                    if (selectedShape == 1)
                        shape = null;
                    else if (selectedShape == 2)
                    {
                        shape = new Line(1.0);
                    }
                    else if (selectedShape == 3)
                    {
                        shape = new Rectangle(1.0, 2.0);
                    }

                    else if (selectedShape == 4)
                    {
                        shape = new Circle(1.0);
                    }

                    Console.WriteLine(GetArea(shape));
                    
                    break;
                case 2:

                    Console.WriteLine("객체의 속성을 사용하여 패턴 매칭을 할 수 있도록 한 것이다. ");
                    Console.WriteLine("케이스는 Level 속성과 IsMinor 속성을 함께 사용하고 있으며, Level이 A이고 IsMinor가 false 인 경우를 다루고 있다.");
                    Console.WriteLine(@"
                    public decimal CalcFee(Customer cust)
                    {
                    // Property Pattern (속성 패턴)
                    decimal fee = cust switch
                    {
                        { IsSenior: true } => 10,
                        { IsVeteran: true } => 12,
                        { Level: 'VIP' } => 5,
                        { Level: 'A', IsMinor: false } => 10,
                        _ => 20
                    };
                    return fee;
                    }
                    ");
                    Console.WriteLine("10,12,5,20 중에 숫자를 입력하여 해당되는 속성으로 변경해 출력한다");
                    Customer customer = new Customer();
                    int selectedFee = Convert.ToInt32(Console.ReadLine());
                    switch(selectedFee)
                    {
                        case 10:
                            customer.IsSenior = true;
                            customer.Level = "A";
                            customer.IsMinor = false;
                            break;
                        case 12:
                            customer.IsVeteran = true;
                            break;
                        case 5:
                            customer.Level = "VIP";
                            break;
                        case 20:
                            break;
                        default:
                            break;
                    }

                    Console.WriteLine($"IsSenior : {customer.IsSenior}");
                    Console.WriteLine($"IsVeteran : {customer.IsVeteran}");
                    Console.WriteLine($"IsLevel : {customer.Level}");
                    Console.WriteLine($"IsMinor : {customer.IsMinor}");
                    Console.WriteLine($"CalcFee(customer) : {CalcFee(customer)}");

                    break;
                case 3:
                    //하나의 변수가 아닌 복수 개의 변수들에 기반한 패턴 매칭을 위해 튜플 패턴을 사용할 수 있다
                    //예를 들어, 신용도와 부채수준에 따른 신용한도를 산출하기 위해 2개의 변수(신용도과 부채수준)를 
                    //받아들이게 되는데, 아래 예제는 이렇게 복수 개의 변수들을 패턴 매칭에 사용하는 튜플 패턴을 예시한 것이다. 
                    //여기서 GetCreditLimit() 메서드는 creditScore와 debtLevel을 받아들여 이 두개의 값을 사용하여 적절한 크레딧 
                    //한도를 산출해서 리턴하는 것이다.

                    Console.WriteLine("하나의 변수가 아닌 복수 개의 변수들에 기반한 패턴 매칭을 위해 튜플 패턴을 사용할 수 있다");
                    Console.WriteLine(@"
                    static int GetCreditLimit(int creditScore, int debtLevel)
                    {
                        // Tuple Pattern (튜플 패턴)
                        var credit = (creditScore, debtLevel) switch
                        {
                            (850, 0) => 200, //max credit score with no debt
                            var (c, d) when c > 700 => 100,
                            var (c, d) when c > 600 && d < 50 => 80,
                            var (c, d) when c > 600 && d >= 50 => 60,
                            _ => 40
                        };
                        return credit;
                    }

                    static void Main(string[] args)
                    {
                        int creditPct = GetCreditLimit(650, 30);
                        Console.WriteLine(creditPct);
                    }
                    ");

                    int creditPct = GetCreditLimit(650, 30);
                    Console.WriteLine($"creaditPct : {creditPct}");
                    break;
                case 4:
                    Console.WriteLine("만약 어떤 타입이 Deconstructor 를 가지고 있다면\nDeconstructor로부터 리턴되는 속성들을 그 위치에 따라 패턴\n매칭에 사용할 수 있는데, 이를 Positional pattern (위치 패턴)이라 한다.");

                    Console.WriteLine(@"
                    static string 사분면(Point point)
                    {
                        //Positional pattern (위치 패턴)
                        string quad = point switch
                        {
                            (0, 0) => '원점',
                            var(x, y) when x > 0 && y > 0 => '1사분면',
                            var(x, y) when x < 0 && y > 0 => '2사분면',
                            var(x, y) when x < 0 && y < 0 => '3사분면',
                            var(x, y) when x > 0 && y < 0 => '4사분면',
                            var(_, _) => 'X/Y축',
                            _ => null
                        };
                            return quad;
                    }

                    static void Main(string[] args)
                    {
                        var p = new Point(-5, -2);
                        string q = 사분면(p);
                        Console.WriteLine(q); // 3사분면
                    }");

                    var p = new Point(-5, -2);
                    string q = 사분면(p);
                    Console.WriteLine($"사분면 : {q}");

                    break;
                case 5:
                    Person nowStudentMan = new Student();
                    Person OBStudent = new Student(true, "woochang");
                    Person OGStudent = new Student(true, "woocchang");
                    Person justWoman = new Student();
                    justWoman.Name = "womanPerson";
                    List<Person> peoples = new List<Person>();
                    peoples.Add(nowStudentMan);
                    peoples.Add(OBStudent);
                    peoples.Add(OGStudent);
                    peoples.Add(justWoman);

                    Console.WriteLine("C# 8.0에서 패턴은 다른 서브패턴(sub pattern)들을 포함할 수 있고,\n한 서브패턴은 내부에 또 다른 서브패턴들을 포함할 수 있는데,\n이러한 것을 재귀 패턴(Recursive pattern)이라 한다.");
                    Console.WriteLine(@"
                    IEnumerable<string> GetStudents(List<Person> people)
                    {
                        foreach (var p in people)
                        {
                            // Recursive pattern (재귀 패턴)
                            if (p is Student { Graduated: false, Name: string name })
                            {
                                yield return name;
                            }
                        }
                    }
                    ...
                    static void Main(string[] args)
                    {
                        Person nowStudentMan = new Student();
                        Person OBStudent = new Student(true, 'woochang');
                        Person OGStudent = new Student(true, 'woocchang');
                        Person justWoman = new Student();
                        justWoman.Name = 'womanPerson';
                        List<Person> peoples = new List<Person>();
                        Person nowStudentMan = new Student();
                        Person OBStudent = new Student(true, 'woochang');
                        Person OGStudent = new Student(true, 'woocchang');
                        Person justWoman = new Student();
                        justWoman.Name = 'womanPerson';
                        List<Person> peoples = new List<Person>();
                        peoples.Add(nowStudentMan);
                        peoples.Add(OBStudent);
                        peoples.Add(OGStudent);
                        peoples.Add(justWoman);
                    }      
                    ");

                    IEnumerable<string> e =  GetStudents(peoples);
                    foreach(var pt in e)
                    {
                        Console.WriteLine(pt);
                    }


                    break;
                default:
                    break;

            }
        }

        #region Switch형 패턴매칭
        //switch문(switch statement)은 각 case 별로 값을 체크하여 분기하게 된다.
        //switch식(switch expression)은 기존의 case 블럭들을 보다 간결하게 식(expression)으로 표현한 것으로, 
        //기존의 case, break, default 등과 같은 키워드를 사용하지 않고 각 case를 '(패턴/값) => (수식)' 와 같은 expression 으로 표현한다.
        static double GetArea(Shape shape)
        {
            // C# 8.0 switch expression
            double area = shape switch
            {
                null => 0, //shape가 null인경우
                Line _ => 0,  //shape가 Line인경우
                Rectangle r => r.Width * r.Height,  //shape가 Rectangle인경우
                Circle c => Math.PI * c.Radius * c.Radius, //shape가 Circle인 경우
                _ => throw new ArgumentException()  //defalut
            };
            return area;
        }
        #endregion

        #region 속성패턴매칭
        //C# 8.0에서 도입된 Property Pattern (속성 패턴)은 객체의 속성을 사용하여 패턴 매칭을 할 수 있도록 한 것이다. 
        //속성 패턴을 사용하면 복잡한 switch문을 보다 간결하게 switch식으로 표현할 수 있다. 
        //아래 예제는 Customer 객체의 속성에 따라 요금(fee)을 판별하는 switch식으로서 Customer 클래스의 여러 속성들(예: cust.IsSenior, cust.Level)을 
        //사용하여 여러 케이스별로 요금을 다르게 책정하게 된다. 속성 패턴은 하나 이상의 속성을 사용할 수 있는데, 예를 들어 아래 4번째 
        //케이스는 Level 속성과 IsMinor 속성을 함께 사용하고 있으며, Level이 A이고 IsMinor가 false 인 경우를 다루고 있다.

        public decimal CalcFee(Customer cust)
        {
            // Property Pattern (속성 패턴)
            decimal fee = cust switch
            {
                { IsSenior: true } => 10,
                { IsVeteran: true } => 12,
                { Level: "VIP" } => 5,
                { Level: "A", IsMinor: false } => 10,
                _ => 20
            };
            return fee;
        }
        #endregion

        #region 튜플형 패턴매칭
        static int GetCreditLimit(int creditScore, int debtLevel)
        {
            // Tuple Pattern (튜플 패턴)
            var credit = (creditScore, debtLevel) switch
            {
                (850, 0) => 200, //max credit score with no debt
                var (c, d) when c > 700 => 100,
                var (c, d) when c > 600 && d < 50 => 80,
                var (c, d) when c > 600 && d >= 50 => 60,
                _ => 40
            };
            return credit;
        }
        #endregion

        #region 위치 패턴매칭(Deconstruct() 메서드 c#7.0 참조)

        //만약 어떤 타입이 Deconstructor 를 가지고 있다면, 
        //Deconstructor로부터 리턴되는 속성들을 그 위치에 따라 패턴 
        //매칭에 사용할 수 있는데, 이를 Positional pattern (위치 패턴)이라 한다.

        //예를 들어, 아래 예제에서 Point 클래스는 Deconstruct() 메서드를 가지고 있는데, 
        //이 Deconstructor는 X, Y 속성을 순서대로 리턴하고 있다.이 Point 객체를 입력 
        //파라미터로 받아들이는 사분면() 메서드는 Point 객체(point)의 Deconstructor에서 
        //리턴되는 속성들을 순서대로 받아 각 값들을 사용하게 된다.Deconstructor에서 리턴되는 
        //속성들은 var (x, y) 로 전달되고, 이 x, y 값의 범위를 when 조건으로 비교하여 몇사분면에 있는지를 판단하게 된다.

        static string 사분면(Point point)
        {
            //Positional pattern (위치 패턴)
            string quad = point switch
            {
                //var(x,y) 이런식으로 튜플을 생성후 when 으로 조건을 사용한다.
                (0, 0) => "원점",
                var (x, y) when x > 0 && y > 0 => "1사분면",
                var (x, y) when x < 0 && y > 0 => "2사분면",
                var (x, y) when x < 0 && y < 0 => "3사분면",
                var (x, y) when x > 0 && y < 0 => "4사분면",
                var (_, _) => "X/Y축",
                _ => null
            };
            return quad;
        }
        #endregion

        #region 재귀 패턴매칭

        //C# 8.0에서 패턴은 다른 서브패턴(sub pattern)들을 포함할 수 있고, 
        //한 서브패턴은 내부에 또 다른 서브패턴들을 포함할 수 있는데, 
        //이러한 것을 재귀 패턴(Recursive pattern)이라 한다. 
        //아래 예제는 변수 p가 Student 클래스인지 체크해서 만약 Student 타입이면 다시 
        //속성 패턴을 사용해서 Graduated 속성이 false 인지(constant pattern)를 체크하고, 
        //그리고 Name 속성이 non-null string 인지(type pattern)를 체크해서 non-null이면 
        //Name 속성을 name 변수에 넣고 이를 yield return 하게 된다. 
        //참고로 'Name: string name' 패턴은 Name 속성이 string 타입인지 체크하는데, 
        //만약 Name is string에서 Name 속성이 null 이면 Name is string 이 false가 된다. 
        //좀 더 보편적인 표현으로 'x is T y' 에서 x가 null 이면 항상 패턴매칭이 false 가 된다.
        /// <summary>
        /// IEnumerable로 선언해 두어서 연속적인 값들에 대해 여러 Linq설정을 사용할 수 있도록 설정하고 아래 선언으로 값을 채우고 반환한다
        /// </summary>
        /// <param name="people"></param>
        /// <returns></returns>
        IEnumerable<string> GetStudents(List<Person> people)
        {
            foreach (var p in people)
            {
                // Recursive pattern (재귀 패턴)
                // Student 인지 패턴을 확인한 후 그 안의 속성이 어떤 값들인지 확인하는 2번이상의 패턴을 매칭한다
                if (p is Student { Graduated: false, Name: string name })
                {                    
                    yield return $"Not Graduated, Name is '{p.Name}'";
                }
                else
                {
                    yield return $"Graduated or Not Student Name is '{p.Name}'";
                }
            }
        }
        #endregion

    }

    #region student 인터페이스
    public interface Person
    {
        public string Name { get; set; }
    }

    public class Student : Person
    {
        public bool Graduated { get; set; }
        public string Name { get; set; }

        public Student()
        {
            Graduated = false;
            Name = "Person";
        }

        public Student(bool isGraduated, string name)
        {
            Graduated = isGraduated;
            Name = name;
        }
    }
    #endregion

    #region Shape 인터페이스

    public class Line : Shape
    {
        public double Length { get; }

        public string MyShapeName => "Line";

        public Line(double length)
        {
            Length = length;
        }

    }

    public class Circle : Shape
    {
        public double Radius { get; }

        public string MyShapeName => "Circle";

        public Circle(double radius)
        {
            Radius = radius;
        }
    }
    public struct Rectangle : Shape
    {
        public double Width { get; }
        public double Height { get; }

        public string MyShapeName => "Rectangle";

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }
    }

    interface Shape
    {
        public String MyShapeName { get; }
        
    }
    #endregion

    #region Customer 클래스
    

    /// <summary>
    //  IsSenior,IsVeteran,Level,IsMinor 속성을 같고있는 클래스
    /// </summary>
    public class Customer
    {
        public bool IsSenior { get; set; }
        public bool IsVeteran { get; set; }
        public string Level { get; set; }
        public bool IsMinor { get; set; }

        public Customer()
        {
            IsSenior = false;
            IsVeteran = false;
            Level = "D";
            IsMinor = true;
        }

    }
    #endregion

    #region Point 클래스
    class Point
    {
        public int X { get; }
        public int Y { get; }
        public Point(int x, int y) => (X, Y) = (x, y);

        //Deconstruct 는 7.0에서 새로생긴 메서드로 필드의 값들을 외부로 전달하는 역활을 한다.
        //public void Deconstruct(out T1 x1, ..., out Tn xn) { ... } 인자값은 out으로 선언하자
        public void Deconstruct(out int x, out int y) =>
            (x, y) = (X, Y);
    }
    #endregion

}
