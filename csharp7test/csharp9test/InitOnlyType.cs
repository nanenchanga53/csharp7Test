using System;

namespace csharp9test
{
        public class InitOnlyType
        {
                //C# 9 에서 init 이라는 키워드가 새로 추가되었는데, 
                //init은 객체의 속성을 처음 초기화하는 용도로 사용된다. 
                //init 키워드는 해당 속성이 초기에 한번 설정되면, 
                //그 이후에 변경할 수 없는 기능을 제공하여 Immutable(불변) 속성을 만드는데 사용된다

                public InitOnlyType()
                {
                        Console.WriteLine(@"
C# 9 에서 init 이라는 키워드가 새로 추가되었는데, init은 객체의 속성을 처음 초기화하는 용도로 사용된다. 
init 키워드는 해당 속성이 초기에 한번 설정되면, 
그 이후에 변경할 수 없는 기능을 제공하여 Immutable(불변) 속성을 만드는데 사용된다
                        ");

                        Console.WriteLine(@"
// 예제(3) init 속성
public class Person
{
    public Guid Id { get; init; }
    public string Name { get; set; }
        
    public Person()
    {
    }

    public Person(string name)
    {
        this.Name = name;
        this.Id = Guid.NewGuid();
    }

    public void ChangeId()
    {
        // Id 변경 불가
        // this.Id = Guid.NewGuid();
    }
}

// 생성자
Person p1 = new Person('Tom');
// 객체 초기자
Person p2 = new Person
{
        Id = Guid.NewGuid(),
        Name = 'Tom'
};

                        ");


                        // 생성자
                        PersonInit p1 = new PersonInit("Tom");
                        // 객체 초기자
                        PersonInit p2 = new PersonInit
                        {
                                Id = Guid.NewGuid(),
                                Name = "Tom2"
                        };

                        

                        Console.WriteLine($"{p1.Id} : {p1.Name}");
                        Console.WriteLine($"{p2.Id} : {p2.Name}");

                        //init은 객체 데이타를 처음 초기화할 때만 사용할 수 있는데, 
                        //자동 속성뿐만 아니라 물론 필드를 엑세스하는 속성에서도 마찬가지로 
                        //init accessor를 사용할 수 있다. 
                        //이때 필드는 객체를 초기화할 때 한번만 변경되므로 흔히 readonly 필드를 사용하지만, 
                        //읽기전용이 아닌 필드도 init에서 사용할 수 있다. 
                        //아래 예제에서 category 필드는 읽기 전용이고 val 필드는 읽기 쓰기가 가능한데, 
                        //init accessor에서 이들 필드들을 함께 초기화하고 있다. 
                        //init 속성의 초기화는 생성자가 없는 경우, 아래 예제에서처럼 객체 초기자에서 할 수 있다.

                        // 객체 초기자를 사용하여 init값 할당 즉 전부 초기화해야 넣을 수 있다.
                        var s = new Score()
                        {
                                Value = 90
                        };

                        Console.WriteLine(s.Value);

                }

                // 예제(3) init 속성
                public class PersonInit
                {
                        public Guid Id { get; init; } //Guid 난수
                        public string Name { get; set; }

                        public PersonInit()
                        {
                        }

                        public PersonInit(string name)
                        {
                                this.Name = name;
                                this.Id = Guid.NewGuid();
                        }

                        public void ChangeId()
                        {
                                // Id 변경 불가
                                // this.Id = Guid.NewGuid();
                        }
                }

                public class Score
                {
                        private readonly int category;
                        private int val;


                        //public Score(int value)
                        //{
                        //        this.category = 1;
                        //        this.val = value;
                        //}
                        
                        //init 도 형식을 지정할 수 있다.
                        public int Value
                        {
                                get
                                {
                                        return this.val;
                                }
                                init
                                {
                                        this.category = 1;
                                        this.val = value;
                                }
                        }
                }

        }

        
}