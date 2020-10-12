using System;
using System.Collections.Generic;
using System.Text;

namespace csharp8test
{
    //예를 들어, ILogger 인터페이스가 초기에 아래와 같이 정의되었다고 가정하자.
    // ILogger v1.0
    //public interface ILogger
    //{
    //    void Log(string message);
    //}

    //이후 새로운 기능이 필요해서 ILogger 인터페이스에 2개의 메서드를 추가한 ILogger v2.0을 출시한다고 가정하자.
    // ILogger v2.0
    public interface ILogger
    {
        void Log(string message);

        // 추가된 멤버들
        void Log(Exception ex) => Log(ex.Message);
        void Log(string logType, string msg)
        {
            if (logType == "Error" ||
                logType == "Warning" ||
                logType == "Info")
            {
                Log($"{logType}: {msg}");
            }
            else
            {
                throw new ApplicationException("Invalid LogType");
            }
        }
    }

    public class DefaultInterfaceMembers
    {
                
        public DefaultInterfaceMembers()
        {
            Console.WriteLine("C#에서 인터페이스를 한번 배포한 후, 그 인터페이스를 수정하면 기존에 구현된 모든 타입들을 수정하지 않는 한 타입 오류를 발생시켰다. ");
            Console.WriteLine("더구나 그 인터페이스를 외부에서 사용한다면, 수정은 거의 불가능하였다.");
            Console.WriteLine("C# 8.0에서는 인터페이스에 새로운 멤버를 추가하고, 새로운 멤버의 Body 구현 부분을 추가할 수 있게 되었다.\n이렇게 새로 추가된 인터페이스 멤버는 디폴트로 사용되기 때문에, 기존 구현된 타입들이 새 멤버를 추가적으로 구현되지 않을 경우, 이 디폴트 구현을 사용하게 된다.");
            Console.WriteLine(@"// ILogger v1.0
        public interface ILogger
        {
            void Log(string message);
        }");

            Console.WriteLine("----------------------------------");
            Console.WriteLine("이후 새로운 기능이 필요해서 ILogger 인터페이스에 2개의 메서드를 추가한 ILogger v2.0을 출시한다고 가정하자.");
            Console.WriteLine(@"public interface ILogger
    {
        void Log(string message);

        // 추가된 멤버들
        void Log(Exception ex) => Log(ex.Message);
        void Log(string logType, string msg)
        {
            안에서 새로운 처리
        }
    }");

            MyLogger logger = new MyLogger();
            try
            {
                Console.WriteLine("숫자를 입력하면 기존것을 실행하고 아니면 새로운 것을 사용한다");
                int message = Convert.ToInt32(Console.ReadLine());
                logger.Log(message.ToString());
            }
            catch(Exception ex)
            {
                logger.Log(ex);
            }

                       

        }
    }

    class MyLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("기존 인터페이스 Log");
            Console.WriteLine(message);
        }

        // 디폴트 구현을 사용하지 않고 새로 정의함
        public void Log(Exception ex)
        {
            Console.WriteLine("새로운 인터페이스 Log");
            Console.WriteLine(ex.ToString());
            Console.WriteLine("-----------");

            //////////////////////////
            //한가지 주의할 점은 인터페이스의 디폴트 멤버 구현을 엑세스하기 위해서는 인터페이스로 캐스팅된 변수를 사용한다는 점이다
            //예를 들어, 위 ILogger.Log(string logType, string msg) 메서드에서 정의된 디폴트 구현은 MyLogger 객체에서 직접 엑세스할 수 없고, ILogger로 캐스팅 된 후에 엑세스할 수 있다
            //MyLogger myLogger = new MyLogger();
            //myLogger.Log("Error", "Invaild Error"); //여기서에러

            ILogger logger1 = new MyLogger();
            logger1.Log("Error", "Invaild data");

            Console.WriteLine("한가지 주의할 점은 인터페이스의 디폴트 멤버 구현을 엑세스하기 위해서는 인터페이스로 캐스팅된 변수를 사용한다는 점이다");
            Console.WriteLine("예를 들어, 위 ILogger.Log(string logType, string msg) 메서드에서 정의된 디폴트 구현은 MyLogger 객체에서 직접 엑세스할 수 없고, ILogger로 캐스팅 된 후에 엑세스할 수 있다");

            Console.WriteLine(@"
            ILogger logger1 = new MyLogger();
            logger1.Log(\'Error\', \'Invaild data\');");
        }
    }
}
