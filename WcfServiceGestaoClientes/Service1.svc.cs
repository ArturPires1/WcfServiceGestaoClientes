using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Configuration;

namespace WcfServiceGestaoClientes
{
    public class Service1 : IService1
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);

        public string InsertUserRegDetails(RegDetails regdet)
        {
            string Status;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("insert into Cliente(cpf,nome,tipoCliente,sexo,situacaoCliente) values(@cpf,@nome,@tipoCliente,@sexo,@situacaoCliente)", con);
            cmd.Parameters.AddWithValue("@cpf", regdet.CPF);
            cmd.Parameters.AddWithValue("@nome", regdet.Nome);
            cmd.Parameters.AddWithValue("@tipoCliente", regdet.Tipo);
            cmd.Parameters.AddWithValue("@sexo", regdet.Sexo);
            cmd.Parameters.AddWithValue("@situacaoCliente", regdet.Situacao);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Status = regdet.CPF + " " + regdet.Nome + " registered successfully";
            }
            else
            {
                Status = regdet.CPF + " " + regdet.Nome + " could not be registered";
            }
            con.Close();
            return Status;
        }

        public DataSet GetUserRegDetails()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("Select * from Cliente", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }

        public DataSet FetchUpdatedRecords(RegDetails regdet)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("select * from Cliente where cpf=@cpf", con);

            cmd.Parameters.AddWithValue("@cpf", regdet.CPF);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }

        public string UpdateUserRegDetails(RegDetails regdet)
        {
            string Status;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("update Cliente set nome=@nome,tipoCliente=@tipoCliente, sexo=@sexo,situacaoCliente=@situacaoCliente where cpf=@cpf", con);
            cmd.Parameters.AddWithValue("@cpf", regdet.CPF);
            cmd.Parameters.AddWithValue("@nome", regdet.Nome);
            cmd.Parameters.AddWithValue("@tipoCliente", regdet.Tipo);
            cmd.Parameters.AddWithValue("@sexo", regdet.Sexo);
            cmd.Parameters.AddWithValue("@situacaoCliente", regdet.Situacao);           
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Status = "Record updated successfully";
            }
            else
            {
                Status = "Record could not be updated";
            }
            con.Close();
            return Status;
        }
        public bool DeleteUserRegDetails(RegDetails regdet)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("delete from Cliente where cpf=@cpf", con);

            cmd.Parameters.AddWithValue("@cpf", regdet.CPF);
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
    }
}
