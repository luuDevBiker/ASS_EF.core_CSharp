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
        private DatabaseContext _dbContext;
        private List<Person> _lstperson;
        private List<DanhBa> _lstdanhBa;

        public Services()
        {
            _dbContext = new DatabaseContext();
            getListDanhba();
            getListPerson();
        }
        // lấy dữ liệu DanhBa từ DB đổ lên _lstdanhBa
        public List<DanhBa> getListDanhba()
        {
            try
            {
                return _lstdanhBa = _dbContext.DanhBas.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        // lấy dữ liệu từ DB person đổ lên _lsrperson
        public List<Person> getListPerson()
        {
            try
            {
                return _lstperson = _dbContext.People.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        // gửi dữ liệu _lstdanhBa lên form 
        public List<DanhBa> senderListDanhba()
        {
            try
            {
                return _lstdanhBa;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        // gửi dữ liệu _lstperson lên form 
        public List<Person> senderListPerson()
        {
            try
            {
                return _lstperson;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public Guid getId(int index)
        {
            throw new NotImplementedException();
        }

        public string saveChangeData()
        {
            try
            {
                _dbContext.SaveChanges();
                return "Done";
            }
            catch (Exception e)
            {
                return "Error : " + e.Message;
            }
        }
    }
}
