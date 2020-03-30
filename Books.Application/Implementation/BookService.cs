using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Books.Application.Contracts;
using Books.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Implementation
{
    public class BookService : IBookService
    {
        private IAmazonDynamoDB _dbClient;
        private readonly string tableName = "Books";

        public BookService(IAmazonDynamoDB dbClient)
        {
            _dbClient = dbClient;
        }

        public async Task<Book> Get(string isbn)
        {
            var response = await _dbClient.GetItemAsync(tableName, GetKey(isbn));

            return Map(response.Item);
        }

        private Book Map(Dictionary<string, AttributeValue> from)
        {
            if (from == null || !from.Any())
            {
                return null;
            }

            return new Book
            {
                ISBN = from["ISBN"].S,
                Description = from["Description"].S,
                Title = from["Title"].S
            };
        }

        private Dictionary<string, AttributeValue> GetKey(string isbn)
        {
            return new Dictionary<string, AttributeValue>
            {
                { "ISBN", new AttributeValue { S = isbn } }
            };
        }
    }
}
