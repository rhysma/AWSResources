# Securing Access to Cloud Resources

## The AWS Shared Responsibility Model
Security and Compliance - shared responsibility between AWS and the customer
AWS Responsibility - Security OF the cloud
Customer Responsibility - Security IN the Cloud

## AWS Identity and Access Management (IAM)
* A service you can use to configure fine-grained access control to AWS resources
* IAM is integrated into most AWS services
* Supports federation from corporate systems like Microsoft Active Directory and standards-based identity providers

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
* IAM policy - a document that explicitly lists permissions. The policy can be attached to an IAM user, group, or role. 

### IAM Credentials for Authentication
You must authenticate to any supported services from the AWS Management Console, AWS Command Line Interface (AWS CLI), and AWS software development kits (SDKs). To do so, you must provide AWS credentials. 

Two primary types of credentials are used for authentication. Which credential type you use depends on how you access AWS.
* To authenticate from the console, you must sign in with your username and password.
* To authenticate programmatically through the AWS CLI, SDKs, and application programming interfaces (APIs), you must provide an AWS access key. The AWS access key is the combination of an access key ID and a secret access key.

More Information - [AWS Security Credentials](https://docs.aws.amazon.com/general/latest/gr/aws-security-credentials.html)

### Multi-factor Authentication (MFA)
Multi-factor authentication (MFA) is a best practice that adds an extra layer of protection on top of your username and password. MFA requires two or more factors to achieve authentication. Factors include something you know, such as a password; something you have, such as a cryptographic token; or something you are, such as your fingerprint.

## Authorizing access to AWS services
You can use IAM to control access to your AWS resources by using IAM policies that grant or deny permissions.

By default, an authenticated IAM user, group, or role can't access anything in your account until you grant them permission. You grant permissions by creating a policy. An IAM policy is a JavaScript Object Notation (JSON) document. It defines the effect, actions, resources, and optional conditions under which an entity can invoke API operations to the AWS account. By default, any actions or resources that are not explicitly allowed are denied.

* Two types of IAM policies can grant permissions: identity-based policies and resource-based policies. The difference between the two types of policies is a result of where they are applied. 
    * Identity-based policies are attached to an IAM user, group, or role. They indicate what that identity can do. For example, you could grant a user the ability to access a DynamoDB table.
    * Resource-based policies are attached to a resource. They indicate what a specified user (or group of users) is permitted to do with it. For example, you can use resource-based policies to grant access to an S3 bucket or to grant cross-account access between two trusted AWS accounts.
    
More information -  [Identity-Based Policies and Resource-Based Policies](https://docs.aws.amazon.com/IAM/latest/UserGuide/access_policies_identity-vs-resource.html)

IAM policies can be managed or inline.
* Managed policies are standalone, identity-based policies that you can attach to multiple users, groups, and roles.
    * AWS-managed policies are created and managed by AWS.
    * Customer-managed policies are created and managed by you.
    * Managed policies provide several features, including reusability, central change management, versioning and rollback, and the ability to delegate permissions management to other users.
* Inline policies are embedded in a principal entity such as a user, group, or role. That is, the policy is an inherent part of the entity.
    * You can use the same policy for multiple entities, but those entities do not share the policy. Instead, each entity has its own copy of the policy, which makes it impossible to centrally manage inline policies.
    * Inline policies are useful when you want to maintain a strict one-to-one relationship between a policy and the principal entity to which it is applied.

When you grant permissions to users, groups, roles, and resources, follow the standard security advice of the principle of least privilege. This practice means that you grant only the permissions that are needed to perform a task. 
* It’s more secure to start with a minimum set of permissions and grant additional permissions as needed. It provides better security than starting with permissions that are too permissive and then trying to restrict them later. To define the correct set of permissions, you must do some research to determine what access is needed to accomplish a specific task.
