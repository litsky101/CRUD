using CRUD.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Controller
{
    public class EmployeeController
    {
        AppInterface view;
        MySQLHelper db = new MySQLHelper();

        public EmployeeController(AppInterface _view)
        {
            view = _view;
            view.SetController(this);
        }


        public DataTable GetEmployee()
        {
            try
            {
                DataTable dt = new DataTable();

                db = new MySQLHelper();

                dt = db.GetEmployee(view);

                return dt;
            }
            catch 
            {

                throw;
            }
        }

        public int Save()
        {
            try
            {
                int result = 0;

                db = new MySQLHelper();

                result = db.SaveEmployee(view);

                return result;
            }
            catch
            {

                throw;
            }
        }

        public int Update()
        {
            try
            {
                int result = 0;

                db = new MySQLHelper();

                result = db.UpdateEmployee(view);

                return result;
            }
            catch
            {

                throw;
            }
        }

        public int Delete()
        {
            try
            {
                int result = 0;

                db = new MySQLHelper();

                result = db.DeleteEmployee(view);

                return result;
            }
            catch
            {

                throw;
            }
        }
    }
}
