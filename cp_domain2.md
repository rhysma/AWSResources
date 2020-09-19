# Domain 2

* Domain 2: Security and Compliance
  * [2.1 Define the AWS shared responsibility model](https://github.com/rhysma/AWSResources/blob/master/cp_domain2.md#global-infrastructure---regions-and-availability-zones)
  * [2.2 Define AWS Cloud security and compliance concepts](https://github.com/rhysma/AWSResources/blob/master/cp_domain2.md#aws-cloud-security-and-compliance)
  * 2.3 Identify AWS access management capabilities
  * 2.4 Identify resources for security support
  * [Domain 2 Study Questions and Review ](https://github.com/rhysma/AWSResources/blob/master/cp_domain2.md#domain-2-cloud-computing-scenarios)

### Domain 2: Security and Compliance

#### Global Infrastructure - Regions and Availability Zones
* AWS Regions - Each region is a specific geographic location. Each geographic location has a cluster of data centers that work together. At this time, there are 24.
   * Some of these are public and some are not available to the public
   * There have been 5 additional planned regions
   
* Availability Zones - Consists of one or more data centers. Usually two zones within each region at minimum.
   * 76 around the world
   * Has redundant power, networking, connectivity
   * AWS tries to ensure there are no single points of failure when it comes to global infrastructure
   * If something happend at one location, another one would be able to take over it's duties
   * Currently there are 69 availability zones 
   * Availability zones exist to provide ongoing and overlapping infrastructure support
   
 * High Availability - If you deploy your applications and experiences in the cloud, across multiple avaiilability zones within an AWS Region, then you minimize any single point of failure and ensure constant uptime. 
 
 * Naming Convention for Availability Zones
    * us-east-2a - means that US for United States, East for the eastern geographic region, the given number determines which data center cluster, the letter designates the availability zone.
    
* Edge Locations - Part of the global content delivery network (CDN), specificaly for CloudFront and Route 53
   * Currently 200 different locations that are edge locations
   * Allows users to get content from the fastest and best location for them
   

#### Cloud Economics 

* Capitalized Expenditure (CapEx) - When you spend money to buy large and expensive equipment for your business to directly support your company or mission. 
* Fixed Assets - The equipment purchased through a CapEx
* Operating Expenditures (OpEx) - The regular day-to-day expenses of your business. Could be things like connectivity costs, utilities, or maintenance. 

##### Tools for Cost Management

* AWS Cost Explorer
  * Allows you to view and explore your AWS costs, provides breakdowns by service, shows current usage costs and makes monthly projections, gives recommendations for cost optimization. 
  * Resource Tags - Metadata that we can attach to our specific AWS resources, if you have multiple departments or purposes for usage in an organization, tags allows you to keep those organized. Tags contain a name and an optional value. Once tags have been created, you can use tags within Cost Explorer to get specific usage based on those groupings. 
* AWS Budgets 
   * Budgets allows you to use the data and visualizations from Cost Explorer to plan and track your usage across all Services. Set budgets for the the amount you want to spend on a particular service, or for all services. 
* TCO Calculator
   * A projection tool for organizations that are considering moving a workload from their own data center to the cloud. Helps you see what your costs would be with AWS services and make a case for moving to the cloud as well as plan costs. TCO stands for Total Cost of Ownership
* AWS Pricing Calculator
   * Allows you to project costs for specific services or workloads in the cloud. 

#### AWS Cloud Security and Compliance 

* [AWS Acceptable Use Policy](https://aws.amazon.com/aup/)
* [AWS Shared Responsibiliy Model](https://aws.amazon.com/compliance/shared-responsibility-model/)

##### Shared Responsibility Model of Security
* Security and compliance is a shared responsibility between AWS and the customer. We have to have a good level of understanding of what is the responsibility of AWS and what is our responsibility to the customer. 

* AWS has the responsibility for the security of the cloud 
   * Core systems that are running the entire platform
   * Access control and training for their employees
   * The underlying network in the data center
   * Making sure all data centers and availability zones maintain connectivity
   * Responsible for the hardware that allows for global infrastructure - switches, servers
   * Configuration management - determining how bits of data get from one location to another
   * Patching of the cloud infrastructure and services
   
* The customer is responsible for the security in the cloud
   * Control over the things they are putting onto the platform and how they're using it
   * Individual access to cloud resources and training
   * Making sure that we have set the right level of permission to the people in our organization that need access to services
   * Data security and encryption - make sure we're following best practices for in-transit data and data at rest
   * The proper configuration of operating systems, networks, and firewall configuration
   * Software applications and code that is installed onto servers or onto services in the cloud
   
#### AWS Well-Architected Framework
* A collection of best practices created over time for AWS cloud architecture 
* [Link](https://aws.amazon.com/architecture/well-architected/)
* Focuses on the five key pillars that help you know how to best create systems that drive business value.
   * Framework, operational excellence, security, reliability, performance efficiency, and cost optimization
   
   
#### High Availability and Fault Tolerance
* Fault tolerance - we're going to be able to support the failure of components within your architecture
* High availability - keep your entire solution up and running in its expected manner despite any issues that may occur


#### Compliance
* Following the rules and standards set out in an agreement about how you will access, use, transfer, or store information
* There are many difference compliance standards you may have to review and follow depending on your business or industry
   * There are tools on AWS to help you know how to navigate these compliance standards

* [AWS Config](https://aws.amazon.com/config/#:~:text=AWS%20Config%20is%20a%20service,recorded%20configurations%20against%20desired%20configurations.) - Contains some conformance packs that are available to help you with compliance 
* [AWS Artifact](https://aws.amazon.com/artifact/) - Provides self-service access to AWS compliance reports 
* [AWS GuardDuty](https://aws.amazon.com/guardduty/) - Provides intelligent threat detection to help monitor and detect if there are scenarios that are happening which are unusual 

   
#### Domain 2 Cloud Computing Scenarios

1. Three primary elements of AWS Global Infrastructure are:
   1. AWS Regions
   1. AWS Availability Zones
   1. AWS Edge Locations
  
1. What represents a cluster of data centers in a specific geographic location?
   1. AWS Region
 
1. What consists of one or more data centers?
   1. Availability Zone
  
1. The acronyn CDN stands for? 
   1. Content Delivery Network
  
1. What are the two services utilized in Edge Locations?
   1. Amazon CloudFront
   1. Amazon Route 53
  
1. What is the primary purpose of an AWS Edge Location?
   1. Serve content where it is closet to the end users
   
1. Which of the Pillars of the Well-architected Framework involves the running and monitoring of systems for business value?
   1. Operational Excellence

1. Which of the Pillars of the Well-architected Framework involves protecting information and business assets
   1. Security
   
1. Which of the Pillars of the Well-architected Framework involves enabling infrastructure to recover from disruptions?
   1. Reliability
   
1. Which of the Pillars of the Well-architected Framework involves using resources efficiently to achieve business value?
   1. Performance Efficiency

1. Which of the Pillars of the Well-architected Framework involves achieving minimal costs for the desired value?
   1. Cost optimization

* Scenario 1
   * Company A is looking to transition to AWS. They are going to start with a few workloads and then move other workloads to the platform later. Right now, it's a requirement that they store their backup data in multiple geographic areas. 
   * Which element of the AWS Global Infrastructure will best suit this company?
      * Answer - AWS Regions
   
* Scenario 2
   * Company B services content through their site to users all around the globe and they're looking to optimize performance to their users. Now they want to leverage a content delivery network because they've heard that if they can get their content on servers that are closest to their users, this will improve performance. 
   * Which element of the AWS Global Infrastructure will best suit this company?
      * AWS Edge Locations 
   
* Scenario 3
   * Company C is transition out of their legacy applications to AWS and for this specific application, they require an uptime of at least 99.5%. They want to be sure that a single data center outage won't cause disruption for their highly available application. 
   * Which element of the AWS Global Infrastructure will best suit this company?
      * AWS Availability Zones
      
* Scenario 4
   * Company A which has multiple departments that work within AWS and finance wants a clean separation of costs between those different departments.  Currently, all of their resources are included within a single AWS account. 
   * What approach would meet this need for understanding future costs, with minimal effort?
      * If you didn't want to move a bunch of resources around, you could use Tags
   
* Scenario 5
   * Company B is considering a transition to the cloud, they currently have two physical data center that they own and maintain.  Now the stakeholders are really questioning whether or not this approach to transitiong to the cloud will save them money. 
   * What approach should be taken to make a case for the cloud and what resources would be used to make that case?
      * Use TCO Calculator or the new Pricing Calculator to create a report that shows all resources and their AWS costs
   
* Scenario 6
  * Company C has a web developer who was given some recent downtime to review moving their site to the cloud because currently they're using their own data center.  Finance is asking for estimate of costs for this transition to AWS. They want to understand how much it would cost per month to run this in the cloud.
  * What approach should be taken to this data to the finance team? 
     * Use the Pricing Calculator to create a report that shows all resources and their AWS costs
        
* Scenario 7
   * Company A is building an application to process credit cards. They will be processing cards directly and not through a service. Their bank needs a PCI DSS compliance report from AWS.  
   * Where would they go to get this information?
      * AWS Artifact 

* Scenario 8
   * Company B is considering a transition to the cloud and they store personal information securely in their system. The CTO has asked what is the company's responsibility for security of this data? 
   * What would you tell the CTO?
      * You would want to review any compliance rules for your industry/business reguarding personal information storage.  You would review the AWS Shared Responsibility Model.
      
* Scenario 9
   * Company C building a new tool for digital asset management and they are curious how to best leverage the capabilities of AWS in their application.  
   * What resources would you recommend to them?
      * Review the AWS Well Architected Framework
   
   
   
   
   
   
   
   
   
   
     
