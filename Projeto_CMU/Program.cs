using Projeto_CMU;
using System;

namespace ControleNotas
{
    class Program
    {
        static void Main(string[] args)
        {
            int op;
            Aluno[] alunos = new Aluno[100];
            short proximoAluno = 0;


            do
            {
                op = 0;
                MontarMenuInicial();

                try
                {
                    op = int.Parse(Console.ReadLine());
                }
                catch //caso opção não seja 1-2-3-9 será retornado a mensagem
                {
                    Console.WriteLine("A opção informada é inválida!");
                }

                switch (op)
                {
                    case 1: //proximoAluno = 0
                        if (proximoAluno > alunos.Length - 1) //remover a capacidade de alunos que pode ser registrado
                        {
                            Console.WriteLine("Capacidade de alunos(as) excedida!");
                            Console.ReadKey();
                            break;
                        }
                        alunos[proximoAluno] = CadastrarAluno();

                        Console.WriteLine($"Aluno(a) {alunos[proximoAluno].Nome} cadastrado(a) com sucesso!");
                        Console.ReadKey();

                        proximoAluno++;

                        break;
                    case 2:
                        //todo
                        ListarAlunos(alunos);
                        Console.WriteLine("Pressione qualquer tecla para retornar.");
                        Console.ReadKey();
                        break;
                    case 3:
                        //todo 
                        CalculoMedia(alunos);
                        Console.ReadKey();
                        break;
                    case 9:
                        Console.WriteLine("Encerrando aplicação...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        Console.ReadKey();
                        break;
                }

            } while (op < 9);

            Console.WriteLine();
            Console.WriteLine("Obrigado por utilizar o nosso sistema!");

        }

        static void MontarMenuInicial() //opção de menu inicial, chamado no inicio da aplicação 
        {
            Console.Clear();
            NomeSistema();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();
            Console.WriteLine("1. Inserir novo(a) aluno(a)");
            Console.WriteLine("2. Listar alunos(as)");
            Console.WriteLine("3. Verificar média alunos(as) para emissão de certificado");
            Console.WriteLine("9. Encerrar aplicação");

            Console.WriteLine();
        }

        static void NomeSistema()
        {
            Console.WriteLine($":::::::::::::::::::::: SISTEMA CONTROLE DE NOTAS E CURSOS ::::::::::::::::::::::");
            Console.WriteLine();
        }

        static Aluno CadastrarAluno()
        {
            bool isNotaValida = false;
            bool isNomeValido = false;
            string retorno = "";

            Console.Clear();
            NomeSistema();
            Console.WriteLine();
            Console.WriteLine(":::CADASTRO DE ALUNOS:::");
            Console.WriteLine();

            Aluno aluno = new Aluno();

            do //insere nome do aluno
            {
                Console.Write("Informe o nome do aluno: ");
                aluno.Nome = Console.ReadLine();

                if (aluno.Nome.Trim().Length == 0 || aluno.Nome.Trim().Length > 50) //aceita somente nomes com 15 caracteres - aumentar para 50
                {
                    Console.WriteLine("Nome do aluno deve conter de uma a 50 caracteres.");
                }
                else
                {
                    isNomeValido = true;
                }

            } while (!isNomeValido);

           
            do
            {

                do
                {//Registra o curso do aluno
                    Console.Write("Informe o Curso em que o aluno esta matriculado: ");
                    aluno.Curso = Console.ReadLine();
                    if (aluno.Curso.Trim().Length == 0 || aluno.Curso.Trim().Length > 50) //aceita somente nomes com 15 caracteres - aumentar para 50
                    {
                        Console.WriteLine("Nome do aluno deve conter de uma a 50 caracteres.");
                    }
                    else
                    {
                        isNomeValido = true;
                    }
                } while (!isNomeValido);

                do //Registra tarefa do curso
                {
                    Console.Write("Informe a tarefa: ");
                    aluno.Tarefa = Console.ReadLine();

                    if (aluno.Tarefa.Trim().Length == 0 || aluno.Tarefa.Trim().Length > 50) //aceita somente nomes com 15 caracteres - aumentar para 50
                    {
                        Console.WriteLine("Nome do aluno deve conter de uma a 50 caracteres.");
                    }
                    else
                    {
                        isNomeValido = true;
                    }

                } while (!isNomeValido);

                Console.Write("Informe a nota do aluno tirou na tarefa realizada: ");
                do //insere nota do aluno
                {
                    isNotaValida = false;
                    if (double.TryParse(Console.ReadLine(), out double nota))
                    {
                        if (nota >= 0 && nota <= 100)
                        {
                            aluno.Nota = nota;
                            isNotaValida = true;
                        }
                        else
                        {
                            Console.WriteLine("****Deve ser digitada uma nota de zero a 100****");
                            Console.Write("Informe a nota do aluno (com vírgula se necessário):");
                        }
                    }

                } while (!isNotaValida);

                Console.WriteLine("Deseja corrigir uma nova tarefa? (S para sim ou qualquer tecla para retornar ao menu inicial)");
                retorno = Console.ReadLine();
            } while (retorno.ToUpper() == "S");

            return aluno;
        }

        static void ListarAlunos(Aluno[] alunos)
        {
            Console.Clear();
            NomeSistema();
            Console.WriteLine();
            Console.WriteLine(":::LISTAGEM DE ALUNOS:::");
            Console.WriteLine();
            Console.WriteLine(new String('-', 169)); //aumentar os carateres para 170
            Console.WriteLine(String.Format("|{0, -50}|{1, -50}|{2, -50}|{3, -15}|", "     Aluno     ", "     Curso     ", "     Tarefa     ", "     Nota     ")); //aumentar os caracteres do nome para trinta
            Console.WriteLine(new String('-', 169));//aumentar os carateres para 170

            for (int i = 0; i < alunos.Length; i++)
            {
                if (!string.IsNullOrEmpty(alunos[i].Nome))
                {
                    Console.WriteLine("|{0, -50}|{1, -50}|{2, -50}|{3, -15}|", alunos[i].Nome, alunos[i].Curso, alunos[i].Tarefa, alunos[i].Nota);
                    Console.WriteLine(new String('-', 169));
                }
            }
        }

        static void CalculoMedia(Aluno[] alunos)
        {
            Console.Clear();
            NomeSistema();
            Console.WriteLine("\t:::MÉDIA PARA EMISSÃO DE CERTIFICADOS:::\t");
            double somaNota = 0;
            int proximoAluno = 1;

            
            for (int i = 0; i < alunos.Length; i++) //Função de soma não utilizada.
            {
                if (alunos[i].Nome == alunos[proximoAluno].Nome)
                {
                    somaNota += alunos[i].Nota;
                }
            }


            foreach (Aluno i in alunos)
            {
                if (!string.IsNullOrEmpty(i.Nome))
                {
                    Console.WriteLine(new string('-', 50));
                    Console.WriteLine($"|A média geral do aluno {i.Nome} cadastrado é " + i.Nota.ToString("0.##"));
                    Console.WriteLine($"Aluno foi {ConceitoFinal(i.Nota).PadRight(0, ' ')} no curso.");
                }
            }

        }

        static string ConceitoFinal(double nota)
        {
            Cursos con;

            if (nota > 60)
            {
                con = Cursos.aprovado;
            }
            else con = Cursos.reprovado;
            return con.ToString();
        }
    }
}