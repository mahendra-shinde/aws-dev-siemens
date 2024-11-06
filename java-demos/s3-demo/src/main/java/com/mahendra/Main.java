package com.mahendra;

import software.amazon.awssdk.core.sync.RequestBody;
import software.amazon.awssdk.regions.Region;
import software.amazon.awssdk.services.s3.S3Client;
import software.amazon.awssdk.services.s3.model.Bucket;
import software.amazon.awssdk.services.s3.model.ListBucketsResponse;
import software.amazon.awssdk.services.s3.model.S3Exception;

import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {

        S3Client s3 = S3Client.builder()
//            .credentialsProvider(StaticCredentialsProvider.create(AwsBasicCredentials.create("your_access_key_id", "your_secret_access_key")))
            .region(Region.US_EAST_1) // Specify the region you want to use
            .build();

        try {
            ListBucketsResponse listBucketsResponse = s3.listBuckets();
            List<Bucket> buckets = listBucketsResponse.buckets();
            System.out.println("List of all the buckets : \n -------------------\n ");
            for (Bucket bucket : buckets) {
            System.out.println(bucket.name());
            }

            // Create a new bucket
            System.out.println("Enter the name of the new bucket:");
            Scanner scanner = new Scanner(System.in);
            String bucketName = scanner.nextLine();
            s3.createBucket(b -> b.bucket(bucketName));
            System.out.println("Bucket created: " + bucketName);

            // Upload a file to the new bucket
            System.out.println("Enter the file path to upload:");
            String filePath = scanner.nextLine();
            Path path = Paths.get(filePath);
            String key = path.getFileName().toString();
            s3.putObject(b -> b.bucket(bucketName).key(key), RequestBody.fromFile(path));
            System.out.println("File uploaded: " + key);
        } catch (S3Exception e) {
            System.err.println(e.awsErrorDetails().errorMessage());
        }

    }
}