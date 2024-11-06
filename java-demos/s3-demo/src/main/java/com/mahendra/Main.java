package com.mahendra;

import software.amazon.awssdk.regions.Region;
import software.amazon.awssdk.services.s3.S3Client;
import software.amazon.awssdk.services.s3.model.Bucket;
import software.amazon.awssdk.services.s3.model.ListBucketsResponse;
import software.amazon.awssdk.services.s3.model.S3Exception;
import java.util.List;

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
        } catch (S3Exception e) {
            System.err.println(e.awsErrorDetails().errorMessage());
        }

    }
}