using System;
using System.Collections.Generic;

public class No
{
    public int Valor { get; }
    public No Esquerda { get; private set; }
    public No Direita { get; private set; }

    public No(int valor)
    {
        Valor = valor;
    }

    public void DefinirFilhos(No esquerda, No direita)
    {
        Esquerda = esquerda;
        Direita = direita;
    }

    public void Imprimir(string prefixo = "", bool ehUltimoFilho = true)
    {
        Console.WriteLine(prefixo + (ehUltimoFilho ? "└─ " : "├─ ") + Valor);

        var proximoPrefixo = prefixo + (ehUltimoFilho ? "   " : "│  ");
        if (Direita != null) Direita.Imprimir(proximoPrefixo, Esquerda == null);
        if (Esquerda != null) Esquerda.Imprimir(proximoPrefixo, true);
    }
}

public static class ConstrutorDeArvore
{
    public static No ConstruirDaRaiz(int[] array)
    {
        if (array == null || array.Length == 0)
        {
            throw new ArgumentException("Array não pode ser nulo ou vazio.", nameof(array));

        }

        Stack<No> pilha = new Stack<No>();

        foreach (var valor in array)
        {
            No noAtual = new No(valor);

            while (pilha.Count > 0 && pilha.Peek().Valor < valor)
            {
                No menor = pilha.Pop();
                noAtual.DefinirFilhos(menor, noAtual.Direita);
            }

            if (pilha.Count > 0)
            {
                No topo = pilha.Peek();
                topo.DefinirFilhos(topo.Esquerda, noAtual);
            }

            pilha.Push(noAtual);
        }

        while (pilha.Count > 1)
        {
            pilha.Pop();

        }

        return pilha.Pop();
    }
}

public class Programa
{
    public static void Main()
    {
        int[] cenario1 = { 3, 2, 1, 6, 0, 5 };
        Console.WriteLine("--- Cenário 1 ---");
        var arvore1 = ConstrutorDeArvore.ConstruirDaRaiz(cenario1);
        Console.WriteLine($"Array de entrada: [{string.Join(", ", cenario1)}]");
        Console.WriteLine("Árvore de saída:");
        arvore1.Imprimir();

        int[] cenario2 = { 7, 5, 13, 9, 1, 6, 3 };
        Console.WriteLine("\n--- Cenário 2 ---");
        var arvore2 = ConstrutorDeArvore.ConstruirDaRaiz(cenario2);
        Console.WriteLine($"Array de entrada: [{string.Join(", ", cenario2)}]");
        Console.WriteLine("Árvore de saída:");
        arvore2.Imprimir();
    }
}
