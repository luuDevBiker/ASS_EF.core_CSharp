using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASS_EF.core.Models;
// using ASS_EF.core.Services;
// using static ASS_EF.core.Services.Services;

namespace ASS_EF.core.IServices
{
    partial interface IServices
    {

        //lấy dữ liệu từ CSDL đổ lên services.
        List<DanhBa> getListDanhba();
        List<Person> getListPerson();
        //Truyền dữ liệu từ services lên form.
        List<DanhBa> senderListDanhba();
        List<Person> senderListPerson();
        // tìm ID của danh bạ thông qua số index của Person trong list danh bạ , index này được tạo ra khi query data.
        Guid getId(int index);
        // lưu nhưng thay đổi trên form
        string saveChangeData();
        // gửi lên form list data đã được join
        List<VwPeopleDanhba> sendPeopleDanhbas();
        // lấy giá trị list ViewData trong database lên -- table View trong SQL
        List<VwPeopleDanhba> getListView();
    }
}
