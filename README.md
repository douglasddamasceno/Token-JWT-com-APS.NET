# Gestão de Tokens JWT com API Mínima
A API está sendo construída com o *template* MinimalAPI do .NET 10 e segue estruturada com adoção do padrão arquitetural VSA (Vertical Slice Architecture), simplificando o agrupamento de recursos por suas finalidades sob a ótica de negócio.

### MinimalAPI
API com abordagem simplificada para criação de serviços REST, com o usuo mínimo de dependências para criação de *endpoints* funcionais.
```powershell
dotnet new web -o MinhaAPI
```
Para saber mais sobre a criação de API's mínimas, veja o artigo https://learn.microsoft.com/pt-br/aspnet/core/tutorials/min-web-api?view=aspnetcore-10.0&WT.mc_id=dotnet-35129-website&tabs=visual-studio-code.

### Vertical Slice Architecture - VSA
Abordagem de design de *software* que organiza o código por funcionalidades de negócio, em vez das tradicionais camadas horizontais (Apresentação, Aplicação, Domínio e Infraestrutura). Para saber mais sobre a abordagem VSA, veja o seguinte https://www.milanjovanovic.tech/blog/vertical-slice-architecture.
