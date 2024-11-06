using System;
using Amazon.S3;
using Amazon.S3.Model;
using System.Threading.Tasks;

namespace S3Demo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var s3Client = new AmazonS3Client(Amazon.RegionEndpoint.USEast1);
            // Explicitely assigned credentials from code
            // BEST PRACTICE : NOT RECOMMENDED
            // var awsAccessKeyId = "your-access-key-id";
            // var awsSecretAccessKey = "your-secret-access-key";
            // var s3Client = new AmazonS3Client(awsAccessKeyId, awsSecretAccessKey, Amazon.RegionEndpoint.USEast1);
            try
            {
                var response = await s3Client.ListBucketsAsync();
                Console.WriteLine("Buckets:");
                foreach (S3Bucket bucket in response.Buckets)
                {
                    Console.WriteLine(bucket.BucketName);
                }
                Console.WriteLine("Enter the name of the bucket to create:");
                var bucketName = Console.ReadLine();

                var putBucketRequest = new PutBucketRequest
                {
                    BucketName = bucketName,
                    UseClientRegion = true
                };

                var putBucketResponse = await s3Client.PutBucketAsync(putBucketRequest);
                Console.WriteLine("Bucket created successfully.");

                Console.WriteLine("Enter the file path to upload:");
                var filePath = Console.ReadLine();
                var fileName = System.IO.Path.GetFileName(filePath);

                var putObjectRequest = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = fileName,
                    FilePath = filePath
                };

                var putObjectResponse = await s3Client.PutObjectAsync(putObjectRequest);
                Console.WriteLine("File uploaded successfully.");
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when listing buckets", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when listing buckets", e.Message);
            }
        }
    }
}