# Steps to create Elastic Beanstalk

## Pre-requisites

You must have created TWO roles. Refer to [this](./iam-role-for-beanstalk.md) document to create these two roles.

1. elastic-beanstalk-role
1. ec2-for-beanstalk

## The process

1.  In the AWS Management Console, type "Elastic Beanstalk" in the search bar and select the service from the results.

1.  Goto `Environment` (From left sidebar) and click `Create Environemnt`
1.  In first stage:

    ```ini
    [Configure Environment]
    Environment-tier=Web Server environment

    [Application Information]
    Application-name=myapp102
    Domain=myapp102
    Use-Check-Availability-button= Check if domain is available!

    [Platform]
    Platform-type= Managed platform
    Platform= PHP
    Platform-branch=PHP 8.3

    [Application Code]
    Use `Sample Application`

    [Preset]
    Configuration-preset= Single Instance (free tier eligible)
    ```

    Click `Next`

1.  In second stage

    ```ini
    Service-Role=elastic-beanstalk-role
    EC2-Key-pair=Any existing key-pair
    EC2-instance-profile=ec2-for-beanstalk
    ```

    Click `Next`

1.  in Third stage:

    ```ini
    [VPC]
    VPC=Choose any existing VPC

    [Instance Settings]
    Public-IP-address= NO (Uncheck Activated)
    Instance-Subnets=Choose all
    ```

    Click `Next`

1.  in Forth stage:

    ```ini
    RootVolumeType=gp3
    BlockDeviceMapping=gp3
    Disable IMDSv1=trueF
    ```
    Click `Next` (Skip this step)

1.  In Fifth Stage:

    ```ini
    [Monitoring / Health Reporting]
    System=Basic
    Managed-Platform-Updates=Uncheck ( Do not activate )
    ```

    Click `Next`

1.   In FINAL stage:

    Verify all the settings for all previous stages, click EDIT if any changes are required.

    Click `Submit`

## Wait for 3-5 minutes for instance status to be `Green`


