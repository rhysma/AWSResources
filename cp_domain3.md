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

### Amazon EC2
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

### AWS Elastic Beanstalk
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


   
   
   
   
