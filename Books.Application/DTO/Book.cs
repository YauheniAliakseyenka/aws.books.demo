using Amazon.DynamoDBv2.DataModel;

namespace Books.Application.DTO
{
    [DynamoDBTable("Books")]
    public class Book
    {
        [DynamoDBHashKey]
        public string ISBN { get; set; }

        [DynamoDBProperty]
        public string Title { get; set; }

        [DynamoDBProperty]
        public string Description { get; set; }
    }
}
