using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace LambdaTs
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> add = (x, y) => x + y;
            int r = add(1, 2);
            Console.WriteLine(r);


            Func<int, Func<int, int>> add2 = x =>( y => (x + y));
            r = add2(2)(8);
            Console.WriteLine(r);

            var add3 = add2(3);
            Console.WriteLine(add3(0));
            Console.WriteLine(add3(1));

            Func<int> func = () => 123;
            Console.WriteLine(func());

            Action<int> print = x => Console.WriteLine(x);
            print(456);

            Func<SqlConnection, Func<String, DataSet>> Execsql = x => y =>
            {
                using (x)
                {
                    x.Open();
                    var com = x.CreateCommand();
                    DataSet ds = new DataSet();
                    com.CommandText = y;
                    SqlDataAdapter adapter = new SqlDataAdapter(com);
                    adapter.Fill(ds);
                    return ds;
                }
            };

            //Execsql(new SqlConnection("xxx"))("select * from xxx");

            Func<string, Func<SqlConnection, DataSet>> Execsql2 = x => y => Execsql(y)(x);

            //Execsql2("select * from xxx")(new SqlConnection());

            
        }
    }
}
