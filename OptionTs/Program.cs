using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            var p1 = Option.Some(10);
            var p2 = Option.Some(10);
            if (p1 == p2)
            {
                Console.WriteLine("Y");
            }
            else
            {
                Console.WriteLine("N");
            }
            int hashValue1 = p1.GetHashCode();
            int hashValue2 = p2.GetHashCode();
            int i = 10, j = 10;
            hashValue1 = i.GetHashCode();
            hashValue2 = j.GetHashCode();

            if (p1 == Option.None)
            {

            }
            //Console.ReadKey();
        }
    }

    /// <summary>
    /// sealed关键字将类密封，不能被其他类所继承
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class Option<T>
    {
        private readonly T value;
        public T Value
        {
            get { return value; }
        }

        private readonly bool hasValue;
        public bool HasValue { get { return hasValue; } }
        public bool IsSome { get { return hasValue; } }
        public bool IsNone { get { return !hasValue; } }

        public Option(T value)
        {
            this.value = value;
            this.hasValue = true;
        }

        private Option() { }
        public static readonly Option<T> None = new Option<T>();

        /// <summary>
        /// 定义方法，将Option类型对象隐式转换成Option<T>.None
        /// implicit 关键字用于声明隐式的用户定义类型转换运算符。 如果可以确保转换过程不会造成数据丢失，则可使用该关键字在用户定义类型和其他类型之间进行隐式转换。
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public static implicit operator Option<T>(Option option)
        {
            return Option<T>.None;
        }

        /// <summary>
        /// ==操作符的重载
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Option<T> a, Option<T> b)
        {
            return a.HasValue == b.HasValue &&
                EqualityComparer<T>.Default.Equals(a.Value, b.Value);
        }

        public static bool operator !=(Option<T> a, Option<T> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            int hashCode = hasValue.GetHashCode();
            if (HasValue)
                hashCode ^= value.GetHashCode();
            return hashCode;
        }
    }

    public sealed class Option
    {
        public static Option<T> Some<T>(T value)
        {
            return new Option<T>(value);
        }

        public static readonly Option None = new Option();
    }
}
