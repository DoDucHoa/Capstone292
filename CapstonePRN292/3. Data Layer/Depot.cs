using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstonePRN292._3._Data_Layer
{
    class Depot
    {
        public Depot(int id, string name, string status)
        {
            this.ID = id;
            this.Name = name;
            this.Status = status;
        }

        private int ID;
        private string name;
        private string status;

        public int ID1 { get => ID; set => ID = value; }
        public string Name { get => name; set => name = value; }
        public string Status { get => status; set => status = value; }
    }
}
