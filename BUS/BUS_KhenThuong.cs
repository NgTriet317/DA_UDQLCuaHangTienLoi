using DAL;
using ET;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
	public class BUS_KhenThuong
	{
		DAL_KhenThuong kthuong = new DAL_KhenThuong();

		public DataTable LayDSKhenThuong()
		{
			return kthuong.LayDSKhenTHuong();
		}

        public bool ThemKhenThuong(ET_KhenThuong et)
		{
			return kthuong.ThemKhenThuong(et);
        }

        public bool SuaKhenThuong(ET_KhenThuong et)
		{
			return kthuong.SuaKhenThuong(et);
        }

    }
}
