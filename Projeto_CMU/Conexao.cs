using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Projeto_CMU
{
    
    //Tentei realizar a conexão com o banco de dados criado, porém não consegui chegar ao resultado desejado. Programa não se conectou com a tabela. Por este motivo tive que encontrar uma outra forma sem SQL.
    public class Conexao
    {
        SqlConnection con = new SqlConnection();

        public Conexao()
        {
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Teste_CMU;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }
        public SqlConnection conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public SqlConnection desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            return con;
        }
    }
}
