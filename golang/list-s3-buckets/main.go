package main

import (
    "context"
    "fmt"
    "log"

    "github.com/aws/aws-sdk-go-v2/aws"
    "github.com/aws/aws-sdk-go-v2/config"
    "github.com/aws/aws-sdk-go-v2/service/s3"
)

func main() {
    // Load the Shared AWS Configuration (~/.aws/config)
    cfg, err := config.LoadDefaultConfig(context.TODO(), config.WithRegion("us-east-1"))
    if err != nil {
        log.Fatalf("unable to load SDK config, %v", err)
    }

    // Create an Amazon S3 service client
    svc := s3.NewFromConfig(cfg)

    // List Buckets
    result, err := svc.ListBuckets(context.TODO(), &s3.ListBucketsInput{})
    if err != nil {
        log.Fatalf("unable to list buckets, %v", err)
    }

    fmt.Println("Buckets:")
    for _, bucket := range result.Buckets {
        fmt.Printf("* %s created on %s\n", aws.ToString(bucket.Name), aws.ToTime(bucket.CreationDate))
    }
}