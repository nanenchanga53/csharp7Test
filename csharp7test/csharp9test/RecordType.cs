using System;
using System.Collections.Specialized;
using static System.Console;
namespace csharp9test
{
        /// <summary>
        /// 레코드 사용으로 객체 내 멤버가 Immutable Reference Type 이 되었다.
        /// </summary>
        public record Person
        {
                //init은 속성을 정의할 때 쓰는 set 대신에 사용하는데, 
                //set으로 정의된 속성이 흔히 객체 생성 이후에 속성을 변경하는데 사용되는 것이라면, 
                //init은 객체가 처음 초기화될 때만 속성을 변경할 수 있다.
                public string Name { get; init; }
                public int Age { get; init; }
                

                //public Person(string name, int age)  => (Name, Age) = (name, age);
        }
        //상속지원
        public record Employee : Person
        {
                public int Id { get; init; }
        }

        /// <summary>
        /// 생성자 사용 Person
        /// </summary>
        public record consPerson
        {
                public string Name { get; init; }
                public int Age { get; init; }
                public consPerson(string name, int age)
                    => (Name, Age) = (name, age);
                public void Deconstruct(out string name, out int age)
                    => (name, age) = (Name, Age);
        }

        // 예제(6) Positional record
        /// <summary>
        /// 위에 consPerson을 아래꺼로 간결하게 만들 수 있다.
        /// </summary>
        public record PosPerson(string Name, int Age);

        #region 예제들
        #region 예제(1)
        //public record Person
        //{
        //        public string Name { get; }
        //        public int Age { get; }

        //        public Person(string name, int age)
        //            => (Name, Age) = (name, age);
        //}

        //class Program
        //{
        //        static void Main(string[] args)
        //        {
        //                Person p = new Person("Tom", 30);
        //                string s = p.Name;
        //        }
        //}
        #endregion
        #region 예제(2)
        //public record Person
        //{
        //        public string Name { get; init; }
        //        public int Age { get; init; }
        //}

        //class Program
        //{
        //        static void Main(string[] args)
        //        {
        //                Person p = new Person
        //                {
        //                        Name = "Tom",
        //                        Age = 30
        //                };
        //        }
        //}
        //#endregion
        //#region 예제(3)
        //Person tom1 = new Person
        //{
        //        Name = "Tom",
        //        Age = 30
        //};

        //Person tom2 = tom1 with { Age = 40 };
        #endregion
        #region 예제(4)
        // 예제(4)
        //Person p1 = new Person
        //{
        //        Name = "Tom",
        //        Age = 30
        //};

        //Person p2 = new Person
        //{
        //        Name = "Tom",
        //        Age = 30
        //};

        //bool same = p1.Equals(p2); // true

        //bool b = ReferenceEquals(p1, p2);  //false
        #endregion
        #region 예제(5,6,7)
        //레코드에 Constructor/Deconstructor 사용
        //public record Person
        //{
        //        public string Name { get; init; }
        //        public int Age { get; init; }
        //        public Person(string name, int age)
        //            => (Name, Age) = (name, age);
        //        public void Deconstruct(out string name, out int age)
        //            => (name, age) = (Name, Age);
        //}

        //// 예제(6) Positional record
        //public record Person(string Name, int Age);

        //// 예제(7) 
        //class Program
        //{
        //        static void Main(string[] args)
        //        {
        //                // Constructor 사용
        //                Person tom = new Person("Tom", 30);

        //                // Deconstructor 사용
        //                var (name, age) = tom;

        //                Console.WriteLine($"{name}, {age}");
        //        }
        //}

        #endregion
        #region 예제(8)
        // 예제(8) 파생 record
        //public record Person
        //{
        //        public string Name { get; init; }
        //        public int Age { get; init; }
        //}

        //public record Employee : Person
        //{
        //        public int Id { get; init; }
        //}

        //class Program
        //{
        //        static void Main(string[] args)
        //        {
        //                Person p1 = new Employee
        //                {
        //                        Id = 1001,
        //                        Name = "Tom",
        //                        Age = 30
        //                };
        //        }
        //}
        #endregion
        #endregion

