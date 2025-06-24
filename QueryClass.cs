using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem
{
    public static class QueryClass
    {
        public static string ClassView(string searchText)
        {
            return "SELECT * FROM tblClass WHERE cName LIKE '%" + searchText + "%' ORDER BY cName ASC";
        }

        public static string ClassInsert(string className)
        {
            return "INSERT INTO tblClass (cName) VALUES ('" + className + "')";
        }

        public static string ClassUpdate(int classId, string className)
        {
            return "UPDATE tblClass SET cName = '" + className + "' WHERE cID = " + classId;
        }

        public static string ClassDelete(int classId)
        {
            return "DELETE FROM tblClass WHERE cID = " + classId;
        }

        public static string ClassById(int classId)
        {
            return "SELECT * FROM tblClass WHERE cID = " + classId;
        }

        #region User Query
        public static string UserView(string searchText)
        {
            return "Select userID, uName, uUsername, uPhone, uStatus from tblUser where uName like '%" + searchText + "%' order by uName ASC";
        }
        #endregion
    }
}
