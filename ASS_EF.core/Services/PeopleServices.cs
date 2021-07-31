using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASS_EF.core.Models;

namespace ASS_EF.core.Services
{
    public partial class Services : IServices.IServices
    {
        public string addPerson(Person People)
        {
            try
            {
                var danhba = new DanhBa
                {
                    GhiChu = "",
                    IdDbPp = People.IdPp,
                    Mail = "",
                    Sdt1 = "",
                    Sdt2 = ""
                };
                _dbContext.People.Add(People);
                _lstperson.Add(People);
                _dbContext.DanhBas.Add(danhba);
                _lstdanhBa.Add(danhba);
                return "Done";
            }
            catch (Exception e)
            {
                return "Error : " + e.Message;
            }

        }

        public string updateDanhBa(Person People)
        {
            throw new NotImplementedException();
        }

        public string xoaDanhBa(Person People)
        {
            throw new NotImplementedException();
        }
    }
}
