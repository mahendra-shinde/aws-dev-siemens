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

            try
            {
                var response = await s3Client.ListBucketsAsync();
                Console.WriteLine("Buckets:");
                foreach (S3Bucket bucket in response.Buckets)
                {
                    Console.WriteLine(bucket.BucketName);
                }
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