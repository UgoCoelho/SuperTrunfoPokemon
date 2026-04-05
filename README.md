# 🎴 Super Trunfo Pokémon (C#)

Um jogo inspirado no clássico **Super Trunfo**, desenvolvido em C# no Visual Studio, utilizando Pokémon e seus **Base Stats** como atributos das cartas.

---

## 📌 Sobre o Projeto

Este projeto simula uma partida de Super Trunfo entre dois jogadores (**Player vs CPU**), onde cada jogador possui um baralho com cartas de Pokémon.

A cada rodada, um atributo é escolhido e comparado. O jogador com o maior valor vence e fica com as cartas.

---

## 🎮 Funcionalidades

✔ Criação de baralho com Pokémon

✔ Embaralhamento das cartas (Fisher-Yates)

✔ Distribuição automática entre jogadores

✔ Sistema de rodadas

✔ Escolha de atributos pelo jogador

✔ Comparação de cartas

✔ Exibição detalhada das cartas

✔ Sistema de grupos (A, B, C, D)

✔ Regra especial de Super Trunfo

✔ Testes unitários com MSTest

---

## 🧠 Mecânicas do Jogo

### 🎴 Rodadas

* Cada jogador joga a carta do topo do baralho
* O jogador escolhe um atributo
* Os valores são comparados

---

### 🏆 Vitória

* Quem tiver o maior valor vence a rodada
* O vencedor recebe as duas cartas

---

### 🤝 Empate

* Cada jogador mantém sua carta

---

## ⭐ Regra Especial – Super Trunfo (Arceus)

* A carta **Arceus** é o Super Trunfo
* Ele vence automaticamente qualquer carta

### ❗ EXCEÇÃO:

Uma carta pode derrotar o Arceus se:

* Pertencer ao **Grupo A**
* E tiver o valor do atributo escolhido maior

---

## 🏷️ Sistema de Grupos

Cada carta pertence a um grupo estratégico:

| Grupo | Descrição           |
| ----- | ------------------- |
| 🅰️ A | Cartas mais fortes  |
| 🅱️ B | Cartas equilibradas |
| 🅲 C  | Cartas medianas     |
| 🅳 D  | Cartas mais fracas  |

---

## 🧱 Estrutura do Projeto

```bash
SuperTrunfoPokemon/
│
├── Cartas.cs        # Modelo da carta
├── Jogador.cs       # Representa o jogador
├── Baralho.cs       # Criação e controle do baralho
├── Partida.cs       # Lógica do jogo
├── Program.cs       # Ponto de entrada
└── Tests/           # Testes automatizados
```

---

## 🧾 Principais Classes

### 🎴 Cartas

Representa uma carta do jogo com:

* Nome
* HP
* Attack
* Defense
* SpAttack
* SpDefense
* Speed
* Grupo
* IsSuperTrunfo

---

### 👤 Jogador

* Nome
* Baralho (Queue de cartas)

---

### 🎲 Baralho

Responsável por:

* Criar cartas
* Embaralhar
* Distribuir entre jogadores

---

### 🎮 Partida

Controla toda a lógica do jogo:

* Execução das rodadas
* Escolha de atributos
* Comparação de cartas
* Aplicação de regras especiais
* Verificação do vencedor

---

## ▶️ Como Executar

1. Clone o repositório:

```bash
git clone https://github.com/UgoCoelho/SuperTrunfoPokemon.git
```

2. Abra o projeto no Visual Studio

3. Execute (`F5`)

---

## 🧪 Testes

O projeto conta com testes automatizados utilizando **MSTest**, cobrindo:

* Criação e integridade do baralho
* Regras do Super Trunfo
* Distribuição de cartas
* Comportamento dos jogadores
* Regras de rodada

---

## 💻 Exemplo de Execução

```
Partida iniciada!

Carta de Player:

=== Garchomp ===
[1] HP: 108
[2] Attack: 130
[3] Defense: 95
[4] Sp. Attack: 80
[5] Sp. Defense: 85
[6] Speed: 102

Escolha um atributo:
```

---

## 🚀 Melhorias Futuras

* 🤖 Inteligência artificial para CPU
* ⚔️ Sistema de “guerra” em empates
* 🎨 Interface gráfica (WinForms ou WPF)
* 🧠 Sistema de vantagem entre grupos
* 💾 Salvamento de partidas
* 🌐 Multiplayer online

---

## 📚 Conceitos Aplicados

* Programação Orientada a Objetos (POO)
* Estruturas de dados (List, Queue)
* Lógica de programação
* Testes unitários
* Organização de código

---

## 👨‍💻 Autores

* Gabriel Tobias
* Kaike Rodrigues
* Kayky Tenório
* Marcos Leandro
* Ugo Lamana

---

## 📄 Licença

Projeto desenvolvido para fins educacionais.
