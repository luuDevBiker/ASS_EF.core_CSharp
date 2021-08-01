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
        string updatePerson(Person People);
        // xóa Person.
        string xoaPerson(Person People);
    }
}
