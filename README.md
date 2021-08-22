# inoa-code-challenge
## by Luiz Fernando

Desafio de code fonte da INOA realizado por mim.

Este código consiste em um Console app e uma API para monitoramento e aviso de oportunidades no mercado financeiro (B3).

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

### Pré-requisitos

#### Ubuntu

1. Para rodar no Ubuntu é necessário instalar o .net core runtime.
2. Executar o comando: export DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1