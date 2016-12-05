using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace RefDll
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //加载数据集
            string plugin = "TestDll.dll";
            Assembly assembly = Assembly.LoadFrom(plugin);
            
            //获取数据集中所有的类型
            Type[] types = assembly.GetTypes();
            //创建数据集中类型的对象实例
            foreach(var type in types)
            {
               //调用无参构造的方式创建实例
                object obj1 = assembly.CreateInstance(type.FullName);
               obj1 = Activator.CreateInstance(type);
               //调用有参构造的方式创建实例
                object[] objs=new object[1];
                objs[0]=1;
                object obj2 = assembly.CreateInstance(type.FullName, false, BindingFlags.CreateInstance, null, objs, null, null);
                obj2 = Activator.CreateInstance(type, objs);
                //获取所有方法
                MethodInfo[] minfos = type.GetMethods();
                //激活func1
                foreach (MethodInfo me in minfos)
                {
                    if (me.Name == "func1")
                    {
                        me.Invoke(obj1, null);
                        type.InvokeMember(me.Name,BindingFlags.InvokeMethod,null,obj1,null);
                    }
                }
                //获取所有成员
                MemberInfo[] memInfo = type.GetMembers();
                //获取所有的属性
                PropertyInfo[] pinfo = type.GetProperties();
                //获取所有的构造函数
                ConstructorInfo[] cinfo = type.GetConstructors();
                //获取所有的字段
                FieldInfo[] finfo = type.GetFields();
                //获取所有的事件
                EventInfo[] einfo = type.GetEvents();
              
            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
