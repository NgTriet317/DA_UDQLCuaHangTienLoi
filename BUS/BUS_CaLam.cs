using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
	public class BUS_CaLam
	{
		DAL_CaLam dal = new DAL_CaLam();
		public DataTable LayDSCalam()
		{
			return dal.LayDSCalam();
		}
	}
}
