# WebApp

## Descrição
Este projeto é uma aplicação web construída utilizando ASP.NET Core, que demonstra o uso de middlewares para manipulação de requisições HTTP e medição do tempo de execução de determinadas rotas. Ele também ilustra a configuração de opções usando o padrão de Injeção de Dependência do ASP.NET Core.

## Funcionalidades Principais
- **Manipulação de Requisições**: O projeto utiliza middlewares para processar e responder a diferentes rotas e parâmetros de consulta (query parameters) das requisições HTTP.
- **Medição de Tempo de Execução**: Um middleware específico é utilizado para calcular e exibir o tempo de execução de determinadas rotas, permitindo a escolha da unidade de medida para exibição do tempo.

## Estrutura do Projeto
- **Startup.cs**: Configura a aplicação, define os serviços utilizados e configura os middlewares.
- **MetodosExtensao.cs**: Fornece um método de extensão para facilitar a inclusão do middleware de cálculo de tempo de execução.
- **CronometroOptions.cs**: Define as opções de configuração para o cálculo do tempo de execução.
- **ContadorOptions.cs**: Define as opções de configuração para a contagem utilizada em um dos middlewares.
- **MiddlewareTempoExecucao.cs**: Implementa o middleware responsável por calcular e exibir o tempo de execução.

## Configuração
O arquivo `appsettings.json` contém as configurações gerais do aplicativo, incluindo as opções para o cálculo do tempo de execução. Você pode ajustar as configurações de log e outras configurações gerais nesse arquivo.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "CronometroOptions": {
    "UnidadeMedida": "Microssegundo"
  }
}
```

## Como Executar o Projeto
Certifique-se de ter o ambiente de desenvolvimento para ASP.NET Core configurado.
## Clone o repositório.
Abra o projeto em sua IDE (Visual Studio, Visual Studio Code, etc.).
Execute a aplicação.
### Uso
Após executar a aplicação, você pode fazer solicitações HTTP para diferentes rotas e parâmetros de consulta para observar o comportamento dos middlewares e a medição do tempo de execução em algumas rotas específicas.
## Autor
Este projeto foi criado por Agata Domingues.

### Contribuindo
Se deseja contribuir para este projeto, sinta-se à vontade para fazer um fork e enviar pull requests com melhorias, correções de bugs ou novas funcionalidades.




