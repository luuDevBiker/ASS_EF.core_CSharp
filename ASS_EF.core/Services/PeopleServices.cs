using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASS_EF.core.Context;
using ASS_EF.core.Models;
using Microsoft.EntityFrameworkCore;

namespace ASS_EF.core.Services
{
    public partial class Services : IServices.IServices
    {
        // cập nhật thông tin người dùng
        public string updatePerson(Person People)
        {
            try
            {
                var indexnew = _lstpersonNewAdd.FindIndex(x => x.IdPp == People.IdPp);
                if (indexnew >= 0)
                    _lstpersonNewAdd[indexnew] = People;// cập nhật list người dùng mới thêm
                _lstperson[_lstperson.FindIndex(x => x.IdPp == People.IdPp)] = People;// cập nhật trong list người dùng
                var index = _peopleDanhbas.FindIndex(x => x.Id == People.IdPp);// cập nhật trong list danh bạ người dùng
                if (index >= 0)
                {
                    _peopleDanhbas[index].Name = People.HoPp + "      " + People.TenDemPp + "      " + People.TenPp;
                    _peopleDanhbas[index].YearOfBirth = People.NamSinhPp;
                    _peopleDanhbas[index].Sex = People.GioiTinhPp;
                    _dbContext.People.Update(People);
                }
                return "Thông tin người dùng cập nhật thành công.";
            }
            catch (Exception e)
            {
                return "Error : Thông tin người dùng cập nhật thất bại. \n" + e.Message;
            }
        }
        //thêm người dùng
        public string addPerson(Person People)
        {
            try
            {
                _lstpersonNewAdd.Add(People);// thêm vào list người dùng mới
                _lstperson.Add(People);// thêm vào list người dùng
                return "Thêm thông tin người dùng thành công.";
            }
            catch (Exception e)
            {
                return "Error !! Thêm thông tin người dùng thất bại.\n" + e.Message;
            }

        }
        // xóa người dùng
        public string xoaPerson(Person People)
        {
            try
            {
                var idex = _lstpersonNewAdd.FindIndex(x => x.IdPp == People.IdPp);
                if (idex >= 0)
                    _lstpersonNewAdd.RemoveAt(idex);// xóa bản ghi trong list người mới
                _lstperson.RemoveAt(_lstperson.FindIndex(x => x.IdPp == People.IdPp));// xóa bản ghi trong list người
                var index = _peopleDanhbas.FindIndex(x => x.Id == People.IdPp);
                if (index >= 0)
                    _peopleDanhbas.RemoveAt(index);// xóa trong list người dùng danh bạ
                return "Xóa thông tin người dùng thành công.";
            }
            catch (Exception e)
            {
                return "Xóa thông tin người dùng thất bại. \n" + e;
            }
        }
    }
}
