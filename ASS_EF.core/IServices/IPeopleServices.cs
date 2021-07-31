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
        //thêm Person.
        string addPerson(Person People);
        // sửa Person.
        string updateDanhBa(Person People);
        // xóa Person.
        string xoaDanhBa(Person People);
    }
}
