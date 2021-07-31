using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASS_EF.core.Models;

namespace ASS_EF.core.IServices
{
    partial interface IServices
    {
        //thêm Danh bạ.
        string addDanhBa(DanhBa DanhBa);
        // sửa danh bạ.
        string updateDanhBa(DanhBa DanhBa);
        // xóa danh bạ.
        string xoaDanhBa(DanhBa DanhBa);
    }
}
