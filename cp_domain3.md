# Domain 3

* Domain 3: Technology
  * 3.1 Define methods of deploying and operating in the AWS Cloud
  * 3.2 Define the AWS global infrastructure
  * 3.3 Identify the core AWS services
  * 3.4 Identify resources for technology support

## Methods of Connecting to AWS

* Three different approaches to interacting with AWS
   * The console - where you log in and view all of the available services, get information on how to use them and tutorials - browser version or mobile application
   * AWS CLI (Command line interface) - Allows you to interact with AWS services through a command-line/terminal system on your computer
   * AWS SDK (Software development kit) - This would allow you to access the AWS resources inside of a custom application, support for multiple languages 
   
## Core Services

### Compute Services

#### Amazon EC2
* [Link to Amazon's documentation](https://aws.amazon.com/ec2/)
* Different types of instances based on need
   * General, Compute, Memory, Accelerated, and Storage optimized
   * Review the documentation to determine which type is best for your scenario
   * Pricing varies based on the type of instance and size of instance
* Instance Features
   * Burstable Performance - Allows you to choose a baseline level of CPU performance with the ability to burst above the baseline
   * Multiple Storage Options
      * Amazon EBS - durable, block-level storage volume, can use as primary storage or for database storage. These will persist independently from the running life of the instance. Works like a physical hard disk attached to the instance. 
      * Three different volume types on Amazon EBS
         * General Purpose (SSD) - default choice, SSD-backed suitable for a large range of uses including small to medium sized databases, development and test environments, boot volumes
         * Provisioned IOPS (SSD) - storage with consistent and low-latency performance, designed for I/O intensive operations such as large relational and NoSQL databases
         * Magnetic  - low cost per GB, ideal for workloads where data is accessed infrequently or applications were the lowest cost option is important. 

#### AWS Elastic Beanstalk
* [Link to Amazon's Documentation](https://aws.amazon.com/elasticbeanstalk/)
* Key Features
  * Automates the process of deploying and scaling your workloads on EC2 but you don't have to deal with the servers directly
  * Supports a specific set of technologies unlike EC2 which is about hardware and storage
  * Allows you to set up all types of applications using different languages or technologies and get it up and running on a server without having to think about the hardware considerations.
  * All of the considerations of monitoring, load balancing, provisioning, etc... are handled through EB
  * Has built-in Health monitoring for your application
* Different deployment options
  * Upload your code through the console
  * Connect through the Elastic Beanstalk CLI
  * Connector for Visual Studio
  * Connect for Eclipse 
  
#### AWS Lambda
* [Link to Amazon's Documentation](https://aws.amazon.com/lambda/)
* Key Features
   * You don't have to think about managing or provisioning servers
   * Only pay for compute time that your application consumes - you are charged based on the number of requets for your functions and the duration of time it takes for code to execute 
   * Can run code for virtually any type of application or backend service - zero administration
   * Choose to have 128 and 3000 megabytes allocated for your functions
   * Great for serving HTTP request via Amazon API Gateway, modificiation to objects in S3 buckets, tables updates to DynamoDB, Echo/Alexa Skills
* Benefits
  * Reduced maintenance requirements 
  * We don't have to worry about underlying servers and keep them up to date
  * Enables fault tolerance without having to think about it or build it in
  * Runs across multiple availability zones so no single point of failure can take down your application
  * Scales based on demand
  
### Content and Network Delivery Services

#### Amazon VPC and Direct Connect
 * [Documentation](https://aws.amazon.com/vpc/?nc2=type_a)
 * VPC - Virtual Private Cloud, a logically isolated section of the AWS cloud. This is where you can launch your EC2 servers. 
 * Virtual network that you can define and configure. 
 * Can support IPv6 and IPv4 addresses
    * Can configure address ranges, subnets, routetables, network gateways
    
 * [Documentation](https://aws.amazon.com/directconnect/?nc2=type_a) 
 * Direct Connect - Allows you to easily setup a connection between on-prem data centers and AWS
   * High speed connection between your resources so you don't have to go through the Internet

#### Route53
 * [Documentation](https://aws.amazon.com/route53/?nc2=type_a)
 * Amazon's DNS Service - Hosted amongst eight different locations in the global infrastructure
 * Highly available - Global routing, so you can send people to the server closest to their physical location 
 * Can configure to have a fail-over service so if one server is misconfigured or unavailable in the data center you can route traffic to another location so your up-time is not affected. 

#### Elastic Load Balancing
 * [Documentation](https://aws.amazon.com/elasticloadbalancing/)
 * Can distribute traffic across multiple targets - allows traffic to be routed between different servers based on the load to keep one server from being overwhelmed
 * By default - will work with two EC2 servers 
 * Supports across availability zones within a region
 
 * Three types of load balancers
   * Application Load Balancer - Best suited for load balancing of HTTP and HTTPs traffic used in web applications 
   * Network Load Balancer - Best suited for load balancing of TCP, UDP, and TLS traffic where extreme network connectivity performance is required. Capable of handling millions of requests per second while maintaining ultra-low latencies
   * Classic Load Balancer - Basic load balancing across multiple EC2 instances and operates at the request and connection level.

#### CloudFront and API Gateway
 * [Documentation](https://aws.amazon.com/cloudfront/?nc2=type_a)
 * Amazon's CDN - Content Delivery Network - Server that allows you to securely deliver data, videos, applications, and APIs to your customers with low-latency and high transfer speeds. 
    * Works in the 8 US infrastructure locations
    * CDN Servers around the world 
    * Supports static and dynamic content
    * Includes several advanced security features so you can protect your business from things like denial of service attacks. 
    
 * [Documentation](https://aws.amazon.com/api-gateway/?nc2=type_a)
 * API Gateway - Fully managed API management service - Makes it easy for developers to create, publish, maintain, monitor, and secure APIs at any scale. 
    * Support containerized and serverless workloads as well as web applications
    * Gives you monitoring and metrics on API calls so you understand how your APIs are being used and be able to troubleshoot problems
    
 
### File Storage Services

#### Amazon S3

#### Glacier and Glacier Deep Archive

#### Elastic Block Store

#### Elastic File System

#### AWS Snowball

### Database Services

#### Relational Database Service

#### DynamoDB

#### Elasticache and Redshift 

### App Integration Services

#### AWS Messaging 

#### AWS Step Functions

## Scenario Review Questions
### Computing Scenarios
 1. Business A - is in the process of moving multiple workloads to AWS one of those is an application that will be leveraged for at least five more years. This is a core business application that the company will be leveraging for the foreseeable future. However, they're looking to be as cost efficient as possible for this and they want ease of use. 
    * What computing options should be chosen for the application? 
    * Answer - EC2 purchase option, all upfront reserved for 3 years 
    
 1. Business B - They are looking to deploy a PHP Web Application to a Virtual Server. They do not have the experience managing EC2 instances on AWS. They need the ability to scale and they do think that the application will be popular after launch.
    * What is the best compute option for Business B based on this criteria?
    * Answer - AWS Elastic Beanstalk 
    
1. Business C - is transitioning to the cloud for its data processing workloads. These workloads happened daily and can start or stop without a problem so they're configured to handle that.  The workload will be leveraged for at least one year. 
   * What easy to purchase option would be the most cost efficient choice?
   * Answer - Spot Instances 
  
  ### Network and Content Delivery Scenarios
  1. Business A - Maintain two corporate data centers they want their data centers to work alongside AWS for specific workloads. They are wondering if there is a way to have a persistent connection to AWS
     * What service from AWS would you recommend?
     * Answer - AWS Direct Connect 
     
  1. Business B - Serves content through their site to users around the globe. They are looking to optimize performance to users around the world. They know they want to leverage a Content Delievry Network (CDN)
     * Which service would enable optimized performance globally for their content?
     * Answer - Amazon CloudFront
     
 1. Business C - They have an internal application that runs on an EC2 Server. Currently there is downtime as demand is greater than capacity for the sever. The company is trying to decide if they should use bigger servers or more servers.
    * Which scaling approach would you recommend and what services should they use?
    * Answer - Elastic Load Balancing, Horizontal Scaling method
   
   


   
   
   
   
