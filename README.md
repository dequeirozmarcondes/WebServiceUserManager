# Sistema de Autentica��o com ASP.NET Core e JWT

Este projeto demonstra a implementa��o de um sistema de autentica��o utilizando ASP.NET Core, Identity e JSON Web Tokens (JWT).

## Vis�o Geral

O sistema de autentica��o permite que usu�rios fa�am registro, login e logout, gerando tokens JWT para autentica��o segura em APIs. O fluxo de autentica��o garante que apenas usu�rios autenticados possam acessar recursos protegidos.

## Fluxo de Autentica��o

1. **Registro**: O usu�rio cria uma conta fornecendo um nome de usu�rio, email e senha.
2. **Login**: O usu�rio faz login com email e senha. Se as credenciais forem v�lidas, um token JWT � gerado.
3. **Autentica��o**: Para acessar recursos protegidos, o usu�rio deve fornecer o token JWT no cabe�alho da requisi��o.
4. **Logout**: O usu�rio pode fazer logout, invalidando a sess�o atual.

## Fluxograma do Processo de Autentica��o

![Fluxo de Autentica��o](./ImgREADME/authentication-flow.gif)

## Endpoints

- `POST /api/account/register`: Registra um novo usu�rio.
- `POST /api/account/login`: Faz login e gera um token JWT.
- `POST /api/account/logout`: Faz logout do usu�rio autenticado.

## Requisitos

- .NET 8 ou superior
- Visual Studio Community 2022 ou Visual Studio Code
- Banco de dados PostgreSQL (ou outro banco de dados configurado)

## Executando o Projeto

1. Clone o reposit�rio e navegue at� a pasta do projeto.
2. Configure as vari�veis de configura��o no arquivo `appsettings.json`.
3. Execute os comandos abaixo para restaurar os pacotes e rodar a aplica��o:

    ```bash
    dotnet restore
    dotnet run
    ```

4. A aplica��o estar� dispon�vel em `http://localhost:5000`.

## Uso do Token JWT

Para acessar endpoints protegidos, inclua o token JWT no cabe�alho `Authorization` da requisi��o:

```http
Authorization: Bearer <seu_token_jwt>
```
## Tecnologias Utilizadas

- ASP.NET Core
- Entity Framework Core
- JWT (JSON Web Tokens)
- Swagger para documenta��o da API

## Contribui��o

Sinta-se � vontade para contribuir com melhorias para este projeto. Abra uma issue para discutir mudan�as que voc� gostaria de fazer.

## Licen�a

Este projeto est� licenciado sob a [MIT License](LICENSE).

## Imagem do Fluxo de Autentica��o

Voc� pode criar uma imagem ilustrativa do fluxo de autentica��o utilizando ferramentas como [draw.io](https://www.draw.io/) ou qualquer outra ferramenta de diagrama��o. Ap�s criar a imagem, salve-a como `authentication-flow.png` na pasta raiz do projeto. Aqui est� uma descri��o de como seria o fluxo visualmente:

1. **Registro**:
    - O usu�rio envia nome de usu�rio, email e senha.
    - O servidor valida os dados e cria a conta.
  
2. **Login**:
    - O usu�rio envia email e senha.
    - O servidor valida as credenciais e gera um token JWT.

3. **Autentica��o**:
    - O usu�rio envia o token JWT no cabe�alho da requisi��o.
    - O servidor valida o token e, se v�lido, permite o acesso ao recurso protegido.

4. **Logout**:
    - O usu�rio requisita o logout.
    - O servidor invalida a sess�o.

## Conclus�o

Este `README.md` proporciona uma vis�o geral do sistema de autentica��o, descreve os endpoints dispon�veis e inclui instru��es de configura��o e execu��o. A imagem ilustrativa ajudar� a entender o fluxo de autentica��o de maneira visual. Sinta-se � vontade para ajustar conforme necess�rio!