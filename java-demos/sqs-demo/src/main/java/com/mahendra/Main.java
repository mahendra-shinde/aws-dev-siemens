package com.mahendra;

import software.amazon.awssdk.auth.credentials.AwsBasicCredentials;
import software.amazon.awssdk.auth.credentials.StaticCredentialsProvider;
import software.amazon.awssdk.regions.Region;
import software.amazon.awssdk.services.sqs.SqsClient;
import software.amazon.awssdk.services.sqs.model.SendMessageRequest;

public class Main {
    public static void main(String[] args) {
        
        // Create SQS client
        SqsClient sqsClient = SqsClient.builder()
                .region(Region.US_EAST_1)
                .build();
        
        // Queue URL Update from AWS Console
        String queueUrl = "https://sqs.us-east-1.amazonaws.com/890756660068/queue101";
        
        // Send message
        SendMessageRequest sendMsgRequest = SendMessageRequest.builder()
                .queueUrl(queueUrl)
                .messageBody("Hello, this is a test message!")
                .build();
        
        sqsClient.sendMessage(sendMsgRequest);
        
        System.out.println("Message sent to queue: " + queueUrl);
    }
}