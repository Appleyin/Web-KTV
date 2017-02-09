using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ktv前端
{

  public   class DBHelper
    {
        //连接字符串
        private static string Connstr = "Data Source=.;Initial Catalog=MyKTV;User ID=sa;Pwd=sa";
        //SqlConnection连接对象
        private static SqlConnection connection;
        //封装SqlConnection对象
        public static SqlConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    connection = new SqlConnection(Connstr);
                }
                return connection;
            }
        }

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public static void OpenConnection()
        {
            //如果数据库已经关闭，则先打开；如果数据库损坏，则先关闭再打开
            if (Connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            else if (Connection.State == ConnectionState.Broken)
            {
                connection.Close();//先关闭
                connection.Open(); //再打开
            }
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public static void ClosedConnection()
        {
            if (Connection.State == ConnectionState.Open || Connection.State == ConnectionState.Broken)
            {
                connection.Close();
            }
        }

    }
}
