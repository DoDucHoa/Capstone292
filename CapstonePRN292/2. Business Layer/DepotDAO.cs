using CapstonePRN292._3._Data_Layer;
using DevExpress.XtraReports.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstonePRN292._2._Business_Layer
{
    public class DepotDAO
    {
        private static DepotDAO instance;

        public static DepotDAO Instance
        {
            get { if (instance == null) instance = new DepotDAO(); return DepotDAO.instance; }
            private set { DepotDAO.instance = value; }
        }

        private DepotDAO() { }

        //public List<Depot> LoadDepotList()
        //{
        //    List<Depot> depotList = new List<Depot>();

        //    DataTable dataTable = DataProvider.Instance.ex
        //}
    }
}
