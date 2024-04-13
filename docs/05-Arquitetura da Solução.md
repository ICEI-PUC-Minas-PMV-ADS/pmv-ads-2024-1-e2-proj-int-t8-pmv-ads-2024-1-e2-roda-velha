# Arquitetura da Solução

<span style="color:red">Pré-requisitos: <a href="3-Projeto de Interface.md"> Projeto de Interface</a></span>

Definição de como o software é estruturado em termos dos componentes que fazem parte da solução e do ambiente de hospedagem da aplicação.

## Diagrama de Classes

O diagrama de classes ilustra graficamente como será a estrutura do software, e como cada uma das classes da sua estrutura estarão interligadas. Essas classes servem de modelo para materializar os objetos que executarão na memória.

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t8-pmv-ads-2024-1-e2-roda-velha/assets/59897366/fdaaf7a1-c32c-42ef-aa4d-9febd07a0752)



## Modelo ER (Projeto Conceitual)

O Modelo ER representa através de um diagrama como as entidades (coisas, objetos) se relacionam entre si na aplicação interativa.

![Conceitual_2](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t8-pmv-ads-2024-1-e2-roda-velha/assets/59897366/152238e6-0bcc-4b82-9d73-1e2bade36b38)



## Projeto da Base de Dados

O projeto da base de dados corresponde à representação das entidades e relacionamentos identificadas no Modelo ER, no formato de tabelas, com colunas e chaves primárias/estrangeiras necessárias para representar corretamente as restrições de integridade.
 
![Diagrama modelagem de banco de dados](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t8-pmv-ads-2024-1-e2-roda-velha/assets/59897366/aac947fe-d289-4706-bba8-8ce65f38e920)


## Tecnologias Utilizadas

A tecnologia de banco de dados para armazenamento será utilizado o PostgreeSQL, que é um banco de dados relacional já consagrado no mercado, rodando em plataformas Linux, Windows e Mac.
A codificação do site (front-end) será feito com as linguagens de marcação HTML5, CSS e o framework BootStrap. Para interatividade será usado o JavaScript.
Para a manipulação dos dados do lado do servidor, ou seja o back-end, será adotado a linguagem C# que é uma linguagem fortemente tipada e orientada a objetos além de contar com excelente performance em vários cenários de aplicação.

## Hospedagem

Explique como a hospedagem e o lançamento da plataforma foi feita.

A hospedagem do site será feita na plataforma de Cloud Azure da microsoft. Será usado o serviço de Máquinas Virtuais na versão Linux, usando a instância B2ats v2, com 2 vCPU, 1GB de RAMe para armazenamento o Azure Managed DIsks, com 30GB de espaço em disco.
O servidor integrado com o ASP.NET CORE será o Kestrel.

> **Links Úteis**:
>
> - [Website com GitHub Pages](https://pages.github.com/)
> - [Programação colaborativa com Repl.it](https://repl.it/)
> - [Getting Started with Heroku](https://devcenter.heroku.com/start)
> - [Publicando Seu Site No Heroku](http://pythonclub.com.br/publicando-seu-hello-world-no-heroku.html)
