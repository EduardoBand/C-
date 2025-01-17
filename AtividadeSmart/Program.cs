using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Para escolher uma aplicação, digite seu número correspondente:\n" +
                          "1 - Descobrir par/ímpar\n" +
                          "2 - Calculadora\n" +
                          "3 - Reajuste salarial\n" +
                          "4 - Cálculo IMC\n" +
                          "5 - Número de vogais\n" +
                          "6 - Altura e nome dos alunos\n" +
                          "7 - Conta corrente\n" +
                          "8 - Soma de vetores\n" +
                          "9 - CSV Funcionários\n" +
                          "10 - Matrix 3x3");

        Console.WriteLine("Digite sua escolha: ");
        if (int.TryParse(Console.ReadLine(), out int escolha))
        {
            switch (escolha)
            {
                case 1:
                    DescobrirParImpar();
                    break;
                case 2:
                    Calculadora();
                    break;
                case 3:
                    ReajusteSalarial();
                    break;
                case 4:
                    CalcularIMC();
                    break;
                case 5:
                    ContarVogais();
                    break;
                case 6:
                    CaracteristicasAlunos();
                    break;
                case 7:
                    ContaCorrente();
                    break;
                case 8:
                    SomaVetor();
                    break;
                case 9:
                    CriarCSV();
                    break;
                case 10:
                    CriarMatrix();
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Entrada inválida, por favor digite um número entre 1 e 10.");
        }
    }


    //Desenvolva um algoritmo que descubra se o número é par ou ímpar
    static void DescobrirParImpar()
    {
        Console.WriteLine("Digite um número: ");

        string entrada = Console.ReadLine();
        if (int.TryParse(entrada, out int numero))
        {
            if (numero % 2 == 0)
            {
                Console.WriteLine($"O número {numero} é par.");
            }
            else
            {
                Console.WriteLine($"O número {numero} é ímpar.");
            }
        }
        else
        {
            Console.WriteLine("Entrada inválida, digite um número inteiro.");
        }
    }

    //Desenvolva um app que funcione como uma calculadora.
    static void Calculadora()
    {
        Console.WriteLine("Digite a operação matemática desejada:\n" +
                          "+ - adição\n" +
                          "- - subtração\n" +
                          "* - multiplicação\n" +
                          "/ - divisão");

        string operacao = Console.ReadLine();
        Console.WriteLine($"Operação selecionada: {operacao}");

        Console.WriteLine("Agora, digite o PRIMEIRO valor desejado: ");
        if (!int.TryParse(Console.ReadLine(), out int PrimeiroValor))
        {
            Console.WriteLine("Erro: o valor digitado não é um número válido.");
            return;
        }

        Console.WriteLine("Agora, digite o SEGUNDO valor desejado: ");
        if (!int.TryParse(Console.ReadLine(), out int SegundoValor))
        {
            Console.WriteLine("Erro: o valor digitado não é um número válido.");
            return;
        }

        double resultado;

        switch (operacao)
        {
            case "+":
                resultado = PrimeiroValor + SegundoValor;
                Console.WriteLine($"Resultado: {PrimeiroValor} + {SegundoValor} = {resultado}");
                break;

            case "-":
                resultado = PrimeiroValor - SegundoValor;
                Console.WriteLine($"Resultado: {PrimeiroValor} - {SegundoValor} = {resultado}");
                break;

            case "*":
                resultado = PrimeiroValor * SegundoValor;
                Console.WriteLine($"Resultado: {PrimeiroValor} * {SegundoValor} = {resultado}");
                break;

            case "/":
                if (SegundoValor != 0)
                {
                    resultado = (double)PrimeiroValor / SegundoValor;
                    Console.WriteLine($"Resultado: {PrimeiroValor} / {SegundoValor} = {resultado:F2}");
                }
                else
                {
                    Console.WriteLine("Erro: divisão por zero não é permitida.");
                }
                break;

            default:
                Console.WriteLine("Erro: operação inválida.");
                break;
        }
    }

    //Desenvolva um algoritmo que calcule o reajuste salarial. Se o salário for abaixo de R$1700 o ajuste é de R$300,00. Se for maior que R$1700, o ajuste será de R$200,00. Para finalizar, exiba o novo salário na tela.
    static void ReajusteSalarial() 
    {

        
        Console.WriteLine("Digite o seu salário atual: ");

        if (float.TryParse(Console.ReadLine(), out float salarioInformado))
        {
            float reajuste;

            if (salarioInformado < 1700)
            {
                reajuste = 300;
            }
            else
            {
                reajuste = 200;
            }

            float novoSalario = salarioInformado + reajuste;

            Console.WriteLine($"Seu salário foi reajustado para {novoSalario:0.00}.");
        }
        else
        {
            Console.WriteLine("Erro: valor digitado não é válido");
        }
    }   

    //Desenvolva um algoritmo que calcule o IMC de uma pessoa e grave os resultados em um arquivo de texto, onde ao acessar a aplicação será solicitado se quer fazer um novo cadastro ou consultar os existentes. 
    //Cadastrando um novo cálculo de IMC, será necessário informar o nome,idade, peso e altura. O cálculo do IMC é feito dividindo o peso (em kg) pela altura ao quadrado (em metros). Ao gravar em um arquivo de texto, os dados anteriores deverão ser mantidos. Use a bliblioteca System.IO. Também será necessário criar um arquivo chamado imc com a extensão .txt

    static void CalcularIMC()
    {
        string caminho = "imc.txt";

        while (true)
        {
            Console.WriteLine("Digite a opção desejada: \n" +
                              "N - Novo cálculo de IMC \n" +
                              "C - Consultar cadastros existentes\n" +
                              "S - Sair");
            Console.WriteLine("Escolha uma opção digitando a letra correspondente: ");
            string opcao = Console.ReadLine()?.ToUpper();

            switch (opcao)
            {
                case "N":
                    Console.WriteLine("Informe o nome: ");
                    string nome = Console.ReadLine();

                    Console.WriteLine("Informe a idade: ");
                    if (!int.TryParse(Console.ReadLine(), out int idade))
                    {
                        Console.WriteLine("Erro: idade inválida. Precisa ser um número inteiro.");
                        break;
                    }

                    Console.WriteLine("Informe o peso (em KG): ");
                    if (!float.TryParse(Console.ReadLine(), out float peso))
                    {
                        Console.WriteLine("Erro: peso inválido.");
                        break;
                    }

                    Console.WriteLine("Informe a altura (em metros EX. 1,76): ");
                    if (!float.TryParse(Console.ReadLine(), out float altura))
                    {
                        Console.WriteLine("Erro: altura inválida.");
                        break;
                    }

                    float imc = peso / (altura * altura);
                    string resultado = $"{nome}, {idade} anos, Peso: {peso} kg, Altura: {altura} m, IMC: {imc:0.00}";

                    File.AppendAllText(caminho, resultado + Environment.NewLine);
                    Console.WriteLine("Cálculo realizado e salvo com sucesso!");
                    break;

                case "C":
                    if (File.Exists(caminho))
                    {
                        Console.WriteLine("Registros existentes:");
                        string[] registros = File.ReadAllLines(caminho);
                        foreach (string registro in registros)
                        {
                            Console.WriteLine(registro);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nenhum registro encontrado.");
                    }
                    break;

                case "S":
                    Console.WriteLine("Saindo do programa...");
                    return;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            Console.WriteLine("Pressione uma tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    //Leia uma cadeia de caracteres e imprima a quantidade de vogais da palavra ou frase. Evite utilizar funções prontas da biblioteca de String.
    static void ContarVogais()
    {
        Console.WriteLine("Digite a frase que será contada:");
        string frase = Console.ReadLine();

        int contadorVogais = 0;
        string vogais = "aáãâeêéiîíoôõóuúûAÃÂÁEÊÉIÎÍOÔÕÓUÚ";

        foreach (char c in frase)
        {
            for (int i = 0; i < vogais.Length; i++)
            {
                if (vogais[i] == c)
                {
                    contadorVogais++;
                    break;
                }
            }
        }

        Console.WriteLine($"A quantidade de vogais na frase é: {contadorVogais}");
    }

    //Faça um algoritmo que leia a altura e o nome de cinco alunos. Mostre o nome do aluno mais alto.
    static void CaracteristicasAlunos()
    {
        const int totalAlunos = 5;
        string[] nomes = new string[totalAlunos];
        float[] alturas = new float[totalAlunos];

        for (int i = 0; i < totalAlunos; i++)
        {
            Console.WriteLine($"Digite o nome do {i + 1}° aluno: ");
            nomes[i] = Console.ReadLine();

            Console.WriteLine($"Digite a altura do {i + 1}° aluno (em metros): ");
            while (!float.TryParse(Console.ReadLine(), out alturas[i]))
            {
                Console.WriteLine("Valor inválido. Digite em metros EX: 1,76");
            }
        }

        float maiorAltura = alturas[0];
        int indiceMaiorAltura = 0;

        for (int i = 1; i < totalAlunos; i++)
        {
            if (alturas[i] > maiorAltura)
            {
                maiorAltura = alturas[i];
                indiceMaiorAltura = i;
            }
        }

        Console.WriteLine($"O aluno mais alto é {nomes[indiceMaiorAltura]} com {maiorAltura} metros.");
    }

    private static void ContaCorrente()
    {
        throw new NotImplementedException();
    }

    //Crie e popule um vetor de inteiros com 10 posições. Depois disso, realize a soma de todos os elementos e imprima na tela. 
    static void SomaVetor()
    {
        int[] vetores = new int[10];
        int soma = 0;

        Console.WriteLine("Digite 10 valores inteiros:");

        for (int i = 0; i < vetores.Length; i++)
        {
            Console.Write($"Valor {i + 1}: ");
            while (!int.TryParse(Console.ReadLine(), out vetores[i])) 
            {
                Console.WriteLine("Entrada inválida. Digite um número inteiro:");
            }
        }

        foreach (int valor in vetores)
        {
            soma += valor; 
        }

        Console.WriteLine($"A soma de todos os elementos do vetor é: {soma}");
    }

    //Crie um arquivo .csv com o título csvFuncionarios e insira as seguintes informações:
    //1000;Fernanda;Programador
    //5500;Marcela;Gerente de Projetos
    //4000;João;Analista pleno
    //2500;Maria;Analista Jr
    //Faça um programa que imprima o valor do salário, nome e cargo do funcionário na tela, substituindo o ponto e vírgula por hífen(-)
    //Ex de saída: Salário:1000 - Funcionário: Fernada - Cargo: Programador
    static void CriarCSV() 
    {
        string caminhoArquivo = "csvFuncionarios.csv";

        string[] dados = {
            "1000;Fernanda;Programador",
            "5500;Marcela;Gerente de Projetos",
            "4000;João;Analista pleno",
            "2500;Maria;Analista Jr"
        };

        File.WriteAllLines(caminhoArquivo, dados);

        Console.WriteLine("Funcionários:");

        string[] linhas = File.ReadAllLines(caminhoArquivo);
        foreach (string linha in linhas)
        {
            string[] campos = linha.Split(';');
            Console.WriteLine($"Salário: {campos[0]} - Funcionário: {campos[1]} - Cargo: {campos[2]}");
        }
    }



    //Crie uma matriz 3x3, popule a matriz solicitando os valores via console e imprima a matriz. Depois, realize a ordenação dos valores por linha. Imprima a matriz ordenada. 
    static void CriarMatrix()
    {
        int[,] matriz = new int[3, 3];

        Console.WriteLine("Digite os valores para preencher a matriz 3x3:");

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write($"Digite o valor para a posição [{i},{j}]: ");
                matriz[i, j] = int.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine("\nMatriz original:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(matriz[i, j] + "\t");
            }
            Console.WriteLine();
        }

        for (int i = 0; i < 3; i++)
        {
            int[] linha = new int[3];

            for (int j = 0; j < 3; j++)
            {
                linha[j] = matriz[i, j];
            }

            Array.Sort(linha);

            for (int j = 0; j < 3; j++)
            {
                matriz[i, j] = linha[j];
            }
        }

        Console.WriteLine("\nMatriz ordenada:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(matriz[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}