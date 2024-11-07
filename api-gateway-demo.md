### Demo: AWS API Gateway with Two Lambda Functions

This guide demonstrates how to set up an AWS API Gateway that routes requests to two separate Lambda functions. The first function returns mock product details, and the second returns mock customer details. The API Gateway will route requests with the pattern `/product` to the first Lambda and `/customer` to the second Lambda.

#### Step 1: Create Lambda Functions

1. **Create Lambda Function for Product Details**:
   - Go to the AWS Lambda console.
   - Click on "Create function".
   - Choose "Author from scratch".
   - Name the function `ProductDetailsFunction`.
   - Choose a runtime (e.g., Python 3.8).
   - Create the function.
   - Add the following code to the function:

     ```python
     import json

     def lambda_handler(event, context):
         product = {
             "id": "1",
             "name": "Mock Product",
             "price": 19.99
         }
         return {
             'statusCode': 200,
             'body': json.dumps(product)
         }
     ```

   - Deploy the function.

2. **Create Lambda Function for Customer Details**:
   - Go to the AWS Lambda console.
   - Click on "Create function".
   - Choose "Author from scratch".
   - Name the function `CustomerDetailsFunction`.
   - Choose a runtime (e.g., Python 3.8).
   - Create the function.
   - Add the following code to the function:

     ```python
     import json

     def lambda_handler(event, context):
         customer = {
             "id": "1",
             "name": "John Doe",
             "email": "john.doe@example.com"
         }
         return {
             'statusCode': 200,
             'body': json.dumps(customer)
         }
     ```

   - Deploy the function.

#### Step 2: Create API Gateway

1. **Navigate to API Gateway**:
   - Go to the AWS Management Console.
   - Search for API Gateway and open it.

2. **Create a New API**:
   - Click on "Create API".
   - Choose "REST API" and click "Build".
   - Name the API (e.g., `DemoAPI`).
   - Click "Create API".

3. **Create Resources and Methods**:
   - Click on "Actions" and select "Create Resource".
   - Name the resource `product` and click "Create Resource".
   - With `/product` selected, click on "Actions" and select "Create Method".
   - Choose `GET` and click the checkmark.
   - Select "Lambda Function" as the integration type.
   - Choose the region and enter the name of the `ProductDetailsFunction`.
   - Click "Save" and confirm the prompt to add necessary permissions.

   - Repeat the above steps to create a `/customer` resource and a `GET` method integrated with the `CustomerDetailsFunction`.

#### Step 3: Deploy the API

1. **Create Deployment Stage**:
   - Click on "Actions" and select "Deploy API".
   - Create a new stage (e.g., `dev`).
   - Click "Deploy".

2. **Note the Invoke URL**:
   - Copy the Invoke URL from the stage dashboard. It will look something like `https://<api-id>.execute-api.<region>.amazonaws.com/dev`.

#### Step 4: Test the API

1. **Invoke the Endpoints**:
   - Access the product endpoint: `https://<api-id>.execute-api.<region>.amazonaws.com/dev/product`.
   - Access the customer endpoint: `https://<api-id>.execute-api.<region>.amazonaws.com/dev/customer`.

   You should receive mock product and customer details in the responses.

This setup will allow you to route requests with the `/product` pattern to the `ProductDetailsFunction` and requests with the `/customer` pattern to the `CustomerDetailsFunction`.
