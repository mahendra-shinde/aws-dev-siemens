# IAM Roles for Elastic BeanStalk

> This is a `One time activity` for creating any number of BeanStalk instances in any region!

## Role for BeanStalk 

1.  Goto "IAM" Console (Search for IAM from Console home)
1.  Click on "Roles" (Left side navbar) and then Click "Create Role" button.
1.  In first stage :  
    
    ```ini
    Trusted-Entity-type= AWS Service
    Choose-Service= Elastic BeanStalk
    Use-Case= Elastic BeanStalk - Customizable
    ```

    Click NEXT		

1.  In second stage:
    
    There should be TWO policies listed

    Click Next

1.  In third stage:

    ```ini
    Role-name = elastic-beanstalk-role
    ```

    Click `Create Role`

## Role for EC2 instance (EC2 Instance profile)

1.  From IAM Console, click on `Create Role`

1.  In first stage:

    ```ini
    Trusted-Entity-type= AWS Service
    Choose-Service= EC2
    Use-Case= EC2 (First Option)
    ```

    Click Next 

1.  In second stage:
 
    ```ini
    Choose-Policy=AWSElasticBeanStalkWebTier
    ```

    click Next

1.  In third stage:

    ```ini
    Enter-role-name = ec2-for-beanstalk
    ```

    Click "Create Role"
