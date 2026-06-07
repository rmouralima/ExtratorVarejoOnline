# ExtratorVarejoOnline

O **ExtratorVarejoOnline** é uma aplicação Console desenvolvida em C# com o objetivo de extrair, processar e exportar dados financeiros e contábeis de sistemas de varejo. O projeto foi desenhado com foco em organização e responsabilidade única, facilitando a manutenção e a escalabilidade.

## 📂 Estrutura do Projeto

A arquitetura do projeto está dividida nos seguintes diretórios e componentes principais:

* **`Models/`**: Contém as classes que representam as entidades de domínio dos dados manipulados.
    * `ContasContabeis.cs`: Estrutura de dados para o plano de contas.
    * `ContasPagar.cs`: Entidade de registros de obrigações financeiras (contas a pagar).
    * `ContasReceber.cs`: Entidade de registros de direitos financeiros (contas a receber).
    * `Terceiros.cs`: Modelo para o cadastro de clientes e fornecedores.

* **`Services/`**: Camada responsável por concentrar a lógica de negócios e as integrações (como o consumo de APIs).
    * `ContasContabeisService.cs`: Gerencia as operações referentes às contas contábeis.
    * `ContasPagarService.cs`: Processa as regras de negócio de contas a pagar.
    * `ContasReceberService.cs`: Processa as regras de negócio de contas a receber.
    * `TerceiroServices.cs`: Lida com o processamento dos dados de terceiros.
    * `TokenProvider.cs`: Classe dedicada ao gerenciamento e autenticação de tokens, garantindo o acesso seguro a endpoints externos.

* **`Utils/`**: Ferramentas e rotinas utilitárias de suporte ao sistema.
    * `ConversorJson.cs`: Utilitário para realizar a serialização e desserialização padronizada de payloads de requisições e respostas.
    * `ExportadorCSV.cs`: Serviço dedicado a compilar as informações em memória e gerar os arquivos finais em formato `.csv`.

* **Raiz**:
    * `Program.cs`: Ponto de entrada da aplicação (*entry point*), responsável por inicializar os serviços, realizar as injeções de dependência e orquestrar o fluxo de execução.