# Api.Juros

Projeto que visa efetuar o cálculo de juros compostos.

O projeto se divide basicamente em duas APIs: ApiJuros.Taxas e ApiJuros.Calculos.

# ApiJuros.Taxas

A API ApiJuros.Taxas é responsável por fornecer uma taxa de juros para ser utilizada no cálculo de juros compostos.

Para obter uma taxa de juros deve-se utilizar o recurso:

```
/taxajuros
```

# ApiJuros.Calculos

A API ApiJuros.Calculos é responsável por efetuar o cálculo dos juros compostos.

Para obter uma taxa de juros deve-se utilizar o recurso informando o valor inicial e o período em meses:

```
/calculajuros?valorinicial=?&meses=?
```

A taxa de juros que será utilizada no cálculo não precisa ser informada pois será obtida automaticamente por meio da API ApiJuros.Taxas.

# Configurando a API

Para executar a API ApiJuros.Calculos deve-se primeiramente publicar a ApiJuros.Taxas.
Após publicar a ApiJuros.Taxas, deve-se configurar o arquivo appsettings.json da API ApiJuros.Calculos com o endereço da ApiJuros.Taxas publicada.

```csharp
	"TaxaJurosOpcoes": {
		"UrlServicoTaxaJuros": "url/taxajuros"
	}
```

* **UrlServicoTaxaJuros**: Deve-se informar o endereço do recurso "taxajuros" para que o mesmo possa ser utilizado no cálculo dos juros compostos.

# Docker + Código Fonte

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

# Docker + Imagens

Para executar os projetos ApiJuros.Taxas e ApiJuros.Calculos utilizando apenas imagens Docker, execute os comandos:

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