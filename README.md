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

Execute um script de criação SQL no diretório do projeto.

> Observação: o repositório pode não incluir scripts de migração. Verifique as classes `DAO` para entender as entidades e a estrutura esperada.

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

## Contribuição

Pull requests são bem-vindos. Para contribuições:

1. Crie um branch com sua feature: `git checkout -b feature/nova-feature`.
2. Commit suas mudanças e abra um Pull Request.

## Suporte

Para dúvidas sobre execução ou instalação, abra uma issue no repositório.

