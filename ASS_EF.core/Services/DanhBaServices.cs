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
        public string addDanhBa(DanhBa DanhBa)
        {
            try
            {
                _dbContext.DanhBas.Add(DanhBa);
                _lstdanhBa.Add(DanhBa);
                return "Thêm Thông tin danh bạ thành công.";
            }
            catch (Exception e)
            {
                return "Thêm Danh bạ thất bại .\n" + e.Message;
            }
        }

        public string updateDanhBa(DanhBa DanhBa)
        {
            try
            {
                _dbContext.DanhBas.Update(DanhBa);
                _lstdanhBa[_lstdanhBa.FindIndex(x => x.IdDbPp == DanhBa.IdDbPp)] = DanhBa;
                return "Thông tin danh bạ cập nhật thành công.";
            }
            catch (Exception e) 
            {
                return "Error !! cập nhật thất bại.\n" + e.Message;
            }
        }

        public string xoaDanhBa(DanhBa DanhBa)
        {
            try
            {
                _dbContext.Remove(DanhBa);
                _lstdanhBa.RemoveAt(_lstperson.FindIndex(x => x.IdPp == DanhBa.IdDbPp));
                return "Xóa thông tin danh bạ thành công.";
            }
            catch (Exception e)
            {
                return "Xóa thông tin danh bạ thất bại.\n" + e.Message;
            }
        }
    }
}
