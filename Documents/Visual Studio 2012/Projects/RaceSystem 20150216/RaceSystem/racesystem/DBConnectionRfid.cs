using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace RaceSystem
{
    class DBConnectionRfid
    {
        public List<RfidBean> getAllRfidTag()
        {
            List<RfidBean> list = new List<RfidBean>();
            MySqlConnection con = getConnection();
            MySqlCommand command = new MySqlCommand(SQLConstants.SELECT_ALL_RFID,con);

            con.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                RfidBean bean = new RfidBean();
                bean.Rfid_No = Convert.ToString(reader["rfid_no"]);
                bean.Rfid_Tag_No = Convert.ToString(reader["rfid_tag_no"]);

                list.Add(bean);
            }

            return list;
        }

        public void removeRifdTag(List<RfidBean> list)
        {
            MySqlConnection con = getConnection();

            foreach (RfidBean bean in list)
            {
                MySqlCommand mysqlCommand = new MySqlCommand(SQLConstants.REMOVE_RFID, con);
                mysqlCommand.Parameters.AddWithValue("@rfid_no", bean.Rfid_No );
               
                con.Open();
                mysqlCommand.ExecuteScalar();
                closeConnection(con);
            }
        }

        public List<RfidBean> registerRfidTag(string rfid_tag_no)
        {
            List<RfidBean> list = new List<RfidBean>();
            MySqlConnection conn = getConnection();
            MySqlCommand comm = new MySqlCommand(SQLConstants.ADD_RFID, conn);
            comm.Parameters.AddWithValue("@rfid_tag_no", rfid_tag_no);
            conn.Open();
            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                RfidBean bean = new RfidBean();
                bean.Rfid_No = Convert.ToString(reader["rfid_no"]);
                bean.Rfid_Tag_No = Convert.ToString(reader["rfid_tag_no"]);

                list.Add(bean);
            }
            closeConnection(conn);
            return list;

            
        }

    






        private MySqlConnection getConnection()
        {
            MySqlConnection conn = new MySqlConnection(SQLConstants.DBCONNECTION);
            return conn;
        }

        private void closeConnection(MySqlConnection conn)
        {
            try
            {
                conn.Close();
            }
            catch (Exception ex)
            {

            }

        }
    }
}
