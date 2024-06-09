# Arquitetura da Solução

<span style="color:red">Pré-requisitos: <a href="3-Projeto de Interface.md"> Projeto de Interface</a></span>

Definição de como o software é estruturado em termos dos componentes que fazem parte da solução e do ambiente de hospedagem da aplicação.

## Diagrama de Classes

O diagrama de classes ilustra graficamente como será a estrutura do software, e como cada uma das classes da sua estrutura estarão interligadas. Essas classes servem de modelo para materializar os objetos que executarão na memória.

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t8-pmv-ads-2024-1-e2-roda-velha/assets/59897366/4e7fb530-5ceb-4a8e-9229-8ab67a76a653)

## Modelo ER (Projeto Conceitual)

O Modelo ER representa através de um diagrama como as entidades (coisas, objetos) se relacionam entre si na aplicação interativa.

![Conceitual_2](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t8-pmv-ads-2024-1-e2-roda-velha/assets/59897366/152238e6-0bcc-4b82-9d73-1e2bade36b38)

## Projeto da Base de Dados

O projeto da base de dados corresponde à representação das entidades e relacionamentos identificadas no Modelo ER, no formato de tabelas, com colunas e chaves primárias/estrangeiras necessárias para representar corretamente as restrições de integridade.

![D_database](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t8-pmv-ads-2024-1-e2-roda-velha/assets/59897366/3eddf6ee-3cc0-479f-b449-18076f78df27)


## Tecnologias Utilizadas

A tecnologia de banco de dados para armazenamento será utilizado o PostgreeSQL ou o MySQL, que é um banco de dados relacional já consagrado no mercado, rodando em plataformas Linux, Windows e Mac.
A codificação do site (front-end) será feito com as linguagens de marcação HTML5, CSS e o framework BootStrap. Para interatividade será usado o JavaScript.
Para a manipulação dos dados do lado do servidor, ou seja o back-end, será adotado a linguagem C# que é uma linguagem fortemente tipada e orientada a objetos além de contar com excelente performance em vários cenários de aplicação.

## Hospedagem & Arquitetura de Software

A hospedagem do site será feita na plataforma de Cloud Azure da microsoft. O serviço/recurso utilizado é de Máquinas Virtuais na versão Linux Ubuntu 20.04, usando a Standard DS1 v2 (1 vcpu, 3.5 GiB de memória) e para armazenamento o Azure Managed Disks, com 30GB de espaço em disco.

Na borda está sendo utilizado o servidor Nginx configurado como proxy reverso na porta 80 e redirecionando na porta 5000 onde o servidor Kestrel recebe a solicitação e retorna com os arquivos compilados e processados dos arquivos asp.net core mvc.

Para upload dos arquivos do site um webhook é acionado no servidor linux a partir de uma requisição post enviada do github para o servidor informando que o repositório foi alterado, o servidor então efetua o download dos códigos atualizados, o compila e reinicia os serviços do servidor kestrel.

![Software_Architecture](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t8-pmv-ads-2024-1-e2-roda-velha/assets/59897366/8b421115-3e30-4ebb-8668-29671403e296)



> **Links Úteis**:
>
> - [Website com GitHub Pages](https://pages.github.com/)
> - [Programação colaborativa com Repl.it](https://repl.it/)
> - [Getting Started with Heroku](https://devcenter.heroku.com/start)
> - [Publicando Seu Site No Heroku](http://pythonclub.com.br/publicando-seu-hello-world-no-heroku.html)
