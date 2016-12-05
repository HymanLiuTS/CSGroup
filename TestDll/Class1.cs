using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace TestDll
{
    public class Test 
    {
        //字段
        public int age = 0;
        
        private string name;
        //属性
        public string Name
        {
            get { return name; }
        }
        //无参构造函数
        public Test()
        {

        }
        //带参构造函数
        public Test(int i)
        {
            age = i;
        }
        //方法
        public void func1()
        {
            MessageBox.Show("func1");
        }
        //事件
        //定义委托
        public delegate void BtnClickHandle(object sender, EventArgs e);
        //定义事件
        public event BtnClickHandle UserControlBtnClicked;
    }
}
