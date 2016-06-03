using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iBatisNetTest.Dao;
using iBatisNetTest.Domain;
using IBatisNet.DataMapper;

namespace iBatisNetTest
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnQuery_Click(object sender, EventArgs e)
        {
            //查询用户
            try
            {
                PersonDao dao = new PersonDao();
                IList<Person> ListPerson = dao.GetList();
                Label1.Text = "查询用户成功";
                foreach (Person p in ListPerson)
                {
                    Label1.Text += p.Id + ":" + p.Name;
                }
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }
        }

        protected void BtnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                Person person = new Person();
                person.Id = 456;
                person.Name = "Thomas";
                PersonDao dao = new PersonDao();
                dao.AddPerson(person);
                Label1.Text = "添加用户成功,result返回UserID为";
            }
            catch (Exception ex)
            {
               Label1.Text = ex.Message;
            }
        }

        protected void BtnUpdateUser_Click(object sender, EventArgs e)
        {
            // try
            // {
            //     iBatisTest.Domain.Sysuser model = new iBatisTest.Domain.Sysuser();
            //     model.Userid = 1;//修改Userid为1的用户信息
            //     model.Password = "1234";
            //     model.Loginname = "deanu";
            //     model.Sex = "男";
            //     model.Birthday = Convert.ToDateTime("1970-01-01");
            //     model.Idcard = "310200198001014200";
            //     model.Officephone = "76279528";
            //     model.Familyphone = "76279528";
            //     model.Mobilephone = "13880000000";
            //     model.Email = "1@qq.com";
            //     model.Address = null;
            //     model.Zipcode = "610000";
            //     model.Remark = "修改ID为1的用户";
            //     model.Status = "有效";
            //     ISqlMapper mapper = Mapper.Instance(); //得到ISqlMapper实例    
            //     mapper.Update("SysuserMap.UpdateSysuser", model);//调用Update方法
            //     Label1.Text = "修改用户成功";
            // }
            // catch (Exception ex)
            // {
            //     Label1.Text = ex.Message;
            // }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            // //删除用户
            // try
            // {
            // ISqlMapper mapper = Mapper.Instance(); //得到ISqlMapper实例   
            // int Userid = 1;
            // mapper.Delete("SysuserMap.DeleteSysuser", Userid);//调用Delete方法
            //     Label1.Text = "删除用户成功";
            // }
            // catch (Exception ex)
            // {
            //     Label1.Text = ex.Message;
            // }
        }
    }
}