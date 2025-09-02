using System;
using System.Linq;


public class No
{
    public int Valor { get; }
    public No Esquerda { get; private set; }
    public No Direita { get; private set; }

    public No(int valor)
    {
        Valor = valor;
    }

    /// <summary>
    /// Define os nós filhos de um nó.
    /// </summary>
    public void DefinirFilhos(No esquerda, No direita)
    {
        Esquerda = esquerda;
        Direita = direita;
    }

    public void Imprimir(string prefixo = "", bool ehUltimoFilho = true)
    {
        Console.WriteLine(prefixo + (ehUltimoFilho ? "└─ " : "├─ ") + Valor);

        var proximoPrefixo = prefixo + (ehUltimoFilho ? "   " : "│  ");
        var temFilhoEsquerdo = Esquerda != null;
        var temFilhoDireito = Direita != null;

        if (temFilhoDireito)
        {
            Direita.Imprimir(proximoPrefixo, !temFilhoEsquerdo);
        }

        if (temFilhoEsquerdo)
        {
            Esquerda.Imprimir(proximoPrefixo, true);
        }
    }
}

public static class ConstrutorDeArvore
{
    public static No ConstruirDaRaiz(int[] array)
    {
        return Construir(array, 0, array.Length - 1);
    }

    private static No Construir(int[] array, int inicio, int fim)
    {
        if (inicio > fim)
        {
            return null;
        }

        var indiceDoMaior = EncontrarIndiceDoMaior(array, inicio, fim);
        var raiz = new No(array[indiceDoMaior]);

        var subArvoreEsquerda = Construir(array, inicio, indiceDoMaior - 1);
        var subArvoreDireita = Construir(array, indiceDoMaior + 1, fim);
        raiz.DefinirFilhos(subArvoreEsquerda, subArvoreDireita);

        return raiz;
    }

    private static int EncontrarIndiceDoMaior(int[] array, int inicio, int fim)
    {
        var indiceDoMaior = inicio;
        for (int i = inicio + 1; i <= fim; i++)
        {
            if (array[i] > array[indiceDoMaior])
            {
                indiceDoMaior = i;
            }
        }
        return indiceDoMaior;
    }
}

public class Programa
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Cenário 1 ---");
        int[] cenario1 = { 3, 2, 1, 6, 0, 5 };
        var arvore1 = ConstrutorDeArvore.ConstruirDaRaiz(cenario1);
        Console.WriteLine($"Array de entrada: [{string.Join(", ", cenario1)}]");
        Console.WriteLine("Árvore de saída:");
        arvore1.Imprimir();

        Console.WriteLine("\n--- Cenário 2 ---");
        int[] cenario2 = { 7, 5, 13, 9, 1, 6, 3 };
        var arvore2 = ConstrutorDeArvore.ConstruirDaRaiz(cenario2);
        Console.WriteLine($"Array de entrada: [{string.Join(", ", cenario2)}]");
        Console.WriteLine("Árvore de saída:");
        arvore2.Imprimir();
    }
}