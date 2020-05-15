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

#### Route53

#### Elastic Load Balancing

#### CloudFront and API Gateway

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

  
   
   


   
   
   
   
