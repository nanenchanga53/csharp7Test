using System;

namespace csharp7test
{
    internal class UseNewThrow
    {
        public UseNewThrow()
        {
            //OldThowAssert(false); //기존에는 throw를 포함한 별도의 매서드가 필요했다.

            newThrowAssert(true); //throw가 의미 있게 사용될 만한 식에서 허용이 된다.
        }

        private void newThrowAssert(bool result) =>
#if DEBUG
            _ = result == true ? result : throw new ApplicationException("ASSERT");
#else
            _ = result;
#endif

#region 기존 Throw
        public bool OldThowAssert(bool result) =>
#if DEBUG
                result == true ? result : AssertException("ASSERT");
#else
        result;
#endif

        public bool AssertException(string msg)
        {
            throw new ApplicationException(msg);
        }
    }
    #endregion


    //덤
    internal class Person
    {
        public string Name { get; }

        // null 변합 연산자(??)에서 thow 사용가능 
        //null 이면 throw를 실행
        public Person(string name) => Name = name ?? throw new ArgumentNullException(nameof(name));

        //람다 식으로 정의된 메서드에서 사용가능
        public string GetLastName() => throw new NotImplementedException();

        public void Print()
        {
            //람다 식을 이용한 델리게이트에서 사용 가능
            Action action = () => throw new Exception();
            action();
        }

    }


}