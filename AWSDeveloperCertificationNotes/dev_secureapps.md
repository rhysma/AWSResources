## Developing Secure Applications on AWS

 Previously learned about two services that are core to AWS security:
 * With Amazon Virtual Private Cloud (Amazon VPC), you secure your networks and subnets and protect your AWS resources in the cloud.
 * With AWS Identity and Access Management (IAM), you control access to AWS resources through policies that grant permissions to users, groups, and roles.

 ### Securing Network Connections

 Transport Layer Security (TLS) and its predecessor Secure Sockets Layer (SSL) are open standards that use public and private certificates to establish the identity of websites over the internet and resources on private networks.
* TLS and SSL protocols encrypt network communications between connected resources
* HTTP connections might use either SSL or TLS (TLS is more secure)

Example with Elastic Load Balancing
* ELB terminates HTTPS and TLS traffic from clients at the load balancer
* The load balancer encrypts and decrypts the traffic
* Keeps the work of handing TLS termination off of the EC2 instance

CloudFront
* You can configure CloudFront to require viewers to use HTTPS so that connections are encrypted when CloudFront communicates with viewers
* You can configure CloudFront to use HTTPS with your origin so that connections are encrypted when CloudFront communicates with your origin
* CloudFront performs SSL/TLS negotiation between the viewer and CloudFront and between CloudFront and the origin if the response is not already cached

#### Certificate Authorities

A Certificate Authority (CA) issues certificates to specific domains. When a domain presents a certificate that a trusted CA issued, your browser or application knows it's safe to make the connection.

Steps between Clients and Servers
1. CA issues a certificate
2. Client requests identification
3. Server sends the certificate and public key
4. Client checks - is issuing CA trusted?
5. Client sends an encrypted session key
6. Acknowledgement encrypted with the session key
7. All data is now encrypted with the session key

#### Challenges with managing certificates
* Security - Certificates can be vulnerable to things such as name mismatch, use of internal names, missing or misconfigured fields/values, outdated or weak hashing algorithms, weak keys, weak cyber suites that compromise endpoints
* Discovery - It is not practical to manually gather details about all of the individual certificates in your network when you have hundreds or thousands of them
* Rotations and renewals - Manage management of certificate expirations is prone to error and could cause you to miss rotations and renewals
* Authorization - You need to be able to verify that someone is authorized to approve and issue a certificate
* Cost - It can be expensive to manage certificates. You must pay a fee to validate them. You must consider support costs, legal costs (insurance, warranties, etc...), ownership or control costs (fees for root embedding), and infrastructure costs

### Using AWS Certificate Manager (ACM)

With ACM you can provision, manage and deploy public and private SSL/TLS certificates for use with AWS service and your internal connected resources. ACM removes the time-consuming manual process to purchase, upload, and renew SSL/TLS certificates
* Public and private certificates that you provision through ACM for use with AWS services are free. You pay only for the AWS resources that you create to run your application.
* You can also produce your own certificate with AWS Certificate Manager Private Certificate Authority.

### Authenticated with AWS Security Token Service(STS)

Key concepts for access control
* Authentication - verify the user
* Authorization - Verify the user's permissions
* Identity provider (IdP) - Manages identity information and provides authentication services
* Identity broker - Authenticates credentials against an IdP and retrieves temporary security credentials from AWS STS
* Standards
    * Security Assertion Markup Language (SAML) - Open standard used to exchange authentication and authorization data between parties
    * OpenID Connect (OIDC) - Open standard that third-party IdPs use so that other companies/sites can use them to authenticate users without having to maintain an in-house user database
    * JSON Web Token (JWT) - Open standard used to securely transmit information between two parties

#### Why use temporary security credentials
* Bad practice - Embed access keys in unencrypted code and/or share access keys between users in an AWS account
* Best practice - Use IAM roles to retrieve temporary security credentials and if IAM roles are not an option, use AWS STS to retrieve credentials.

Why use temporary security credentials from STS:
* Provided trusted users to enable them to access your AWS resources
* Short-lived credentials that consist of an access key, ID, secret access key, and session token
* Limited in duration to a configurable lifetime
* Not reusable after they expire
* Generated dynamically

You can use the AWS Security Token Service(AWS STS) to provide trusted users with temporary security credentials to access your AWS resources. Temporary security credentials consist of a short-lived access key ID, secret access key, and session token.

#### AWS STS Trusted Users

AWS STS trusted users can be IAM users or federated identities:
* IAM Users - You can establish cross-account access for IAM users in one AWS account who need temporary access to AWS resources in another AWS account. 
* Federated identities - Federated identities are users who sign in to your application from an authentication system outside of AWS. IAM supports two types of identity federation:
    * Enterprise identity federation 
    * Web identity federation 

#### AWS STS API Operations
* AssumeRole - Returns a set of temporary security credentials for existing IAM users to grant cross-account access to AWS resources
* AssumeRoleWithSAML - Returns a set of temporary security credentials for federated users who are authenticated by an organization's existing identity system
* AssumeRoleWithWebIdentity - Returns a set of temporary security credentials for federated users who are authenticated through a public IdP such as Login with Amazon, Google, Facebook, etc...
* GetFederationToken - Returns a set of temporary security credentials for federated users. 
* GetSessionToken - Returns a set of temporary security credentials for existing IAM users. 

### Authenticating with Amazon Cognito
Cognito provides authentication, authorization, and user management for your web and mobile applications
* Authenticates user identities through external IdPs that support SAML, or OIDC, Social IdPs, and custom IdPs.
* Provides temporary security credentials to access AWS resources and services

User Pools
* Directory of users
* Provides sign-in for users
* Accepted federated identities from outside providers

User Pool features and functionality
* Sign-up and sign-in services
* built-in, customizable login web UI
* Control who can access your API
* Compromised credentials check
* Phone and email verification
* Adaptive authentication

To authenticate, a user answers successive challenges until authentication either fails or the user is issued tokens. With these two steps, which can be repeated to include different challenges, you can support any custom authentication flow.

You can customize your authentication flow with Lambda triggers. These triggers issue and verify their own challenges as part of the authentication flow. Challenges might include password verification, MFA enabled, CAPTCHA, or secret questions and answers.

Identity Pools (federated identities)
* Provide users with temporary access credentials
* Enable the creation of unique identities and federate them with various providers

You can use identity pools and user pools separately or together

When you sign in by using a user pool, regardless of where the identity lives (in the pool or coming from a federated third-party IdP), Amazon Cognito gives you three JWTs:
* ID
* Access
* Refresh

User Pool Tokens:
* Identity token - Authorizes API calls. Contains claims about the identity of the user (such as name and email)
* Access token - Authorizes API calls based on the custom scopes of specified access-protected resources
* Refresh token - Contains the information necessary to obtain a new ID or access token

ID and access tokens are signed, not encrypted. The refresh token is encrypted.

By design, tokens live for a relatively short time. You can choose how long your access and refresh tokens remain valid. You can configure access tokens to expire in as little as 5 minutes or as long as 24 hours. You can configure refresh tokens to expire in as little as 1 hour or as long as 10 years.

Amazon Cognito identity pools support the following IdPs:
* Amazon Cognito user pools
* Public IdPs, such as Login with Facebook, Google, or Amazon
* SAML IdPs
* OIDC IdPs
* Developer-provided authenticated identities


