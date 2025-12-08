# ERP-BOLOVDECOR

Aplicação Windows Forms para gerenciamento de produtos e cadastros (ERP) desenvolvida em C# targeting .NET Framework 4.7.2.

## Descrição

Projeto de exemplo para cadastro de produtos, locais, assessores e decoradores. Inclui uma interface WinForms e acesso a banco de dados através de classes DAO.

## Requisitos

- Windows
- Visual Studio 2017, 2019 ou 2022 (com suporte a .NET Framework 4.7.2)
- .NET Framework 4.7.2
- Git (opcional, para clonar o repositório)
- Motor de banco de dados compatível (por exemplo, SQL Server)

## Instalação

1. Clone o repositório:

```bash
git clone https://github.com/JoaoPZSirino/ERP-BOLOVDECOR.git
cd ERP-BOLOVDECOR
```

2. Abra a solução no Visual Studio: abra o arquivo `ERPBOLOV2\ERPBOLOV2.sln`.
3. Restaure os pacotes NuGet (se houver) pelo Visual Studio: `Build` -> `Restore NuGet Packages`.

## Configuração do banco de dados

A aplicação utiliza classes `DAO` para persistência. Antes de executar, configure a string de conexão no arquivo `App.config` (ou `Properties\Settings.settings`, conforme o projeto) apontando para sua instância de banco de dados.

Exemplo de `connectionStrings` em `App.config`:

```xml
<connectionStrings>
  <add name="DefaultConnection" connectionString="Server=SEU_SERVIDOR;Database=SEU_BANCO;User Id=USUARIO;Password=SENHA;" providerName="System.Data.SqlClient" />
</connectionStrings>
```

O repositório inclui um script de criação do banco de dados chamado `banco.sql` na raiz do projeto. Importe esse arquivo antes de executar a aplicação.

Como executar `banco.sql`:

- Usando SQL Server Management Studio (SSMS):
  1. Abra o SSMS e conecte-se ao servidor desejado.
  2. Abra o arquivo `banco.sql` (`File > Open > File...`).
  3. Se necessário, selecione o banco de destino na lista de databases (ou deixe o script criar o banco se ele contiver o comando `CREATE DATABASE`).
  4. Clique em `Execute` (ou pressione `F5`).

- Usando `sqlcmd` (linha de comando):
  - Exemplo de comando para executar o script em um servidor SQL Server:

```powershell
sqlcmd -S SEU_SERVIDOR -U SEU_USUARIO -P SUA_SENHA -i banco.sql
```

  - Se o script cria o banco de dados e você precisa executar comandos em um banco específico utilize `-d NomeDoBanco` após conectar.

Observações:
- Ajuste a `connectionString` no `App.config` para apontar ao servidor e ao nome do banco gerado pelo `banco.sql`.
- Se o seu ambiente usa outro SGBD (MySQL, PostgreSQL, etc.), confirme se `banco.sql` é compatível ou converta o script para o dialeto apropriado.

> Observação: verifique as classes `DAO` para entender as tabelas e restrições esperadas pelo aplicativo.

## Compilar e executar

- Pelo Visual Studio:
  1. Selecione `ERPBOLOV2` como projeto inicial (startup project).
  2. Pressione `F5` para executar em modo Debug ou `Ctrl+F5` para executar sem Debugging.

- Executável direto:
  1. Após compilar, o executável estará em `ERPBOLOV2\bin\Debug` ou `ERPBOLOV2\bin\Release`.
  2. Execute o arquivo `ERPBOLOV2.exe` a partir dessa pasta.

## Estrutura do projeto

- `ERPBOLOV2/` - projeto principal WinForms
- `ERPBOLOV2/DAO` - classes de acesso a dados
- Formulários: `CadastrarProduto`, `CadastroLocal`, `CadastroAssessor`, `CadastroDecorador`, etc.

