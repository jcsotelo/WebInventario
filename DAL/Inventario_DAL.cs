using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using WebInventario.Models;

namespace WebInventario.DAL
{
    public class Inventario_DAL
    {
        SqlConnection _connection = null;
        SqlCommand _command = null;
        public static IConfiguration Configuration { get; set; }

        private string GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            return Configuration.GetConnectionString("DefaultConnection");

        }

        public List<Mov_Inventario> GetAll()
        {
            List<Mov_Inventario> InventarioList = new List<Mov_Inventario>();
            using ( _connection = new SqlConnection( GetConnectionString() ) )
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[dbo].[sp_get_inventario]";
                _connection.Open();
                SqlDataReader dr = _command.ExecuteReader();
                

                while (dr.Read())
                {
                    Mov_Inventario inventario = new Mov_Inventario();

                    inventario.COD_CIA = dr["COD_CIA"].ToString();
                    inventario.COMPANIA_VENTA_3 = dr["COMPANIA_VENTA_3"].ToString();
                    inventario.ALMACEN_VENTA = dr["ALMACEN_VENTA"].ToString();
                    inventario.TIPO_MOVIMIENTO = dr["TIPO_MOVIMIENTO"].ToString();
                    inventario.TIPO_DOCUMENTO = dr["TIPO_DOCUMENTO"].ToString();
                    inventario.NRO_DOCUMENTO = dr["NRO_DOCUMENTO"].ToString();
                    inventario.COD_ITEM_2 = dr["COD_ITEM_2"].ToString();
                    inventario.PROVEEDOR = dr["PROVEEDOR"].ToString();
                    inventario.ALMACEN_DESTINO = dr["ALMACEN_DESTINO"].ToString();
                    inventario.CANTIDAD = Convert.ToInt32(dr["CANTIDAD"]);
                    inventario.DOC_REF_1 = dr["DOC_REF_1"].ToString();
                    inventario.DOC_REF_2 = dr["DOC_REF_2"].ToString();
                    inventario.DOC_REF_3 = dr["DOC_REF_3"].ToString();
                    inventario.DOC_REF_4 = dr["DOC_REF_4"].ToString();
                    inventario.DOC_REF_5 = dr["DOC_REF_5"].ToString();
                    inventario.FECHA_TRANSACCION = Convert.ToDateTime(dr["FECHA_TRANSACCION"]).Date;
                    InventarioList.Add(inventario);
                }
                _connection.Close();
            }
            return InventarioList;

        }

        public bool Insert(Mov_Inventario model)
        {

            int id = 0;

            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[dbo].[sp_insert_inventario]";
                _command.Parameters.AddWithValue("@COD_CIA", model.COD_CIA);
                _command.Parameters.AddWithValue("@COMPANIA_VENTA_3", model.COMPANIA_VENTA_3);
                _command.Parameters.AddWithValue("@ALMACEN_VENTA", model.ALMACEN_VENTA);
                _command.Parameters.AddWithValue("@TIPO_MOVIMIENTO", model.TIPO_MOVIMIENTO);
                _command.Parameters.AddWithValue("@TIPO_DOCUMENTO", model.TIPO_DOCUMENTO);
                _command.Parameters.AddWithValue("@NRO_DOCUMENTO", model.NRO_DOCUMENTO);
                _command.Parameters.AddWithValue("@COD_ITEM_2", model.COD_ITEM_2);
                _command.Parameters.AddWithValue("@PROVEEDOR", model.PROVEEDOR);
                _command.Parameters.AddWithValue("@ALMACEN_DESTINO", model.ALMACEN_DESTINO);
                _command.Parameters.AddWithValue("@CANTIDAD", model.CANTIDAD);
                _command.Parameters.AddWithValue("@DOC_REF_1", model.DOC_REF_1);
                _command.Parameters.AddWithValue("@DOC_REF_2", model.DOC_REF_2);
                _command.Parameters.AddWithValue("@DOC_REF_3", model.DOC_REF_3);
                _command.Parameters.AddWithValue("@DOC_REF_4", model.DOC_REF_4);
                _command.Parameters.AddWithValue("@DOC_REF_5", model.DOC_REF_5);
                _command.Parameters.AddWithValue("@FECHA_TRANSACCION", model.FECHA_TRANSACCION);
                _connection.Open();
                id = _command.ExecuteNonQuery();
                _connection.Close();

                return id > 0? true : false;
                
            }

        }

        public Mov_Inventario GetById(Mov_Inventario model)
        {
            Mov_Inventario inventario = new Mov_Inventario();
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[dbo].[sp_get_inventarioByCia]";
                _command.Parameters.AddWithValue("@COD_CIA", model.COD_CIA);
                _command.Parameters.AddWithValue("@COMPANIA_VENTA_3", model.COMPANIA_VENTA_3);
                _command.Parameters.AddWithValue("@ALMACEN_VENTA", model.ALMACEN_VENTA);
                _command.Parameters.AddWithValue("@TIPO_MOVIMIENTO", model.TIPO_MOVIMIENTO);
                _command.Parameters.AddWithValue("@TIPO_DOCUMENTO", model.TIPO_DOCUMENTO);
                _command.Parameters.AddWithValue("@NRO_DOCUMENTO", model.NRO_DOCUMENTO);
                _command.Parameters.AddWithValue("@COD_ITEM_2", model.COD_ITEM_2);
                _connection.Open();
                SqlDataReader dr = _command.ExecuteReader();


                while (dr.Read())
                {                    
                    inventario.COD_CIA = dr["COD_CIA"].ToString();
                    inventario.COMPANIA_VENTA_3 = dr["COMPANIA_VENTA_3"].ToString();
                    inventario.ALMACEN_VENTA = dr["ALMACEN_VENTA"].ToString();
                    inventario.TIPO_MOVIMIENTO = dr["TIPO_MOVIMIENTO"].ToString();
                    inventario.TIPO_DOCUMENTO = dr["TIPO_DOCUMENTO"].ToString();
                    inventario.NRO_DOCUMENTO = dr["NRO_DOCUMENTO"].ToString();
                    inventario.COD_ITEM_2 = dr["COD_ITEM_2"].ToString();
                    inventario.PROVEEDOR = dr["PROVEEDOR"].ToString();
                    inventario.ALMACEN_DESTINO = dr["ALMACEN_DESTINO"].ToString();
                    inventario.CANTIDAD = Convert.ToInt32(dr["CANTIDAD"]);
                    inventario.DOC_REF_1 = dr["DOC_REF_1"].ToString();
                    inventario.DOC_REF_2 = dr["DOC_REF_2"].ToString();
                    inventario.DOC_REF_3 = dr["DOC_REF_3"].ToString();
                    inventario.DOC_REF_4 = dr["DOC_REF_4"].ToString();
                    inventario.DOC_REF_5 = dr["DOC_REF_5"].ToString();
                    inventario.FECHA_TRANSACCION = Convert.ToDateTime(dr["FECHA_TRANSACCION"]).Date;                    
                }
                _connection.Close();
            }
            return inventario;

        }

        public bool Update(Mov_Inventario model)
        {

            int id = 0;

            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[dbo].[sp_update_inventario]";
                _command.Parameters.AddWithValue("@COD_CIA", model.COD_CIA);
                _command.Parameters.AddWithValue("@COMPANIA_VENTA_3", model.COMPANIA_VENTA_3);
                _command.Parameters.AddWithValue("@ALMACEN_VENTA", model.ALMACEN_VENTA);
                _command.Parameters.AddWithValue("@TIPO_MOVIMIENTO", model.TIPO_MOVIMIENTO);
                _command.Parameters.AddWithValue("@TIPO_DOCUMENTO", model.TIPO_DOCUMENTO);
                _command.Parameters.AddWithValue("@NRO_DOCUMENTO", model.NRO_DOCUMENTO);
                _command.Parameters.AddWithValue("@COD_ITEM_2", model.COD_ITEM_2);
                _command.Parameters.AddWithValue("@PROVEEDOR", model.PROVEEDOR);
                _command.Parameters.AddWithValue("@ALMACEN_DESTINO", model.ALMACEN_DESTINO);
                _command.Parameters.AddWithValue("@CANTIDAD", model.CANTIDAD);
                _command.Parameters.AddWithValue("@DOC_REF_1", model.DOC_REF_1);
                _command.Parameters.AddWithValue("@DOC_REF_2", model.DOC_REF_2);
                _command.Parameters.AddWithValue("@DOC_REF_3", model.DOC_REF_3);
                _command.Parameters.AddWithValue("@DOC_REF_4", model.DOC_REF_4);
                _command.Parameters.AddWithValue("@DOC_REF_5", model.DOC_REF_5);
                _command.Parameters.AddWithValue("@FECHA_TRANSACCION", model.FECHA_TRANSACCION);
                _connection.Open();
                id = _command.ExecuteNonQuery();
                _connection.Close();

                return id > 0 ? true : false;

            }

        }

        public bool Delete(Mov_Inventario model)
        {

            int id = 0;

            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[dbo].[sp_delete_inventario]";
                _command.Parameters.AddWithValue("@COD_CIA", model.COD_CIA);
                _command.Parameters.AddWithValue("@COMPANIA_VENTA_3", model.COMPANIA_VENTA_3);
                _command.Parameters.AddWithValue("@ALMACEN_VENTA", model.ALMACEN_VENTA);
                _command.Parameters.AddWithValue("@TIPO_MOVIMIENTO", model.TIPO_MOVIMIENTO);
                _command.Parameters.AddWithValue("@TIPO_DOCUMENTO", model.TIPO_DOCUMENTO);
                _command.Parameters.AddWithValue("@NRO_DOCUMENTO", model.NRO_DOCUMENTO);
                _command.Parameters.AddWithValue("@COD_ITEM_2", model.COD_ITEM_2);                
                _connection.Open();
                id = _command.ExecuteNonQuery();
                _connection.Close();

                return id > 0 ? true : false;

            }

        }

    }
}
