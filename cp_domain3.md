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
 * [Documentation](https://aws.amazon.com/s3/?nc2=type_a)
 * S3 - Simple Storage Service 
    * Object storage service that offers scalability, data availability, security, and performance
    * Object Storage - Allows you to store objects inside of buckets
    * Enables URL access for files
    * Offers configurable rules for your data lifecycle
    * Can serve as a static website host
    
 * S3 Storage Classes
    * General Purpose (non-archival storage classes)
       * S3 Standard - high availability, high durability, performance object storage for frequently accessed data.  Appropriate for a wide variety of use cases
       * S3 Intelligent-Tiering -  Will move your data to the correct storage class based on usage so if you're not sure which one to use, choose this and it will move the data to the most cost-optimized location. 
      * S3 Standard-IA (Infrequent Access) - This is for infrequently accessed data with the standard resilience. 
      * One Zone-IZ (Infrequent Access) - This is for infrequently accessed data that is only stored in one availability zone. Good for things like secondary backup copies of on-prem data or easily re-creatable data. Costs 20% less than Standard-IA.

 * Lifecycle Policies for S3
    * Objects in a bucket can transition or expire based on your criteria
    * Transtitions can enable objects to move to another storage class based on time
    * Expiration can delete objects based on age
    * Your policies can also factor in versions of a specific object in the bucket 
    

#### Glacier and Glacier Deep Archive
  * [Documentation](https://aws.amazon.com/s3/storage-classes/?nc=sn&loc=3)
  * Glacier is a secure, durable, low-cost storage option for data archiving. 
     * Has configurable retrieval times when you need to get files out of storage
     * Can send files directly from an S3 bucket or through lifecycle rules in S3
     * 90 day minimum storage duration change
     * Can be retrieved in minutes or hours
     * You pay a retrieval fee per GB
     * Over 5 times less expensive than Standard S3. 
     
  * Glacier Deep Archive
     * Low-cost storage class for long-term retention and digital preservation of data that may be accessed one or twice in a year. Best suited for customers in sectors that have long-term data storage compliance requirements (Financial services, health care, public sectors, etc...)
     * Can also be used for disaster recovery or backups
     * 180 day minimum storage duration change
     * Can be retrieved in hours
     * You pay a retrieval fee per GB
     * Over 23 times less expensive than Standard S3
   
#### Elastic Block Store (EBS)
 * [Documentation](https://aws.amazon.com/ebs)
 * EBS is a high-performance block storage designed for use with EC2.  Provides for both throughput and transaction intensive workloads at any scale. 
    * Redundancy within an Availability Zone
    * Allows you to take snapshots of its data
    * Offers encryption of its volumes
    
 * Multiple Volume Types
    * General Purpose SSD - Cost effective type designed for general workloads, standard/default 
    * Provisioned IOPS SSD - High performance volume for low latency appllications, best for intensive database or application workloads, data warehouse workloads, HBase, Vertica, Cassandra
    * Throughput Optimized HDD - Designed for frequetly accessed data, provides the lowest cost per GB of all EBS volumes with ongoing workloads
    * Cold HDD - Less frequently accessed workloads, the lowest cost option for all EBS.
    

#### Elastic File System (EFS)
 * [Documentation] (https://aws.amazon.com/efs/?nc2=type_a)
 * Fully managed NFS File system, designed for Linux workloads
 * Supports up to petabyte scale
 * Stores across multiple Availability Zones
 * Provides configurable lifecycle data rules
 
 * Two different storage classes
    * Standard - General/default option for file storage
    * Infrequent access - Cost-optimization for files accessed less frequently
    

#### AWS Snowball and Snowmobile 
 * [Documentation](https://aws.amazon.com/snowball/?nc2=type_a)
  * Snowball - A service to physically migrate petabyte scacle data to AWS
     * Block storage and S3 compatible 
     * 40 Virtual CPUs 
     * Suited for local storage and large-scale data transfer
     * Snowball Edge - Compute Optimized device that provides 52 Virtual CPUs, block and object storage, and option GPU
     
  * Snowmobile - Service to physically migrate exabyte scale data onto AWS
     * [Documentation](https://aws.amazon.com/snowmobile/?nc2=type_a)
     * Allows you to move extremely large amount of data to AWS
     * You can transfer up to 100PB per Snowmobile 
     * The Snowmobile is a 45-foot long, ruggedized shipping container pulled by a semi-truck

### Database Services

#### Relational Database Service (RDS)
 * [Documentation](https://aws.amazon.com/rds/)
 * Easy to set up and operate databases in the cloud. Doesn't require you to have a server, understand the underlying infrastructure.
 * Fully managed service - handles provisioning, patching, backups, recovery
 * Supports operations across multiple availability zones, allows for quick scaling. 
 * Two types of storage - General purpose SSDs and provisioned iOPS drives
 * Access to a lot of different database platforms - Amazon Aurora, PostgreSQL, MySQL, MariaDB, Oracle, Microsoft SQL
 
##### Amazon Aurora
* [Documentation](https://aws.amazon.com/rds/aurora/)
* Amazon's database engine available through RDS - built for the cloud
* MySQL and PostgreSQL compatible
* Performance and availability of commercial-grade databases at 1/10th the cost
   * 5 times faster than standard MySQL
   * 3 times faster than standard PostgreSQL
   
#### DynamoDB
* [Documementation](https://aws.amazon.com/dynamodb/)
* Fully managed like RDS but is a noSQL service
   * Multiregion
   * Multimaster
   * Durable
   * Built in security, backups, restore, in-memory caching
* Provides key/values and document database
* Delivers single-digit millisecond performance at any scale

#### Elasticache and Redshift 
* [Elasticache Documentation](https://aws.amazon.com/elasticache/)
* Fully managed, in-memory, data store. 
* Two different engines - Redis and Memcache

* [Redshift Documentation](https://aws.amazon.com/redshift/)
* Scalable data warehouse service
* Leverages high-performance disks, petabytes in scale
* Allows you to fully encrypt the contents of your data warehouse and gives you a level of isolation within your VPC
* Query petabyes of structured and semi-structured data across your data warehouse, using standard SQL

### App Integration Services
* [Documentation](https://aws.amazon.com/products/application-integration/)
* Suite of services that enable communications between decoupled components within microservices, distributed systems, and serverless applications.
  * No longer have to write custom code to enable interoperability between applications
  * Limits extra code that may be repeated in your microservices
  * Automatic scaling

#### AWS Messaging 
* Publish and subscribe to messaging for high throughput and reliable message delivery
* Amazon Simple Notification Service (SNS) and Simple Queue Service (SQS)
  * Message queue that sends, stores, and receives messages between applications
* Amazon MQ
  * Message broker - makes migration easy and enables hybrid architectures
  
### AWS Step Functions
* [Documentation](https://aws.amazon.com/step-functions/)
* Allows you to coordinate multiple AWS services into a serverless workflow
* Makes it simpler and more intuitive to stitch together different Amazon services 
* Support serverless architectures
* Supports complex workflows and error handling
* Charged per state transition along with the other services you're using
* Uses the Amazon States Language for defining Workflows


## Management and Governance

### AWS CloudTrail
* [Documentation](https://aws.amazon.com/cloudtrail/)
* Service that enables goverance, compliance, operation auditing, risk auditing and continuous monitoring.
* Gives you a history of everything that happens on your account. How services and resources are accessed. Simplifies security analysis, resource charge tracking, and troubleshooting. 
* Loging
   * Creates S3 bucket or CloudWatch Log
   * Logs events in the regions in which they occur
   * Meets many compliance requirements for infrastructure auditing
   * Best practice - should be enabled on every account
   
### Amazon CloudWatch
* [Documentation](https://aws.amazon.com/cloudwatch/)
* A monitoring and observability service - provides ddata and actionable insights to montior your applications
* Collects monitoring and operational data in the form of logs, metrics, and events
* Many uses - compliance requirements, forensic analysis, operational analysis, troubleshooting
* Enable alarms
* Custom dashboards based on collected metrics

### AWS Config
* [Documentation](https://aws.amazon.com/config/)
* A service that enables you to assess, audit, and evaluate the configurations of your resources. 
* Monitors and records your configuration to allow for quick changes and evaluation


### AWS System Manager
* [Documentation](https://aws.amazon.com/systems-manager/)
* Gives you visibility and control of your infrastructure on AWS
* Unified user interface so you can view operational data from multiple services and automate operational tasks
* Give a secure way to access servers using only AWS credentials
* Gives you a way to store commonly used parameters securely for operational use

### AWS CloudFormation
* [Documentation](https://aws.amazon.com/cloudformation/)
* A common language for you to model and provision AWS and third-party application resources in your cloud environment
* Allows you to provision infrastructure based on templates
* Templates can be YAML or JSON


### AWS Organiations and Control Tower
* [Organizations Documentation](https://aws.amazon.com/organizations/)
* Helps you centrally govern your environment as you grow and scale your workloads
* Gives you centralized billing, control access, compliance, and security
* Sharing resources across your AWS accounts

* [Control Tower Documentation](https://aws.amazon.com/controltower/)
* Provides setup and governance support for large accounts/orgs and teams
* Automate the setup of your AWS environment
* Provides recommended rules - called guardrails that help enforce policy
* Includes a dashboard to gain operational insights from a single view


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
   
 ### File Stoage Services Scenarios
 1. Business A - Launched a site that offers daily tutorials for developers. They use S3 to store the assets needed per tutorial. These assets are very popular within the week the tutorial is launched. After this initial week, these assets are rarely accessed.
    * How can Business A reduce their S3 costs while maintaining durability?
    * Answer - Setup S3 lifecycle rule that moves from Standard to Standard-IA storage
    
1. Business B - Is a social networking company and they are moving to AWS. They have 2PB of user-generated content that they need to migrate. They are trying to determine if there is a faster way to move the data than uploading over the Internet.
   * Would there be an approach you would recommend?
   * Answer - AWS Snowball
   
1. Business C - Is a company that produces a messaging app. They are looking for a shared file system between 8 different Linux EC2 instances. The file system would need to support roughly 1PB of data. 
   * What approach would you recommend? 
   * Answer - Elastic File System 
 
 ### Database Service Scenarios
 
 1. Business A - A financial services company who is transtioning their data warehouse to AWS for analysis. This data warehouse would need to support up to 2PB of data. 
    * What service would you recommend?
    * Answer - Amazon Redshift
    
 1. Business B - They are a tech company that needs to launch a MySQL database for a new web application. They need to have direct access to the virtual server that MySQ is running on.
    * What approach would you recommend?
    * Answer - EC2 server with MySQL installed
    
 1. Business C - They are a gaming company that is trying to determine how to store realtime user analytics. They need low latency and the ability to scale up to 1 million players. The company want to minimize the amount of time it takes to maintain the database. 
    * What approach would you recommend?
    * Answer - DynamoDB
 
 ### App Integration Services Scenarios
 1. Business A - A non-profile that assigns volunteers to opportunities. Recently their database server went down and users were unable to sign up. While the situation is now corrected, there is still some downtown expected in the future. The business wants to explore an AWS service that would prevent lost user signups
    * What service would you recommend?
    * Answer - Simple Queue Service (SQS)
    
    
 1. Business B - They are creating a list of onboarding steps for new customers for their app. These steps detail integrations with their CRM, emails to the user, and analytics. The business is worried about the time it will take to build all of this from scratch. 
   * Is there an AWS service that can help?
   * Answer - AWS Step Functions
   
1. Business C - They are an eCommerce company building a custom platform. They are adding new functionality and want to have aspects of the platform that listen for events like orders and refunds. They don't know yet all of the elements that would need to respond to events.
   * Is there a service that would allow current and future parts of the platform to listen for these events?
   * Answer - Simple Notification Service (SNS)
 
 
 ### Management and Governance Scenarios
  1. Business A - They are a financial services company that recently discovered that someone had disabled a security setting on a server. They are concerned that events like this might go unnoticed until a breach. 
     * Which service would allow the organization to continually track configuration and infrastructure?
     * Answer - AWS Config
     
 1. Business B - They are a learning SaaS company that will be launching a new application that includes several components. They are looking at ways to minimize manual work required when creating infrastructure. 
    * What service would enable them to automate their effort?
    * AWS CloudFormation
 
 1. Business C - They are a manufacturing company and they have a cloud server which is needed to support their business processes and it was deleted. They want to make sure they know who was responsible.
    * Which service could show the individual who deleted this specific server?
    * AWS CloudTrail 
    
 
 
 
 
 
 
 
 
 
 
 
 
 
   


   
   
   
   
