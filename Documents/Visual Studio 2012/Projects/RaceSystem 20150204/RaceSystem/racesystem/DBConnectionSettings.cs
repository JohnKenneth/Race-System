using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace RaceSystem
{
    class DBConnectionSettings
    {
        /* RFID Address */
        public void updateRFIDAddress(String address)
        {
            MySqlConnection connection = getConnection();
            MySqlCommand command = new MySqlCommand(SQLConstants.UPDATE_SETTINGS_ADDRESS, connection);
            Console.WriteLine(SQLConstants.UPDATE_SETTINGS_ADDRESS);
            command.Parameters.AddWithValue("@rfid_address", address);

            command.ExecuteNonQuery();
        }

        public String getRFIDAddress()
        {
            MySqlConnection connection = getConnection();
            String address = "";
            MySqlCommand command = new MySqlCommand(SQLConstants.SELECT_RFID_ADDRESS, connection);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    address = (string)reader["rfid_address"];
                }
            }
            finally
            {
                // Always call Close when done reading.
                reader.Close();
            }

            return address;
        }
        /* END RFID Address */

        /* RFID Comport */
        public void updateRFIDComPort(String comport)
        {
            MySqlConnection connection = getConnection();
            MySqlCommand command = new MySqlCommand(SQLConstants.UPDATE_SETTINGS_COMPORT, connection);
            Console.WriteLine(SQLConstants.UPDATE_SETTINGS_COMPORT);
            command.Parameters.AddWithValue("@rfid_comport", comport);

            command.ExecuteNonQuery();
        }

        public String getRFIDComPort()
        {
            MySqlConnection connection = getConnection();
            String comport = "";
            MySqlCommand command = new MySqlCommand(SQLConstants.SELECT_RFID_COMPORT, connection);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    comport = (string)reader["rfid_comport"];
                }
            }
            finally
            {
                // Always call Close when done reading.
                reader.Close();
            }

            return comport;
        }
        /* END RFID Comport */

        /* Connections */
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
