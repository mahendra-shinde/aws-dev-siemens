using System;
using Amazon.SQS;
using Amazon.SQS.Model;
using System.Threading.Tasks;

class Program
{
    private static readonly string queueUrl = "https://sqs.us-east-1.amazonaws.com/890756660068/queue101";

    static async Task Main(string[] args)
    {
        var sqsClient = new AmazonSQSClient();

        Console.WriteLine("Receiving messages from SQS queue...");
        await ReceiveMessagesAsync(sqsClient);
    }

    private static async Task ReceiveMessagesAsync(AmazonSQSClient sqsClient)
    {
        var receiveMessageRequest = new ReceiveMessageRequest
        {
            QueueUrl = queueUrl,
            MaxNumberOfMessages = 10,
            WaitTimeSeconds = 5
        };

        var receiveMessageResponse = await sqsClient.ReceiveMessageAsync(receiveMessageRequest);

        if (receiveMessageResponse.Messages.Count > 0)
        {
            foreach (var message in receiveMessageResponse.Messages)
            {
                Console.WriteLine($"Message received: {message.Body}");
                // Process the message
                // ...

                // Delete the message after processing
                var deleteMessageRequest = new DeleteMessageRequest
                {
                    QueueUrl = queueUrl,
                    ReceiptHandle = message.ReceiptHandle
                };
                await sqsClient.DeleteMessageAsync(deleteMessageRequest);
                Console.WriteLine("Message deleted.");
            }
        }
        else
        {
            Console.WriteLine("No messages to receive.");
        }
    }
}
