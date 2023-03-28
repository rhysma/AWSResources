# Securing Access to Cloud Resources

## The AWS Shared Responsibiliy Model
Security and Compliance - shared responsibility between AWS and the customer
AWS Responsibility - Security OF the cloud
Customer Responsibility - Security IN the cloud

## AWS Identity and Access Management (IAM)
* A service you can use to configure fine-grained access control to AWS resources
* IAM is integrated into most AWS services
* Supports federation from corporate systems like Microsoft Active Director and standards-based identity providers

### Authentication
* Control who is requesting access to the AWS account and resources
* It is important to establish the identity of the requester through credentials
* The requester could be a person or an application. IAM calls these principals

### Authorization
* Assuming the requester has been authenticated - what should they be allowed to do?
* IAM checks for policies that are relevant to the request to determine whether to allow or deny the request

### IAM Components
* IAM user - an entity that you create in AWS to represent a person or application, given a permanent set of credentials
* IAM group - a collection of IAM users. You can use groups to grant the same permission to multiple users
* IAM role - Similar to a user, can be used to attach permission policies. 
* IAM policy - a document that explicity lists permissions. The policy can be attached to an IAM user, group or role. 

### IAM Credentials for Authentication
You must authenticate to any supported services from the AWS Management Console, AWS Command Line Interface (AWS CLI), and AWS software development kits (SDKs). To do so, you must provide AWS credentials. 

Two primary types of credentials are used for authentication. Which credential type you use depends on how you access AWS.
* To authenticate from the console, you must sign in with your user name and password.
* To authenticate programmatically through the AWS CLI, SDKs, and application programming interfaces (APIs), you must provide an AWS access key. The AWS access key is the combination of an access key ID and a secret access key.

More Information - [AWS Security Credentials](https://docs.aws.amazon.com/general/latest/gr/aws-security-credentials.html)

### Multi-factor Authentication (MFA)
Multi-factor authentication (MFA) is a best practice that adds an extra layer of protection on top of your user name and password. MFA requires two or more factors to achieve authentication. Factors include something you know, such as a password; something you have, such as a cryptographic token; or something you are, such as your fingerprint.

## Authorizing access to AWS services

