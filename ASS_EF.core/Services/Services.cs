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
        private DatabaseContext _dbContext =new DatabaseContext();
        private List<Person> _lstperson;
        private List<DanhBa> _lstdanhBa;
        private List<VwPeopleDanhba> _peopleDanhbas;

        public Services()
        {
            getListDanhba();
            getListPerson();
            getListView();
            _dbContext = new DatabaseContext();
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
                return "Lưu thành công.";
            }
            catch (Exception e)
            {
                return "Error : Lưu thất bại.\n" + e.Message;
            }
        }

        public List<VwPeopleDanhba> sendPeopleDanhbas()
        {
            return _peopleDanhbas;
        }

        public List<VwPeopleDanhba> getListView()
        {
            _peopleDanhbas = _dbContext.VwPeopleDanhbas.ToList();
            return _peopleDanhbas;
        }
    }
}
