# MarketAPI
 Criação de API para avaliação de desenvolvedores

Este projeto foi desenvolvido para avaliação.

Para a criação da base de dados (market) e as tabelas (Categoria e Produto) em SQL Server, localizar o arquivo ScriptDB.sql. 
Executar o script antes de rodar o projeto pela primeira vez.

No projeto, localizar o arquivo Programa.cs e alterar a linha onde consta a string de conexão conforme as configurações do computador onde estiver rodando o banco de dados.

Na primeira execução a chamada da função AppDbInitializer.Seed(app) é utilizada para popular dados a base. Case queira, pode comentar esta linha para realizar os testes com a base totalmente limpa.

Pode utilizar o gerador de documentação swagger para realizar os teste de interação com a API ou usar outro aplicativo para testar.
