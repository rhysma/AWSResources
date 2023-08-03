## Cloud Migration Strategies
There are six common strategies that an organization can use to migrate its applications to the cloud
 * Rehosting
    * Also called Lift-and-Shift
    * Move legacy applications from on-prem to the cloud without changing core architecture, functionality, or performance
    * The goal is to migrate and scale quickly to meet a business use-case  
 * Replatforming
    * Also called Lift-and-Reshape
    * You might make a few cloud optimizations to achieve a tangible benefit
    * You're not changing the core architecture of the application 
 * Repurchasing
    * Also called Replace-Drop-and-Shop
    * Moving the application or product to a different product on AWS
 * Refactoring
    * Also called Rewriting/Decoupling applications
    * Re-imagining how the application is architected/developed and moving toward those cloud-native features
    * Typically there is a strong business need to add features, scale, performance, etc...That would be otherwise difficult to achieve in the existing environment
 * Retire
    * Deprecate applications that are no longer useful.  
 * Retain
    * Revisit or do nothing (for now) for applications that don't suit any of the above options


[More Info](https://aws.amazon.com/blogs/enterprise-strategy/6-strategies-for-migrating-applications-to-the-cloud/)

## Cloud Deployment Strategies
There are two deployment strategies for cloud applications

* All-In Cloud - When your cloud application is fully deployed in the cloud, and all parts run in the cloud
   * Cloud-based applications are either created in the cloud (cloud native)
   * Or they have been fully migrated to take advantage of the benefits of cloud computing 

* Hybrid - The deployment can connect infrastructure and applications in the cloud and in on-prem data centers. 
   * This kind of deployment enables an organization to extend and grow its infrastructure into the cloud by connecting cloud and internal systems
   * [The hybrid cloud](https://aws.amazon.com/hybrid/)

### Cloud Computing Deployment Models
There are three types of cloud computing deployment models depending on the level of abstraction you want
* Virtual Machines - "I want to configure the servers, storage, networking, and OS for my applications" (EC2)
* Containers - "I want to run my application and its dependencies in resource-isolated processes" (Elastic Container)
* Serverless - "I don't want to manager servers, I just want to upload my code and have it run as needed" (Lambda)

















