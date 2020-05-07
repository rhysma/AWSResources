# AWS Exam Study Resources
Notes and resources for studying for the AWS Certified Cloud Practitioner Exam

## Links and Resources
* [Main Amazon Page - Cloud Practitioner](https://aws.amazon.com/certification/certified-cloud-practitioner/)
* [Free Code Camp](https://www.freecodecamp.org/news/awscertified-challenge-free-path-aws-cloud-certifications/)
   * [Free Code Camp Video Course](https://www.youtube.com/watch?v=3hLmDS179YE)
* [PluralSight](https://app.pluralsight.com/paths/certificate/aws-certified-cloud-practitioner)
* [AWS Regions](https://aws.amazon.com/about-aws/global-infrastructure/regions_az/)
* [Global Infrastructure Visualization](https://www.infrastructure.aws/)

## Whats on the Exam?
* [Domain 1: Cloud Concepts](https://github.com/rhysma/AWSResources/blob/master/cloudpractitioner.md#domain-1-cloud-concepts)
  * [1.1 Define the AWS Cloud and its value proposition]((https://github.com/rhysma/AWSResources/blob/master/cloudpractitioner.md#domain-1-cloud-concepts))
  * [1.2 Identify aspects of AWS Cloud economics](https://github.com/rhysma/AWSResources/blob/master/cloudpractitioner.md#benfits-of-cloud-computing)
  * [1.3 List the different cloud architecture design principles](https://github.com/rhysma/AWSResources/blob/master/cloudpractitioner.md#types-of-cloud-computing)
  * [Domain 1 Study Questions and Review](https://github.com/rhysma/AWSResources/blob/master/cloudpractitioner.md#domain-1-study-questions)
* Domain 2: Security and Compliance
  * 2.1 Define the AWS shared responsibility model
  * 2.2 Define AWS Cloud security and compliance concepts
  * 2.3 Identify AWS access management capabilities
  * 2.4 Identify resources for security support
* Domain 3: Technology
  * 3.1 Define methods of deploying and operating in the AWS Cloud
  * 3.2 Define the AWS global infrastructure
  * 3.3 Identify the core AWS services
  * 3.4 Identify resources for technology support
* Domain 4: Billing and Pricing
  * 4.1 Compare and contrast the various pricing models for AWS
  * 4.2 Recognize the various account structures in relation to AWS billing and pricing
  * 4.3 Identify resources available for billing support

### Domain 1: Cloud Concepts
* Define the AWS Cloud and its value proposition

Traditional datacenters, inside of an organization are expensive - they contain equipment (servers, switches, hardware, etc...) plus the people to manage and maintain it. If you want to expand into a new area or a new geographic region, you're going to have to financial support a new set of equipment and a new datacenter at that location. Obtaining funding through investors or traditional banking requires time. Building things also takes a lot of time. Then once you have the funding to purchase the equipment and have built it, you have to hire people in the new location to manage and maintain it. To continue expanding your business around the globe you would have to continue this process.

You're also adding to your own technical debt. You have to plan financially to not only support future growth of your datacenters but you have to plan for upgrades and replacement of older tech as your datacenter ages.

Forecasting demand is also challenging - we need to understand what are we using now (what kind of capacity do we need) and what are we going to be using in the future (as our business grows). Businesses struggle with knowing how many users they will need to support in the future, how their internal business needs might change and how their market might fluctuate over time. 

When we're looking at traditional data centers, it takes an intial (large) up-front investment to get it up and running. Then there is a time commitment involved for funding and building. As well as the committment to people and technical debt.

Compliance burden - With every new datacenter you bring online, you have to have people who are experienced in security and data auditing to ensure that you are keeping your data safe and that it is held within the guidelines of your business expectations/legal requirements.

#### Benfits of Cloud Computing
1. Key Advantages
   1. Trade capital expense for variable expense - We don't have a large investment of equipment initially like we would in a datacenter. In this case, you would get variable expenses based on usage. You don't have to pay for the equipment or installation, etc...you only pay for the time you're using or accessing the equipment. 
   1. Economies of scale - AWS purchases equipment at a much lower cost due to the volume and quantity they are purchasing from manufacturers. This means that they can buy things much cheaper than your business. Amazon is going to be sure to get the best price for their equipment in a way you cannot. Amazon has the capacity to manage all of the servers at scale and that cost savings gets passed down to the consumer (that's you!). 
   1. Capacity - Your business no longer has to worry about forecasting capacity. System and server demand in the cloud can either grow or shrink based on your needs. If your business is growing and needs more capacity it is easy to bring up more servers or equipment to support that. If your business is in a slump, you can scale-back your usage to ensure cost savings at that critical time for your business.
   1. Increased speed and agility - Obtaining funds for a traditional capital purchase such a datacenter or equipment you might need, can be very slow. If your business is growing very quickly you want to be able to support additional users or demand on your services at that time without waiting for traditional methods. This allows your business to compete better in your market. Additionally, what if you want to test a new market or a hypothesis about your users, traditional methods may not allow you to do that quickly. 
   1. Elasticity - You can aquire resources when you need them and release them when you no longer need them. In the cloud, you want to be able to expand and contract your resources on demand, automatically. AWS has several services available to do this. 
   1. Reliability - The AWS global infrastructure is built with reliability in mind and you take advantage of it by default. 


#### Types of Cloud Computing
  * What is cloud computing? - AWS says that cloud computing is the on-demand delivery of compute power, database storage, applications, and other IT resources through a cloud services platform via the Internet with pay-as-you-go pricing, and that pricing model is critical to business success. 
  
##### The Cloud Spectrum
* Full Control Datacenter ---- Infrastructure as a Service (IaaS) ---- Platform as a Service (PaaS) ---- Software as a Service (Saas)

* Infrastructure as a Service 
  * Servers in the cloud (virtual servers)  - We have full access to these server
  * You have to perform your own maintenance

* Platform as a Service
  * We're given a service that is configured for us and we can deploy our customizations (Wordpress host)

* Software as a Service
  * Software you use or run as part of your business
  * Don't have to worry about servers or configuration, it's just provided as a service

##### Cloud Deployment Models
  * Public "the cloud" - Cloud resources that are available publically for a fee, anyone can sign up and then set up these resources for public consumption.
  * Private "on prem" - Cloud-like platform in a private datacenter. Scalable like AWS but in your own datacenter. 
  * Hybrid - You're leveraging the public cloud but the public cloud applications work in tandem with a private cloud within their own datacenter. 
  

#### Domain 1 Study Questions

1. Traditional data centers present challenges for organizations (5 things)?
   1. large up-front investment
   1. forecast demand is difficult
   1. slow to deploy to new data centers and servers
   1. maintenance is expensive
   1. you have all of the security and compliance burden
  
1. AWS lists six key advantages of cloud computing:
   1. Trade capital expense for variable expense
   1. Benefit from massive economies of scale
   1. Stop guessing capacity needs
   1. Increased speed and agility
   1. Stop spending money maintaining data centers
   1. Go global in minutes
  
1. (blank) is the ability to aquire resources as you need them and release resources when you no long need them. In the cloud, you want to do this automatically.
   1. Elasticity
  
1. What is the definition of Cloud Computing provided by AWS?
   1. AWS says that cloud computing is the on-demand delivery of compute power, database storage, applications, and other IT resources through a cloud services platform via the Internet with pay-as-you-go pricing.
  
1. Which model allows for the deployment onto a public cloud provider such as AWS, Azure, or Google Cloud?
   1. Public Cloud

1. Which model allows for the deployment in a private data center using a cloud-like platform provided by a vendor?
   1. On-Premises (private cloud)
 
1. Which model allows for the deployment of a mixed environment of the previous two options using both a provided cloud alongside a cloud-like platform in a private datacenter?
   1. Hybrid model
  
  #### Cloud Computing Scenarios
* Scenario 1
   * Company A - Runs several production workloads within its datacenter. They use VMware to manage the infrastructure in the datacenter. They want to use AWS and integrate it in with their some of their datacenter workload (using the two in tandem). 
   * Which cloud deployment model would this company be following? 
      * Hybrid Cloud
 
* Scenario 2
   * Company B - They are trying to decice whether to fund a new line of business and look at ways to monetize a new emerging technology. The new line of business will require some new infrastructure, beyond what they currently have. 
   * What benefit of cloud computing would be most relevant to Company B?
      * Pay as you go 
  
* Scenario 3
   * Company C - They have a new CTO at their insurance company. This is a medium-sized business.  They are considering moving to the cloud instead of colocating servers (which means they are renting space in another datacenter). They want to make sure they have the maximum control of their cloud servers and they want to that for security and compliance reasons. 
   * In this case, what cloud computing model would they need to leverage? 
      * Infrastructure as a Service (Iaas)



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
   

    
    
    
    
    
    






