using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
         
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (MyClass mc=new MyClass())
            {
                
            }
            MyClass mc2 = new MyClass();
        }
    }

  
    class MyClass:IDisposable
    {

        /// <summary>
        /// 非托管资源
        /// </summary>
        private FileStream file;

        /// <summary>
        /// 标志是否被释放的布尔量
        /// </summary>
        private bool Disposed = false;

        /// <summary>
        /// 继承自IDispose的Dispose方法，保证在使用using关键字时能够及时释放资源.
        /// 注意using语句块结束后是不会调用析构函数的。
        /// </summary>
        public void Dispose()
        {
            if (Disposed == false)
            {
                if (file != null)
                {
                    file.Close();
                }
                Disposed = true;
            }
            //将对象从垃圾回收列表中移除
            //这样在垃圾回收时只释放托管资源，从而提高了效率
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 在析构函数中同样进行非托管资源的是否，这样在编译阶段将会生成Finalize()方法，保证系统在垃圾回收阶段调用该方法释放
        /// 非托管资源.
        /// 注意这里定义的析构函数只是为了生存Finalize的方法，实际程序的执行过程中是不会进入析构函数中的。
        /// </summary>
        ~MyClass()
        {
            if (Disposed == false)
            {
                if (file != null)
                {
                    file.Close();
                }
                Disposed = true;
            }
        }
    }
}
