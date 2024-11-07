# Lambda function to detect new object in s3 bucket

## Steps to Create AWS Lambda Function Using Template "Get S3 Object" with Python Runtime

1. **Open the AWS Management Console**:
    - Navigate to the [AWS Management Console](https://aws.amazon.com/console/).

2. **Go to the Lambda Service**:
    - In the AWS Management Console, search for "Lambda" and select the Lambda service.

3. **Create a New Function**:
    - Click on the "Create function" button.

4. **Choose a Blueprint**:
    - In the "Create function" page, select the "Blueprints" option.
    - Search for the "s3-get-object-python" blueprint and select it.

5. **Configure the Function**:
    - **Function name**: Enter a name for your Lambda function.
    - **Runtime**: Ensure that "Python 3.10" is selected as the runtime.
    - **Role**: Create a new role with policy template
    

6. **Configure Triggers**:
    - S3 trigger is pre-configured in this template.
    - Select the S3 bucket you want to monitor.
    - Specify the event type (e.g., "All object create events").

7. **Review and Create**:
    - Review the configuration settings.
    - Click on the "Create function" button to create your Lambda function.

8. **Test the Function**:
    - Upload a test object to the specified S3 bucket.
    - Check the Lambda function logs in CloudWatch to verify that the function executed successfully.

9. **Deploy and Monitor**:
    - Deploy your Lambda function.
    - Monitor the function's performance and logs using AWS CloudWatch.

By following these steps, you will have created an AWS Lambda function using the "Get S3 Object" template with the Python runtime.