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
    }
}