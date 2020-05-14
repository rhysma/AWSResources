# Domain 2

* Domain 2: Security and Compliance
  * [2.1 Define the AWS shared responsibility model](https://github.com/rhysma/AWSResources/blob/master/cloudpractitioner.md#global-infrastructure---regions-and-availability-zones)
  * 2.2 Define AWS Cloud security and compliance concepts
  * 2.3 Identify AWS access management capabilities
  * 2.4 Identify resources for security support
  * [Domain 2 Study Questions and Review ](https://github.com/rhysma/AWSResources/blob/master/cloudpractitioner.md#domain-2-cloud-computing-scenarios)

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
  * Resource Tags - Metadata that we can attach to our specific AWS resources, if you have multiple departments or purposes for useage in an organization, tags allows you to keep those organized. Tags contain a name and an optional value. Once tags have been created, you can use tags within Cost Explorer to get specific usage based on those groupings. 
* AWS Budgets 
   * Budgets allows you to use the data and visualizations from Cost Explorer to plan and track your usage across all Services. Set budgets for the the amount you want to spend on a particular service, or for all services. 
* TCO Calculator
   * A projection tool for organizations that are considering moving a workload from their own data center to the cloud. Helps you see what your costs would be with AWS services and make a case for moving to the cloud as well as plan costs. TCO stands for Total Cost of Ownership
* AWS Pricing Calculator
   * Allows you to project costs for specific services or workloads in the cloud. 


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
     