        public class RecordType
        {
                public RecordType()
                {



                        WriteLine(@"
                        C# 9.0 에서 가장 두드러진 변화는 record 타입을 새로 도입한 것이다.
                        지금까지의 C#/.NET에서는 struct를 사용하는 Value Type(값 타입)과 class를 사용하는 Reference Type(레퍼런스 타입)이 있었는데, 
                        C# 9에서 Immutable 값 데이타를 갖는 record 타입을 추가하였다. 
                        새로 도입된 record 타입은 객체 내의 멤버가 변하지 않는 Immutable Reference Type을 만들기 위한 것이다. 
                        C# 9에서는 이를 위해 record 라는 새로운 키워드를 도입했으며, 
                        class 키워드를 사용해서 클래스를 정의하는 것이 아니라, 
                        이 record라는 키워드를 통해 Immutable Type을 정의하게 된다.

                        // 예제(1)
                        public record Person
                        {
                            public string Name { get; }
                            public int Age { get; }

                            public Person(string name, int age)
                                => (Name, Age) = (name, age);
                        }

                        class Program
                        {
                                static void Main(string[] args)
                                {
                                        Person p = new Person('Tom', 30);
                                        string s = p.Name;
                                }
                        }


                        init은 속성을 정의할 때 쓰는 set 대신에 사용하는데, 
                        set으로 정의된 속성이 흔히 객체 생성 이후에 속성을 변경하는데 사용되는 것이라면,
                        init은 객체가 처음 초기화될 때만 속성을 변경할 수 있다.

                        public record Person
                        {
                            public string Name { get; init;}
                            public int Age { get; init;}
                                
                            //아래는 생략 가능하려면 new에서 각각 넣는 방식으로 만들어야한다
                            //public Person(string name, int age) => (Name, Age) = (name, age);
                        }
                        
                        .....//아래처럼 선언해야 튜플형식으로 생성자를 만들 필요가 없다
                        Person p = new Person
                        {
                            Name = 'Tom',
                            Age = 30
                        };
                        //p.Name = 'John'; //에러 선언시만 값을 넣을 수 있음


                        p 객체 중 나이만 변경하고 나머지 데이타는 동일하게 p2 객체를 만들고 싶다면, 
                        아래와 같이 with 키워드를 사용할 수 있다.

                        Person p = new Person('Tom', 30);
                        string s = p.Name;
                        Person p2 = p with { Age = 40 };

                        ");



                        //Person tom = new Person("Tom", 30);
                        //string s = tom.Name;
                        //p.Name = "John"; //에러

                        //Person tom2 = tom with { Age = 40 };

                        // 예제(4)
                        Person p1 = new Person
                        {
                                Name = "Tom",
                                Age = 30
                        };

                        Person p2 = new Person
                        {
                                Name = "Tom",
                                Age = 30
                        };

                        Person p3 = p1 with { Age = 40 };

                        WriteLine(@"
                        record 객체 비교
                        ReferenceEquals()은 false를 리턴하고, 두 객체의 데이타가 동일하므로 Equals()은 true를 리턴한다.

                        // 예제(4)
                        Person p1 = new Person
                        {
                            Name = 'Tom',
                            Age = 30
                        };

                        Person p2 = new Person
                        {
                                Name = 'Tom',
                                Age = 30
                        };

                        bool same = p1.Equals(p2); // true

                        bool b = ReferenceEquals(p1, p2);  //false
                        ");

                        bool same = p1.Equals(p2); // true
                        bool b = ReferenceEquals(p1, p2);  //false
                        bool same2 = p1.Equals(p3);
                        bool b2 = ReferenceEquals(p1, p3);

                        WriteLine($"same = {same}");
                        WriteLine($"b = {b}");

                        WriteLine($"same2 = {same2}");
                        WriteLine($"b2 = {b2}");

                        //record 타입은 아래 예제(5)에서 보는 바와 같이 생성자(constructor)와 Deconstructor를 사용할 수 있는데, 
                        //이들은 Positional record를 사용하면 생성자(constructor)와 Deconstruct를 정의할 필요 없이 
                        //아래 예제(6)과 같이 간결하게 표현할 수 있다.

                        WriteLine(@"
                        // 예제(5) 레코드에 Constructor/Deconstructor 사용
                            public record Person
                            {
                                public string Name { get; init; }
                                public int Age { get; init; }
                                public Person(string name, int age)
                                    => (Name, Age) = (name, age);
                                public void Deconstruct(out string name, out int age)
                                    => (name, age) = (Name, Age);
                            }

                            // 예제(6) Positional record
                            public record Person(string Name, int Age);

                            // 예제(7) 
                            class Program
                            {
                                static void Main(string[] args)
                                {
                                // Constructor 사용
                                Person tom = new Person('Tom', 30);

                                // Deconstructor 사용
                                var (name, age) = tom;

                                Console.WriteLine($'{name}, {age}');
                                    }
                            }

                            ");

                        // Constructor 사용
                        PosPerson postom = new PosPerson("Tom", 30);

                        // Deconstructor 사용
                        var (name, age) = postom;

                        Console.WriteLine($"{name}, {age}");

                        WriteLine(@"
                        record 타입은 상속을 지원하며, 파생 클래스를 정의하는 것과 동일한 방식으로 파생 record를 만들 수 있다. 
                        파생 record 타입에서도 with 표현식과 Equals 객체 비교 등이 동일하게 적용된다.
                        // 예제(8) 파생 record
                        public record Person
                        {
                            public string Name { get; init; }
                            public int Age { get; init; }
                        }

                        public record Employee : Person
                        {
                            public int Id { get; init; }
                        }

                        class Program
                        {
                            static void Main(string[] args)
                            {
                                Person p1 = new Employee
                                {
                                    Id = 1001,
                                    Name = 'Tom',
                                    Age = 30
                                };
                            }
                        }

                        ");

                        Person employee = new Employee
                        {
                                Id = 1001,
                                Name = "Tom",
                                Age = 30
                        };

                        WriteLine($"{employee}");


                }
        }
}