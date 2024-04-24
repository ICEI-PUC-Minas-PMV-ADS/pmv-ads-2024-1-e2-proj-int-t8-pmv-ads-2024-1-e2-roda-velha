# Instruções de Instalação para o Projeto RodaVelha

Este documento fornece um guia passo a passo para configurar e iniciar o projeto RodaVelha em seu ambiente local.

## Pré-requisitos

Antes de iniciar a instalação, certifique-se de que você tem os seguintes pré-requisitos instalados:

- [Git](https://git-scm.com/downloads)
- [.NET Core SDK](https://dotnet.microsoft.com/download) (a versão compatível com o projeto)
- [Visual Studio](https://visualstudio.microsoft.com/downloads/) com o ASP.NET e desenvolvimento web workload ou [Visual Studio Code](https://code.visualstudio.com/)

## Clonar o Repositório

1. Abra o terminal ou o prompt de comando.
2. Navegue até o diretório onde deseja clonar o projeto.
3. Execute o seguinte comando Git:

   ```bash
   git clone https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t8-pmv-ads-2024-1-e2-roda-velha.git
   ```

## Instalação do Projeto

1. Abra o **Visual Studio**.
2. No menu **Arquivo**, escolha **Abrir** e, em seguida, **Projeto/Solução**.
3. Navegue até o diretório onde você clonou o repositório e abra o arquivo de solução do projeto (`.sln`).

## Configuração do Banco de Dados

1. No menu **Ferramentas** do Visual Studio, selecione **Gerenciador de Pacotes NuGet** e depois **Console do Gerenciador de Pacotes**.
2. No Console do Gerenciador de Pacotes (PMC), execute os comandos a seguir:

   ```powershell
   Update-Database
   ```

- Update-Database: Aplica a migração ao banco de dados, criando o esquema conforme definido.

## Executar o Projeto

Após a configuração do banco de dados, você pode executar o projeto:

No Visual Studio, pressione `Ctrl + F5` para iniciar o projeto sem depuração.
Uma janela do navegador deve abrir com a aplicação RodaVelha em execução.

## Próximos Passos

Após instalar e executar o projeto com sucesso, você pode:

- Navegar pela aplicação para verificar se todas as páginas estão carregando corretamente.
- Consultar a documentação do projeto para entender melhor a arquitetura e as funcionalidades.
