# AveryDennisonAPI

This API is a project created for my application to Avery Dennison as a test of technical ability.  The API allows a program to interface with a database (currently local storage for simplicity) to track sales of an item.  Those sales are stored as a JSON object as such:
```{
    "id": 1,
    "date": "2020-01-02T00:00:00",
    "articleNumber": "shirt1",
    "salesPrice": 5.99
}
```
This is my first project in C#/.NET, and took about 7-8 hours not including research.  

## Usage

#### Adding Sales

To add a sale, send a POST request to:
https://localhost:{PORT}/api/Sales

The api expects a JSON object with the following format:
```{
	"Date":"2020-01-01",
	"ArticleNumber":"shirt1",
	"SalesPrice":5.99
}
```
and will respond with the created object.  

#### Getting Data and Statistics

To get an all sales, send a GET request to:

https://localhost:{PORT}/api/Sales

which will return an array of sale objects.  

To get an individual sale, send a GET request to:

https://localhost:{PORT}/api/Sales/{SaleId}

which will return the sale object, or a 404 error if the sale is not found.  

To find the number of articles on a given date, send a GET request to:

https://localhost:{PORT}/api/Sales/salesByDate/{Date in format: yyyy-mm-dd}

which will return the number of sales on that given day.  This will not respond with any data about aformentioned sales.  

To find revenue by date, send a GET request to:

https://localhost:{PORT}/api/Sales/revenueByDate/{Date in format: yyyy-mm-dd}

which will respond with the total revenue of that given day.  This will not respond with any data about sales on that date.  

To find all revenue grouped by article number, send a GET request to:

https://localhost:{PORT}/api/Sales/revenueByArticle/{ArticleNumber}

which will respond with a list of articles and their respective revenues.  

To find revenue by article number, send a GET request to:

https://localhost:{PORT}/api/Sales/revenueByArticle/{ArticleNumber}

which will respond with the total revenue of that article.

## Existing Issues

- Responses vary wildly, I would like to normalize them with a response object.  
- Getting revenue sorted by articles requires two O(n^2) functions, requires more work for higher efficiency.
