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

## Dicas para quem usa Visual Studio Code

### Extensões Necessárias

Certifique-se de ter as seguintes extensões instaladas no Visual Studio Code:

- **C# Dev Kit**
- **C#**
- **.NET Install Tool**
- **.NET Extension Pack**
- **C# Extensions**
- **NuGet Gallery** (A mais importante para baixar os pacotes necessários para o .NET)

### Rodando o Projeto

1. **Instalar as Extensões**: Certifique-se de que todas as extensões mencionadas acima estão instaladas.

2. **Navegar para a Pasta do Projeto**:

   - Abra o terminal no Visual Studio Code.
   - Navegue até a pasta `RodaVelha` do seu projeto.

3. **Executar os Comandos**:
   - **Restaurar Pacotes**: Baixa os pacotes presentes no arquivo `RodaVelha.csproj`.
     ```bash
     dotnet restore
     ```
   - **Compilar o Projeto**:
     ```bash
     dotnet build
     ```
   - **Criar uma Migração**: (Atenção: Não é mais necessário, pois o banco já está na nuvem)
     ```bash
     dotnet ef migrations add Init
     ```
   - **Atualizar o Banco de Dados**: (Atenção: Não é mais necessário, pois o banco já está na nuvem)
     ```bash
     dotnet ef database update
     ```
   - **Rodar o Projeto**: Executa o projeto em modo de observação.
     ```bash
     dotnet watch run
     ```

### Observações

- **Migrações e Atualizações do Banco de Dados**: Os comandos para criar migrações e atualizar o banco de dados não são mais necessários, pois o banco de dados já está na nuvem.

Seguindo essas instruções, você deve ser capaz de configurar e rodar o projeto `RodaVelha` no Visual Studio Code.
