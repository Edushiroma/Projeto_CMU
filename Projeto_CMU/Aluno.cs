
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Projeto_CMU
{
    public struct Aluno
    {
        public string Nome { get; set; }
        public string Curso { get; set; }
        public string Tarefa { get; set; }
        public double Nota { get; set; }

        public static void SomaNota(Aluno[] alunos)
        {
            double somaNota = 0;
            foreach (Aluno i in alunos)
            {
                if (!string.IsNullOrEmpty(i.Nome))
                {
                    somaNota += i.Nota;
                }
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Média" + Nota;
            return retorno;
        }


        /*
        Tentei realizar o registro dos alunos no banco de dados, entretanto após tentativas não consegui identificar a solução para o registro. Por este motivo tive que encontrar uma outra forma sem SQL.

        Conexao conexao = new Conexao();
        SqlCommand cmd = new SqlCommand();
        public String mensagem;

        public Alunos(int matricula, string nome , int idade)
        {

            cmd.CommandText = "insert into alunos (Matricula, NomeAluno, IdadeAluno) values (@matricula, @nome, @idade)";

            cmd.Parameters.AddWithValue("@matricula", matricula);
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@idade", idade);

            try
            {
                cmd.Connection = conexao.conectar();
                //executar comando no SQL
                cmd.ExecuteNonQuery();
                //desconectar
                conexao.desconectar();
                this.mensagem = "Cadastrado com sucesso";
                
            }
            catch (Exception e)
            {
                this.mensagem = "Erro";
            }
        }
        */

    }
}
