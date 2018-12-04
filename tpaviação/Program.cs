using System;
using System.Collections;
using System.Collections.Generic;

namespace tpaviação
{
    public class Voo
    {
        public int Id { get; set; }
        public string Destino { get; set; }
        public DateTime dateTime { get; set; }
    }

    public class Passageiro
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public long Telefone { get; set; }
        public string Numvoo { get; set; }
        public string Destino { get; set; }
        public DateTime dateTime { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Voo primeiro = new Voo()
            {
                Id = 001,
                Destino = "MG",
                dateTime = Convert.ToDateTime("06:00")
            };
            Voo segundo = new Voo()
            {
                Id = 002,
                Destino = "S",
                dateTime = Convert.ToDateTime("12:00")
            };
            Voo terceiro = new Voo()
            {
                Id = 003,
                Destino = "RS",
                dateTime = Convert.ToDateTime("17:30")
            };

            List<Voo> voos = new List<Voo>();
            voos.Add(primeiro);
            voos.Add(segundo);
            voos.Add(terceiro);

            int posicao;
            Queue espera = new Queue();
            List<Passageiro> listaPessoa = new List<Passageiro>();

            Passageiro passageiro = new Passageiro();

            Passageiro porta1 = new Passageiro()
            {
                Nome = "Higor",
                CPF = "14295287542",
                Telefone = 11998491717,
                Numvoo = " ",
                dateTime = Convert.ToDateTime("06:00")
            };
            Passageiro porta2 = new Passageiro()
            {
                Nome = "Adriana",
                CPF = "14295287542",
                Telefone = 64985842014,
                Numvoo = " ",
                dateTime = Convert.ToDateTime("06:00")
            };
            Passageiro porta3 = new Passageiro()
            {
                Nome = "Gabriel",
                CPF = "14295287542",
                Telefone = 11954859456,
                Numvoo = " ",
                dateTime = Convert.ToDateTime("06:00")
            };
            Passageiro porta4 = new Passageiro()
            {
                Nome = "Pedro",
                CPF = "45146248488",
                Telefone = 14987554563,
                Numvoo = " ",
                dateTime = Convert.ToDateTime("06:00")
            };
            listaPessoa.Add(porta1);
            listaPessoa.Add(porta2);
            listaPessoa.Add(porta3);
            listaPessoa.Add(porta4);
            espera.Enqueue(porta1);
            espera.Enqueue(porta2);
            espera.Enqueue(porta3);
            espera.Enqueue(porta4);
            bool sair = false;
            do
            {
                string Destino = "";
                DateTime aux;
                for (int i = 0; i < voos.Count; i++)
                {
                    Destino = primeiro.Destino;
                    aux = primeiro.dateTime;
                    if (aux > segundo.dateTime)
                    {
                        Destino = segundo.Destino;
                    }
                    else if (aux > terceiro.dateTime)
                    {
                        Destino = terceiro.Destino;
                    }
                }
                Console.WriteLine("\n\t\t\t\t\tBem Vindo ao Aeroporto de Confins:\n\n" + "\n\n" +
                    "Voos\n" +
                    "[F1] Lista de Passageiros\n" +
                    "[F2] Pesquisar Passageiros\n" +
                    "[F3] Cadastrar Novo Passageiros\n" +
                    "[F4] Retirar Passageiros da lista\n" +
                    "[F5] Fila de Espera\n" +
                    "[ESC] SAIR", Destino);
                ConsoleKeyInfo Menu = Console.ReadKey();
                sair = Menu.Key == ConsoleKey.Escape;
                if (Menu.Key == ConsoleKey.F1)
                {
                    posicao = 1;
                    for (int i = 0; i < espera.Count; i++)
                    {
                        Console.WriteLine("\n" + posicao + "°: " + "Nome: {0} " +
                            "CPF: {1} " +
                            "Numero do Voo: 125{2} " +
                            "Destino: SP/{3} " +
                            "Telefone: {4} " +
                            "Horario: {5}",
                            listaPessoa[i].Nome, listaPessoa[i].CPF, listaPessoa[i].Destino, listaPessoa[i].Telefone, listaPessoa[i].Telefone, listaPessoa[i].dateTime);
                        posicao++;
                       
                    }
                }
                else if (Menu.Key == ConsoleKey.F2)
                {
                    Console.WriteLine("Informe o CPF requerido");
                    string CPF = Console.ReadLine();
                    for (int i = 0; i < listaPessoa.Count && i < 5; i++)
                    {
                        if (CPF == listaPessoa[i].CPF)
                        {
                            Console.WriteLine("\n" + "Nome: {0} " +
                            "CPF: {1} " +
                            "Numero do Voo: 127{2} " +
                            "Destino: BH/{3} " +
                            "Telefone: {4} " +
                            "Horario: {5}",
                            listaPessoa[i].Nome, listaPessoa[i].CPF, listaPessoa[i].Destino, listaPessoa[i].Telefone, listaPessoa[i].Telefone, listaPessoa[i].dateTime);
                       
                        }
                    }
                }
                else if (Menu.Key == ConsoleKey.F3)
                {
                    bool retornar = false;
                    do
                    {
                        Passageiro cadastrado = new Passageiro();

                        Console.WriteLine("Qual é o seu nome?");
                        cadastrado.Nome = Console.ReadLine();

                        Console.WriteLine("Qual o seu CPF");
                        cadastrado.CPF = (Console.ReadLine());

                        Console.WriteLine("Qual o local de destino");
                        string Numvoo = Console.ReadLine();

                        if (Numvoo == "SP")
                        {
                            cadastrado.Numvoo = "primeiro";
                        }
                        else if (Numvoo == "RE")
                        {
                            cadastrado.Numvoo = "segundo";
                        }
                        else if (Numvoo == "RJ")
                        {
                            cadastrado.Numvoo = "primeiro";
                        }
                        Console.WriteLine("Qual o seu Telefone para Contato?");
                        passageiro.Telefone = long.Parse(Console.ReadLine());

                        listaPessoa.Add(cadastrado);
                        espera.Enqueue(cadastrado);

                        Console.WriteLine("Deseja fazer um novo cadastro? Aperte ESC duas vezes para voltar");
                        var terminar = Console.ReadKey();

                        retornar = terminar.Key == ConsoleKey.Escape;
                        Console.ReadKey();

                    } while (!retornar);
                }
                else if (Menu.Key == ConsoleKey.F4)
                {
                    
                    espera.Dequeue();

                    Console.WriteLine("\nRetirada feita com Sucesso\n");
                    Console.ReadKey();
                }

                else if (Menu.Key == ConsoleKey.F5)
                {
                    posicao = 6;
                    for (int i = 0; i > 5 && i < espera.Count; i++)
                    {
                        Console.WriteLine("\n" + posicao + "°: " + "Nome: {0} " +
                            "CPF: {1} " +
                            "Numero do Voo: 458{2} " +
                            "Destino: BH/{3} " +
                            "Telefone: {4} " +
                            "Horario: {5}",
                        listaPessoa[i].Nome, listaPessoa[i].CPF, listaPessoa[i].Destino, listaPessoa[i].Telefone, listaPessoa[i].Telefone, listaPessoa[i].dateTime);
                        posicao++;
                    }
                }
            } while (!sair);
        }
    }

}