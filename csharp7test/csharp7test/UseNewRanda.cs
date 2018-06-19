using System;
using static System.Console;
namespace csharp7test
{
    internal class UseNewRanda
    {
        public UseNewRanda()
        {
            Vector newRam = new Vector(10,20);
            newRam.X = 40;

            newRam[0] = 30;
            newRam[1] = 40;

            newRam.Move(34, 10);

            
        }
    }

    public class Vector
    {
        double x;
        double y;

        public Vector(double x) => this.x = x; //생성자 정의가능
        //{
        //   this.x = x;
        //}
        
        public Vector(double x, double y) //생성자지만 2개의 문장이므로 람다 식으로 정의 불가
        {
            this.x = x;
            this.y = y;
        }

        ~Vector() => Console.WriteLine("Destroy Vector()"); //소멸자 정의 가능

        public double X
        {
            get => x;
            set => x = value; //속정의 set 접근자 정의 가능;
        }

        public double Y
        {
            get => y;
            set => y = value;
        }

        public double this[int index] //클래스 배열
        {
            get => (index == 0) ? x : y;
            set => _ = (index == 0) ? x = value : y = value; // 인덱서의 set 접근자 정의 가능
        }

        private EventHandler positionChanged;
        public event EventHandler PositionChanged // 이벤트의 add/remove 접근자 정의가능
        {
            add => this.positionChanged += value;
            remove => this.positionChanged -= value;
        }

        public Vector Move(double dx, double dy)
        {
            x += dx;
            y += dy;

            positionChanged?.Invoke(this, EventArgs.Empty);
            PritIt();

            return this;
        }

        public void PritIt() => WriteLine(this);

        public override string ToString() => string.Format("x = {0}, y = {1}", x, y);
    }
}