using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASS_EF.core.Context;
using ASS_EF.core.Models;

namespace ASS_EF.core.Services
{
    public partial class Services : IServices.IServices
    {
        // thêm danh bạ
        public string addDanhBa(DanhBa DanhBa)
        {
            try
            {
                _lstdanhBa.Add(DanhBa);//thềm vào list danh bạ  
                _lstDanhBasNewAdd.Add(DanhBa);
                var person = _lstperson.Where(x => x.IdPp == DanhBa.IdDbPp).FirstOrDefault();// lấy thông tin của người có cùng ID với danh bạ sau đó thêm vào danh sách người dùng danh bạ
                var data = new VwPeopleDanhba
                {
                    Id = person.IdPp,
                    Name = person.TenPp + "      " + person.TenDemPp + "      " + person.TenPp,
                    YearOfBirth = person.NamSinhPp,
                    Sex = person.GioiTinhPp,
                    Phone1 = DanhBa.Sdt1,
                    Phone2 = DanhBa.Sdt2,
                    Mail = DanhBa.Mail,
                    GhiChu = DanhBa.GhiChu
                };
                _peopleDanhbas.Add(data);
                _lstPeopleDanhbasNewAdd.Add(data);
                return "Thêm Thông tin danh bạ thành công.";
            }
            catch (Exception e)
            {
                return "Thêm Danh bạ thất bại .\n" + e.Message;
            }
        }
        // cập nhật thông tin danh bạ
        public string updateDanhBa(DanhBa DanhBa)
        {
            try
            {
                var indx = _lstPeopleDanhbasNewAdd.FindIndex(x => x.Id == DanhBa.IdDbPp);
                if (indx >= 0)
                {
                    _lstPeopleDanhbasNewAdd[indx].Phone1 = DanhBa.Sdt1;
                    _lstPeopleDanhbasNewAdd[indx].Phone2 = DanhBa.Sdt2;
                    _lstPeopleDanhbasNewAdd[indx].Mail = DanhBa.Mail;
                    _lstPeopleDanhbasNewAdd[indx].GhiChu = DanhBa.GhiChu;
                }
                _lstdanhBa[_lstdanhBa.FindIndex(x => x.IdDbPp == DanhBa.IdDbPp)] = DanhBa;// gán lại giá trị trong list danh bạ
                var idex = _peopleDanhbas.FindIndex(x => x.Id == DanhBa.IdDbPp);// tìm vị trí của bản di trong list người dùng danh bạ thông qua ID --> cập nhật thông tin
                _peopleDanhbas[idex].Phone1 = DanhBa.Sdt1;
                _peopleDanhbas[idex].Phone2 = DanhBa.Sdt2;
                _peopleDanhbas[idex].Mail = DanhBa.Mail;
                _peopleDanhbas[idex].GhiChu = DanhBa.GhiChu;
                return "Thông tin danh bạ cập nhật thành công.";
            }
            catch (Exception e)
            {
                return "Error !! cập nhật thất bại.\n" + e.Message;
            }
        }
        // xóa danh bạ
        public string xoaDanhBa(DanhBa DanhBa)
        {
            try
            {
                var indx = _peopleDanhbas.FindIndex(x => x.Id == DanhBa.IdDbPp);
                if (indx >= 0)
                    _lstPeopleDanhbasNewAdd.RemoveAt(indx);
                _lstdanhBa.RemoveAt(_lstperson.FindIndex(x => x.IdPp == DanhBa.IdDbPp));// xóa trong list danh bạ
                _peopleDanhbas.RemoveAt(_peopleDanhbas.FindIndex(x => x.Id == DanhBa.IdDbPp));// xóa trong list danh sách người dùng danh bạ 
                return "Xóa thông tin danh bạ thành công.";
            }
            catch (Exception e)
            {
                return "Xóa thông tin danh bạ thất bại.\n" + e.Message;
            }
        }
    }
}
