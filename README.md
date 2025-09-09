# Construtor de Árvore Binária a partir de Array

Este projeto contém uma implementação em **C#** de uma **árvore binária** construída a partir de um array de inteiros. A árvore é construída de forma que cada nó contenha o maior valor do subarray correspondente, e os elementos à esquerda e à direita do maior valor formam as subárvores esquerda e direita, respectivamente.  

A construção agora é **otimizada em O(n)** usando uma **pilha**, garantindo eficiência mesmo para arrays grandes, mantendo a mesma estrutura da versão recursiva original.

---

## Estrutura do Código

### Classes Principais

#### `No`

Representa um nó da árvore.

* **Propriedades**
  * `Valor` → valor inteiro armazenado no nó.
  * `Esquerda` → referência ao filho esquerdo.
  * `Direita` → referência ao filho direito.

* **Métodos**
  * `DefinirFilhos(No esquerda, No direita)` → define os nós filhos do nó atual.
  * `Imprimir(string prefixo = "", bool ehUltimoFilho = true)` → imprime a árvore de forma hierárquica no console.

#### `ConstrutorDeArvore`

Classe estática responsável por construir a árvore a partir de um array.

* **Métodos**
  * `ConstruirDaRaiz(int[] array)` → ponto de entrada para construção da árvore; utiliza **pilha para construir a árvore em O(n)**.
  * Mantém a lógica de Maximum Binary Tree, garantindo que cada nó seja o maior de seu subarray.

#### `Programa`

Classe que contém o método `Main` para execução e demonstração.

* Executa dois cenários de exemplo.
* Imprime o array de entrada e a árvore construída no console.

---

## Como Executar

1. Clone o repositório:

   ```bash
   git clone <https://github.com/alefsilvaf/desafio-paradigma>
   ```
2. Abra a solução ou o projeto no **Visual Studio** ou **VS Code**.
3. Compile e execute:

   ```bash
   dotnet run
   ```
4. Observe a saída no console mostrando os arrays de entrada e suas árvores correspondentes.

---

## Exemplo de Saída

**Cenário 1**

```
Array de entrada: [3, 2, 1, 6, 0, 5]
Árvore de saída:
└─ 6
   ├─ 5
   │  └─ 0
   └─ 3
      └─ 2
         └─ 1
```

**Cenário 2**

```
Array de entrada: [7, 5, 13, 9, 1, 6, 4, 3]
Árvore de saída:
└─ 13
   ├─ 9
   │  └─ 6
   │     ├─ 4
   │     │  └─ 3
   │     └─ 1
   └─ 7
      └─ 5
```

---

## Observações

* Esta implementação agora usa pilha para construir a árvore em tempo linear O(n).
* A impressão da árvore é feita de forma **visual**, usando caracteres especiais (`└─`, `├─`, `│`) para representar a hierarquia.
* Pode ser facilmente adaptada para diferentes tipos de dados ou estratégias de construção de árvore.

---

## Tecnologias

* C# 10 ou superior
* .NET 6 ou superior
* Funciona em Windows, macOS e Linux

