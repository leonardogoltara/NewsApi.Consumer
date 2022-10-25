# News Api Consumer
Projeto de teste para a empresa Innovea(https://innovea.com.br/). 
API construída para buscar artigos na plataforma News API(https://newsapi.org/v2/everything).

curl --location --request GET 'https://newsapi.org/v2/everything?q=tesla&from=2022-09-25&sortBy=publishedAt&apiKey=84e4d640e01d4ff0b0c84a96e628d7ed'

#### Parâmetros:
* Termo(q): Termo de busca.
* Desde(from): data desde que o artigo foi criado.

#### Parâmetros fixos:
* Chave de acesso da API(apiKey): 84e4d640e01d4ff0b0c84a96e628d7ed
* Ordenação(sortBy): ordenado por data de publicação.

## Resposta
* Autor
* Título
* Descrição

## Documentação
* Api com parâmetros e respostas documentadas no Swagger.
