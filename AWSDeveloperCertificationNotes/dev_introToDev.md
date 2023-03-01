# Introduction to Developing on AWS

## The Systems Development Life Cycle
* Develop
     * Code - Check in source code, peer-review new code
     * Build - Compile code, perform unit tests, gather code metrics, create container images
     * Test - Integration tests, load tests, UI test
* Deploy - Deploy to production environments
* Maintain - Monitor code in production to detect unusual activity

## Systems development life cycle
* Software development goes through a series of phases in the systems development lifecycle (SDLC). The SDLC is a conceptual model used in project management. It describes the stages in an information system development project, from an initial feasibility study to the maintenance of the completed application.
* In general, an SDLC methodology follows these steps: plan, define, design, develop, deploy and maintain. 
* The Developer cetification focuses on the Develop phase. In the Develop phase, the new system is developed. New components and programs must be obtained and installed. System users must be trained, and all aspects of the system’s performance must be tested. If necessary, bugs must be fixed and adjustments must be made to improve performance.

### SDLC Methodologies
* Waterfall (or traditional) methodology: This is often considered the classic approach to the SDLC. The waterfall model describes a sequential development method in which each development phase has distinct goals and tasks that must completed before the next phase can begin. Under this paradigm, product teams might not hear back from customers for months, and often not until the product is commercialized.
* Agile software development methodology: Agile is a new conceptual framework that supports fast-paced, iterative software development. Under this new paradigm, product teams push their work to customers as quickly as possible so that they can collect feedback and improve the previous iteration of their products. Concepts such as minimum viable product (MVP), release candidate, velocity, etc. are all derived from this new approach. There are a number of agile software developmentmethodologies, e.g., Crystal methods, Dynamic Systems Development Method (DSDM), and Scrum. Under agile, software is developed iteratively in short time periods called sprints, which typically last 1 –4 weeks.

### Five Phases of Software Development
* Code - developers write application source code and check changes into a source code repository, such as a Git repository or AWS CodeCommit. Many teams use code reviews to provide peer feedback of code quality before they ship code into production. Other teams use pair programming as a way to provide real-time peer feedback.
* Build - an application’s source code is compiled and the quality of the code is tested on the build machine. The most common type of quality check is an automated test that does not require a server in order to run. These quality tests can be initiated from a test harness. Some teams extend their quality tests to include code metrics and style checks.
* Test - additional tests are performed that cannot be done during the Build phase. These tests require the software to be deployed to a production-like environment. Often, these tests include integration testing with other live systems, load testing, user interface (UI) testing, and penetration testing. A common pattern is for engineers to deploy builds to a personal development stage where they can check that their automated tests work correctly. They then deploy to pre-production stages where their application interacts with other systems to ensure that the software works in an integrated environment.
* Deploy - Though there are different deployment strategies, the common goal is to reduce risk when deploying new changes and to minimize the impact if a bad change is released to production.
* Maintain - After code is deployed, it must be monitored in production to determine if everything works as expected.

## Steps to get started developing on AWS
* Set up an AWS account
* Set up AWS Permissions (IAM)
     * IAM is a web service that helps you securely control access to AWS resources for your users. You use IAM to control who can use your AWS resources (authentication) and what resources they can use and in what ways (authorization).IAM enables you tocreate and manage AWS usersand groups.With IAM, you can set up roles and policies to control access to AWS services. A role has policies that grant access to specific services and operations.IAM also enables identity federationbetween your corporate directory and AWS services. 
* AWS IDE Toolkits / Install dev environment
* Interact with AWS services with AWS SDKs and CLI

## IDE
* You'll need an IDE for the language that you'll be using
* Install the SDK for your IDE and language

### AWS Cloud9
* Cloud-based, web-based IDE you can use to develop for AWS and works with other AWS services
* Has some features of integration with AWS that make it easy to write for some services, like Lambda
* Integrates with CodeCommit which is AWS's code repository

## Interacting with AWS Services
Any time you are interacting with AWS services you are interacting via the API.  There are four ways to do this:
* Call the APIs directly
* Use the AWS Management Console
* Use the Command Line Interface
* Use the SDK

### Tools available for using the CLI
* AWS CLI tool - Windows, MacOS, Linux or Unix
* AWS Tools for Powershell - Windows, MacOS, Linux (comes installed with the .NET SDK)
* AWS Serverless Application Model (AWS SAM) Local - A CLI tool for developing serverless applications locally
* AWS Amplify - Mobile app development framework that helps integrate with front-end frameworks 

### Command Line Format
Example - $ aws ec2 stop-instances --instance-id i1234567890abcdef0
* Always starts with aws
* Then the service command (ec2, s3, etc...)
* Then the operation or sub-command (stop-instances)
* Then Parameters - information the command needs to run
* If you need to run a complex command with multiple parameters you can create a configuration file in json format
* aws help - command for general help
* aws ec2 help - specific help for using ec2 via CLI

### AWS Cloudshell
* AWS provided CLI access in the browser via the Management Console
* Pre-authenticated session (no keys needed)
* No cost
* Preinstall with AWS CLI, SDKs and other helpful tools

## Fundamentals of working with the SDK
 * Supports many languages. 
 * Mobile SDK for mobile frameworks
 * IoT Device SDK for developing IoT projects 

### Uses the Request / Response Model
Your Application -> AWS SDK (service client APIs and resource APIs) -> Request -> AWS Service Endpoint (URLs that's an entry point for a web service)
Response is returned from the endpoint back to the AWS SDK and then back to the client
The Response will have what you requested - database information, results of the function, etc...
* Uses the HTTP request service codes in the response

## AWS SDKs APIs
AWS SDKs have two levels of APIs
 * Service client API
     * One method per service operation
     * Objects for request and result data
     * Uses a "low level" client - allows you to control the behavior of your calls
 * Resource API
     * One class per conceptual resource
     * Defines service resources and individual resources
 * NOTE - Some services have resources that area associated with a specific region. When you access these services in your code you must specify a region so you'll be able to find your resource

## Handling Exceptions
 * AWS endpoints are designed to return error messages such as an HTTP 400 (client error) or 500 (server error) 
 * Different languages will have different built-in ways provided by the SDK that allow you to handle errors gracefully
     * Java, .NET and Xamarin - AmazonServiceException or AmazonClientException
     * Python - Botocore.exceptions.ClientError
     * JavaScript - Asynchronous callback function 

