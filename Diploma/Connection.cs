﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Diploma
{
    /// <summary>
    /// Something like singleton
    /// </summary>
    class GlobalConnection
    {
        private static SqlConnection connection;
        private static GlobalConnection instance;

        public static SqlConnection Connection
        {
            get
            {
                if (instance == null)
                {
                    throw new NullReferenceException("Подключение не создано");
                }
                else
                {
                    return connection;
                }
            }
            private set
            {
                connection = value;
            }
        }
        public static SqlDataReader Reader { get; private set; }

        private GlobalConnection()
        { }

        public static void SetSQLConnection(SqlConnection con)
        {
            if (instance == null)
            {
                instance = new GlobalConnection();
                Connection = con;
            }
        }
        public static void ExecReader(string query)
        {
            SqlCommand cmd = new SqlCommand(query, Connection);
            Reader = cmd.ExecuteReader();
        }
        public static void CloseReader()
        {
            Reader.Close();
        }
        public static int UpdateGasStation(string loc, string brand, int id)
        {
            string query = "update gas_station set location = @location, brand = @brand where id = @id";
            SqlParameter par1 = new SqlParameter("@location", SqlDbType.NVarChar);
            par1.Value = loc;
            SqlParameter par2 = new SqlParameter("@brand", SqlDbType.NVarChar);
            par2.Value = brand;
            SqlParameter par3 = new SqlParameter("@id", SqlDbType.Int);
            par3.Value = id;
            SqlCommand cmd = new SqlCommand(query, Connection);
            cmd.Parameters.Add(par1);
            cmd.Parameters.Add(par2);
            cmd.Parameters.Add(par3);
            return cmd.ExecuteNonQuery();
        }
        public static int UpdateGasDeliver(GasDeliverType type, int GSID, int id)
        {
            string query = "update gas_deliver set type = @type, gas_station_id = @gas_station_id where id = @id";
            SqlParameter par1 = new SqlParameter("@type", SqlDbType.NVarChar);
            par1.Value = type.ToString();
            SqlParameter par2 = new SqlParameter("@gas_station_id", SqlDbType.Int);
            par2.Value = GSID;
            SqlParameter par3 = new SqlParameter("@id", SqlDbType.Int);
            par3.Value = id;
            SqlCommand cmd = new SqlCommand(query, Connection);
            cmd.Parameters.Add(par1);
            cmd.Parameters.Add(par2);
            cmd.Parameters.Add(par3);
            return cmd.ExecuteNonQuery();
        }
        public static int UpdateStaff(string fullName, EmployeePosition position, int GSID, int id)
        {
            string query = "update staff set full_name = @full_name, position = @position, gas_station_id = @gas_station_id where id = @id";
            SqlParameter par1 = new SqlParameter("@full_name", SqlDbType.NVarChar);
            par1.Value = fullName;
            SqlParameter par2 = new SqlParameter("@position", SqlDbType.NVarChar);
            par2.Value = position.ToString();
            SqlParameter par3 = new SqlParameter("@gas_station_id", SqlDbType.Int);
            par3.Value = GSID;
            SqlParameter par4 = new SqlParameter("@id", SqlDbType.Int);
            par4.Value = id;
            SqlCommand cmd = new SqlCommand(query, Connection);
            cmd.Parameters.Add(par1);
            cmd.Parameters.Add(par2);
            cmd.Parameters.Add(par3);
            cmd.Parameters.Add(par4);
            return cmd.ExecuteNonQuery();
        }
        public static int InsertGasStation(string loc, string brand)
        {
            string query = "insert into gas_station(location, brand) values(@location, @brand)";
            SqlParameter par1 = new SqlParameter("@location", SqlDbType.NVarChar);
            par1.Value = loc;
            SqlParameter par2 = new SqlParameter("@brand", SqlDbType.NVarChar);
            par2.Value = brand;
            SqlCommand cmd = new SqlCommand(query, Connection);
            cmd.Parameters.Add(par1);
            cmd.Parameters.Add(par2);
            return cmd.ExecuteNonQuery();
        }
        public static int InsertGasDeliver(GasDeliverType type, int GSID)
        {
            string query = "insert into gas_deliver(type, gas_station_id) values(@type, @gas_station_id)";
            SqlParameter par1 = new SqlParameter("@type", SqlDbType.NVarChar);
            par1.Value = type.ToString();
            SqlParameter par2 = new SqlParameter("@gas_station_id", SqlDbType.Int);
            par2.Value = GSID;
            SqlCommand cmd = new SqlCommand(query, Connection);
            cmd.Parameters.Add(par1);
            cmd.Parameters.Add(par2);
            return cmd.ExecuteNonQuery();
        }
        public static int InsertStaff(string fullName, EmployeePosition position, int GSID)
        {
            string query = "insert into staff(full_name, position, gas_station_id) values(@full_name, @position, @gas_station_id)";
            SqlParameter par1 = new SqlParameter("@full_name", SqlDbType.NVarChar);
            par1.Value = fullName;
            SqlParameter par2 = new SqlParameter("@position", SqlDbType.NVarChar);
            par2.Value = position.ToString();
            SqlParameter par3 = new SqlParameter("@gas_station_id", SqlDbType.Int);
            par3.Value = GSID;
            SqlCommand cmd = new SqlCommand(query, Connection);
            cmd.Parameters.Add(par1);
            cmd.Parameters.Add(par2);
            cmd.Parameters.Add(par3);
            return cmd.ExecuteNonQuery();
        }
    }
}