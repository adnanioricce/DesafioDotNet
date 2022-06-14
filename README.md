# EDIT: Como compilar e executar o projeto
## Requisitos:
- .net core SDK 6.0
- SQL Server
- ou somente docker, se preferir

## configurando o banco de dados
### Localmente
para configurar o banco de dados, execute o script em SQL/createdb.sql
### com docker
> OBS: você também pode configurar o banco de dados e executar a api com docker-compose
execute a seguinte linha.
Sim, a porta é necessária.
```bash
docker run -dt --name desafiodotnetdb -p 1233:1433 adnanioricce/desafiodotnetdb
```
## executando a Api
### A partir de uma imagem docker
```bash
docker run -dt --name desafiodotnet -p 6060:80 -e DATABASE_URL="Server=host.docker.internal,1233;Database=DesafioDb;User Id=sa;Password=!P4ssword" adnanioricce/desafiodotnet
```
### com docker compose
na raiz do projeto, digite a seguinte linha e tecle enter:
```bash
docker-compose up --build
```
isso vai compilar a api e construir um banco de dados DesafioDb com a Tabela Produto(vazia).
### com a cli do dotnet
vá até a pasta do projeto web DesafioDotNet e digite a seguinte linha:
```bash
cd DesafioDotNet
sqlcmd -S .\SQLEXPRESS -i SQL/createdb.sql
dotnet watch run
```
## Swagger
para visualziar os endpoints da API vá até /swagger
## Tabela
para visualizar a tabela, vá até /

# Desafio .NET
Desafio de contratação Khipo. Realize um fork deste repositório e faça as etapas referentes a sua vaga. O intuito desse teste é ser algo simples, porém suficiente para validar a qualidade do seu código.

## Etapa 1 (Backend)

Utilizando o framework .Net Core (https://docs.microsoft.com/pt-br/dotnet/fundamentals/) crie uma ``API Rest``. Essa API deverá ser capaz de CRUD em um banco de dados de ``Produtos``. É essencial que seja conectado em um banco de dados SQL Server.


``GET /api/v1/products``
Retorna todos os produtos em lista

``GET /api/v1/products/:productId``
Retorna apenas o produto do productId

``POST /api/v1/products``
Cria um produto

``PUT /api/v1/products/:productId``
Edita o produto do productId

``DELETE /api/v1/products/:productId``
Apaga o produto do productId

Exemplo de produtos:
```
[
 {
  "createdAt": "2022-05-20T00:31:08.822Z",
  "name": "Incredible Plastic Pants",
  "price": "827.00",
  "brand": "Hauck - Johnson",
  "updatedAt": "2022-05-22T02:31:08.822Z",
  "id": "1"
 },
 {
  "createdAt": "2022-05-20T09:05:23.745Z",
  "name": "Electronic Wooden Tuna",
  "price": "765.00",
  "brand": "Johns - Farrell",
  "updatedAt": "2022-05-20T09:05:23.745Z",
  "id": "2"
 },
 {
  "createdAt": "2022-05-20T02:07:28.065Z",
  "name": "Awesome Steel Mouse",
  "price": "143.00",
  "brand": "Paucek, Kuvalis and Zieme",
  "updatedAt": "2022-05-23T22:35:23.745Z",
  "id": "3"
 },
 ]
```

Observações
1. É necessario utilizar o Entity Framework (EF) Core
2. Não permita dois ou mais produtos com o mesmo Id, ele deve ser incremental

## Etapa 2 (Frontend)

Faça um website com ASP.Net. Esse site deve exibir uma lista de produtos de uma loja, através de sua API. Faça tratamento de erro para as chamadas.

### Design da tela
Exiba a seguinte tela, com ``Nome, Preço, Marca, Data de Criação e Data de Modificação``. Ordene por ordem de criação.

![image](https://user-images.githubusercontent.com/30670086/172623617-00692e3c-8849-473f-9145-b147b488c368.png)

![image](https://user-images.githubusercontent.com/30670086/172623809-70109ad7-b279-4221-b126-db038a7ba75d.png)

Link do Figma: https://www.figma.com/file/kgxxK5TMfNyqMLFIMqBx2k/DesafioDotNet?node-id=0%3A1



Importante
1. É permitido a utilização de pacotes de UI
2. Utilizar JQuery e boas práticas é importante para o projeto

### Pontos Extras
- [ ] Fazer função de editar e deletar na tela
- [ ] Colocar Swagger
- [ ] Usar Docker