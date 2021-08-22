# inoa-code-challenge
## by Luiz Fernando

Desafio de code fonte da INOA realizado por mim.

Este código consiste em um Console app e uma API para monitoramento/aviso de oportunidades no mercado financeiro (B3).

Onde você informa o código do ativo a ser monitorado, os valores de suporte e resistência. Então o App informa os momentos de entrada e saída por e-mail.

### Serviços utilizados
**Send Grid**

Utilizado como servidor smtp relay

**Alpha Vantage**

Api para consumo de informações sobre a cotação dos ativos

### Softwares utilizados

- **VSCode**

- **vim**

- **dotnet CLI**

### Framework

- **.net core 3.1**

### Libs utilizadas

- **NewtonSoft.Json**

- **Swashbuckle**

- **mustache-sharp**

- **Stubble.Core**

- **xunit**

- **NSubstitute**

Dentre outros assemblies...


### Melhorias em andamento e pendentes:

- Melhoria na injeção de dependência das configurações e das urls;
- Testes em exceções;
- Teste unitário na camada de infra;
- Criptografar ou mascarar settings;

### Licença

Conforme informado no arquivo "LICENSE" este código está livre para distribuição, alteração e comercialização, sem a necessidade de pagamento de licença, roalties, taxas ou qualquer tipo de cobrança financeira, sem a obrigação da informação do autor.
Caso tenha dúvida, não deixe de entrar em contato comigo através do e-mail: fernando@cerkal.com.br 

### Testes

Para executar os testes é necessário digitar dotnet test no console. Sempre rodando dentro do path raiz (onde fica o arquivo da solution)

### Pré-requisitos

#### Linux

1. Para rodar no Linux é necessário instalar o .net core runtime. (Script testado no Ubuntu)
2. Executar o comando: export DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1
3. Para debugar é necessário escolher a config "Both Console & Web API", pois ela vai rodar tanto a API, quanto o console.