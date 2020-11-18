using System;
using System.Runtime.InteropServices;
using static System.Console;

namespace csharp9test
{
        public class CovariantReturnType
        {
                public CovariantReturnType()
                {
                        Audi audi = new();
                        var whatClass = audi.GetEngine();
                        whatClass.Print();

                }

                public abstract class Car
                {
                        public abstract Engine GetEngine();
                }

                public class Audi : Car
                {
                        public override V6Engine GetEngine()
                        {
                                return new V6Engine();
                        }
                }

                public class Engine 
                {
                        public virtual void Print() => Console.WriteLine("I'm Engine");
                }
                public class V6Engine : Engine 
                {
                        public override void Print() => Console.WriteLine("I'm V6Engine");
                }
        }
}