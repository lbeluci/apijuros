# Api.Juros

Projeto que visa efetuar o cálculo de juros compostos.

O projeto se divide em duas APIs: ApiJuros.Taxas e ApiJuros.Calculos.

1. ApiJuros.Taxas

A API ApiJuros.Taxas é responsável por retornar uma taxa de juros para ser utilizada no cálculo de juros compostos.

2. ApiJuros.Calculos

A API ApiJuros.Calculos é responsável por efetuar o cálculo de juros.
A ApiJuros.Calculos utiliza a ApiJuros.Taxas para obter a taxa de juros que será utilizada no cálculo.

# Configurando a API

Para executar a API ApiJuros.Calculos deve-se primeiramente publicar a ApiJuros.Taxas.
Após publicar a ApiJuros.Taxas, deve-se configurar o arquivo appsettings.json da API ApiJuros.Calculos com o endereço da ApiJuros.Taxas publicada.

```csharp
	"TaxaJurosOpcoes": {
		"UrlServicoTaxaJuros": "url/taxajuros"
	}
```

* **UrlServicoTaxaJuros**: Endereço do recurso "taxajuros" para ser utilizado no cálculo de juros compostos

# Docker

Para executar os projetos ApiJuros.Taxas e ApiJuros.Calculos utilizando Docker e o código fonte do projeto, posicione o cursor do Terminal na pasta "src" e execute os comandos:

```docker
docker build -f .\ApiJuros.Taxas\Dockerfile -t lbeluci/apitaxasjuros .
```

```docker
docker build -f .\ApiJuros.Calculos\Dockerfile -t lbeluci/apicalculosjuros .
```

```docker
docker network create apinet
```

```docker
docker run -d -p 80:80 --name apitaxasjuros --net apinet lbeluci/apitaxasjuros
```

```docker
docker run -d -p 8080:80 --name apicalculosjuros --net apinet lbeluci/apicalculosjuros
```

Para executar os projetos ApiJuros.Taxas e ApiJuros.Calculos utilizando Docker, execute os comandos:

```docker
docker pull lbeluci/apitaxasjuros:latest
```

```docker
docker pull lbeluci/apicalculosjuros:latest
```

```docker
docker network create apinet
```

```docker
docker run -d -p 80:80 --name apitaxasjuros --net apinet lbeluci/apitaxasjuros
```

```docker
docker run -d -p 8080:80 --name apicalculosjuros --net apinet lbeluci/apicalculosjuros
```