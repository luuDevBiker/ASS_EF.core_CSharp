using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASS_EF.core.Context;
using ASS_EF.core.Models;

namespace ASS_EF.core.Services
{
    public partial class Services : IServices.IServices
    {

        public string updatePerson(Person People)
        {
            try
            {
                _dbContext.People.Update(People);
                _lstperson[_lstperson.FindIndex(x => x.IdPp == People.IdPp)] = People;
                return "Thông tin người dùng cập nhật thành công.";
            }
            catch (Exception e)
            {
                return "Error : Thông tin người dùng cập nhật thất bại. \n" + e.Message;
            }
        }
        public string addPerson(Person People)
        {
            try
            {
                _dbContext.Add(People);
                _lstperson.Add(People);
                return "Thêm thông tin người dùng thành công.";
            }
            catch (Exception e)
            {
                return "Error !! Thêm thông tin người dùng thất bại.\n" + e.Message;
            }

        }


        public string xoaPerson(Person People)
        {
            try
            {
                _dbContext.People.Remove(People);
                _lstperson.RemoveAt(_lstperson.FindIndex(x=>x.IdPp == People.IdPp));
                return "Xóa thông tin người dùng thành công.";
            }
            catch (Exception e)
            {
                return "Xóa thông tin người dùng thất bại. \n" + e.Message;
            }
        }
    }
}
