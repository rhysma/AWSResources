# Well-Architected Framework Design Principles

## Operational Excellence
  * Focus: Run and monitor systems to deliver business value, and to continually improve supporting processes and procedures.
  
  * Key topics:
     * Automating changes
     * Responding to events
     * Defining standards to manage daily operations

  * Design principles:
     * Perform operations as code - Define your entire workload (that is, applications and infrastructure) as code and update it with code. Implement operations procedures as code and configure them to automatically trigger in response to events. By performing operations as code, you limit human error and enable consistent responses to events.
     * Make frequent, small, reversible changes - Design workloads to enable components to be updated regularly. Make changes in small increments that can be reversed if they fail (without affecting customers when possible).
     * Refine operations procedures frequently - Look for opportunities to improve operations procedures. Evolve your procedures appropriately as your workloads evolve. Set up regular game days to review all procedures, validate their effectiveness, and ensure that teams are familiar with them.
     * Anticipate failure - Identify potential sources of failure so that they can be removed or mitigated. Test failure scenarios and validate your understanding of their impact. Test your response procedures to ensure that they are effective and that teams know how to run them. Set up regular game days to test workloads and team responses to simulated events.
     * Learn from all operational events and failures - Drive improvement through lessons learned from all operational events and failures. Share what is learned across teams and through the entire organization

  * Best practice areas:
     * Organization
     * Prepare
     * Operate
     * Evolve

Operations teams must understand business and customer needs so they can effectively and efficiently support business outcomes. Operations teams create and use procedures to respond to operational events and validate the effectiveness of procedures to support business needs. Operations teams collect metrics that are used to measure the achievement of desired business outcomes. As business context, business priorities, and customer needs, change over time, it’s important to design operations that evolve in response to change and to incorporate lessons learned through their performance.

[Operational Excellence Pillar Whitepaper](https://d1.awsstatic.com/whitepapers/architecture/AWS-Operational-Excellence-Pillar.pdf)

## Security

   * Focus: Protect information, systems, and assets while delivering business value through risk assessments and mitigation strategies

   * Key topics:
      * Protecting confidentiality and integrity of data
      * Identifying and managing who can do what
      * Protecting systems
      * Establishing controls to detect security events

   * Design principles:
      * Implement a strong identity foundation–Implement the principle of least privilege and enforce separation of duties with appropriate authorization for each interaction with your AWS resources. Centralize privilege management and reduce or even eliminate reliance on long-term credentials.
      * Enable traceability–Monitor, alert, and audit actions and changes to your environment in real time. Integrate logs and metrics with systems to automatically respond and take action.
      * Apply security at all layers–Apply defenseindepth and apply security controls to all layers of your architecture (forexample,edge network, virtual private cloud, subnet, and load balancer; and every instance, operating system, and application).
      * Automate security best practices–Automate security mechanisms to improve your ability to securely scale more rapidly and cost effectively. Create secure architectures and implement controls that are defined and managed as code in version-controlled templates.
      * Protect data in transit and at rest–Classify your data into sensitivity levels and use mechanisms such as encryption, tokenization, and access control where appropriate.
      * Keep people away from data–To reduce the risk of loss or modification of sensitive data due to human error, create mechanisms and tools to reduce or eliminate the need for direct access or manual processing of data.
      * Prepare for security events–Have an incident management process that aligns with organizational requirements. Run incident response simulations and use tools with automation to increase your speed of detection, investigation, and recovery.

   * Best practice areas:
      * Security
      * Identity and access management
      * Detection
      * Infrastructure protection
      * Data protection
      * Incident response 

Before you architect any system, you must put security practices in place. You must be able to control who can do what. In addition, you must be able to identify security incidents, protect your systems and services, and maintain the confidentiality and integrity of data through data protection. You should have a well-defined and practiced process for responding to security incidents. These tools and techniques are important because they support objectives such as preventing financial loss or complying with regulatory obligations.

[Security Pillar Whitepaper](https://d1.awsstatic.com/whitepapers/architecture/AWS-Security-Pillar.pdf)

## Reliability
   * Focus: Ensure a workload performs its intended function correctly and consistently when it's expected to.

   * Key topics:
      * Designing distributed systems
      * Recovering planning
      * Handling change

   * Design principles:
      * Automatically recover from failure - Monitor systems for key performance indicators and configure your systems to trigger an automated recovery when a threshold is breached. This practice enables automatic notification and failure-tracking, and for automated recovery processes that work around or repair the failure.
      * Test recovery procedures - Test how your systems fail and validate your recovery procedures. Use automation to simulate different failures or to recreate scenarios that led to failures before. This practice can expose failure pathways that you can test and rectify before a real failure scenario.
      * Scale horizontally to increase aggregate workload availability - Replace one large resource with multiple, smaller resources and distribute requests across these smaller resources to reduce the impact of a single point of failure on the overall system.
      * Stop guessing capacity - Monitor demand and system usage, and automate the addition or removal of resources to maintain the optimal level for satisfying demand.
      * Manage change in automation - Use automation to make changes to infrastructure and manage changes in automation.

   * Best practice areas:
      * Foundations
      * Workload architecture
      * Change management
      * Failure management 

To achieve reliability, a system must have both a well-planned foundation and monitoring in place. It must have mechanisms for handling changes in demand or requirements. The system should be designed to detect failure and automatically heal itself.

[Reliability Pillar Whitepaper](https://d1.awsstatic.com/whitepapers/architecture/AWS-Reliability-Pillar.pdf)

## Performance Efficiency
* Focus: Use IT and computing resources efficiently to meet system requirements and to maintain that efficiency as demand changes and technologies evolve.

   * Key topics:
      * Selecting the right resource types and sizes based on workload requirements
      * Monitoring performance
      * Making informed decisions to maintain efficiency as business needs evolve

   * Design principles:
      * Democratize advanced technologies–Consume technologies as a service. For example, technologies such as NoSQL databases, media transcoding, and machine learning require expertise that is not evenly dispersed across the technical community. In the cloud, these technologies become services that teams can consume. Consuming technologies enables teams to focus on product development instead of resource provisioning and management.
      * Go global in minutes–Deploy systems in multiple AWS Regions to provide lower latency and a better customer experience at minimal cost.
      * Use serverless architectures–Serverless architectures remove the operational burden of running and maintaining servers to carry out traditional compute activities. Serverless architectures can also lower transactional costs because managed services operate at cloud scale.
      * Experiment more often–Perform comparative testing of different types of instances, storage, or configurations.
      * Consider mechanical sympathy–Use the technology approach that aligns best to what you are trying to achieve. For example, consider your data access patterns when you select approaches for databases or storage.

   * Best practice areas:
      * Selection
      * Review
      * Monitoring
      * Tradeoffs 

Use data to design and build a high-performance architecture. Gather data on all aspects of the architecture, from the high-level design to the selection and configuration of resource types. Review your choices periodically to ensure that you are taking advantage of new AWS services. Perform monitoring so that you are aware of any deviance from expected performance and can take prompt action to remediatethem. Finally, use tradeoffs in your architecture to improve performance, such as using compression, using caching, or relaxing consistency requirements.

[Performance Efficiency Pillar Whitepaper](https://d1.awsstatic.com/whitepapers/architecture/AWS-Performance-Efficiency-Pillar.pdf)

## Cost Optimization
   * Focus: Avoid unnecessary costs

   * Key topics:
      * Understanding and controlling where money is being spent
      * Selecting the most appropriate and right number of resource types
      * Analyzing spend over time
      * Scaling to meeting business needs without overspending

   * Design principles:
      * Implement Cloud Financial Management–To achieve financial success and accelerate business value realization in the cloud, you need to invest in cloud financial management and cost optimization. You need to build capability through knowledge building, programs, resources, and processes to become a cost-efficient organization.
      * Adopt a consumption model–Pay only for the computing resources that you require. Increase or decrease usage depending on business requirements, not by using elaborate forecasting.
      * Measure overall efficiency–Measure the business output of the workload and the costs that are associated with delivering it. Use this measure to know the gains that you make from increasing output and reducing costs.
      * Stop spending money on undifferentiated heavy lifting –AWS does the heavy lifting of racking, stacking, and powering servers, which meansthat you can focus on your customers and business projects instead of the IT infrastructure.
      * Analyze and attribute expenditure–The cloud makes it easier to accurately identify system usage and costs, and attribute IT costs to individual workload owners. Having this capability helps you measure return on investment (ROI) and gives workload owners an opportunity to optimize their resources and reduce costs.

   * Best practice areas:
      * Practice cloud financial management
      * Expenditure and usage awareness
      * Cost-effective resources
      * Manage demand and supply resources
      * Optimize over time 

Similar to the other pillars, there are tradeoffs to consider when evaluating cost. For example, you may choose to prioritize for speed—going to market quickly, shipping new features, or simply meeting a deadline—instead of investing in upfront cost optimization. As another example, designing an application for a higher level of availability typically costs more. You should identify your true application needs and use empirical data to inform your architectural design decisions. Perform benchmarking to establish the most cost-optimal workload over time.

[Cost Optimization Pillar Whitepaper](https://d1.awsstatic.com/whitepapers/architecture/AWS-Cost-Optimization-Pillar.pdf)

## Trusted Advisor
AWS Trusted Advisor is an online tool that provides you real time guidance to help you provision your resources following AWS best practices. Trusted Advisor checks help optimize your AWS infrastructure, improve security and performance, reduce your overall costs, and monitor service limits. Whether establishing new workflows, developing applications, or as part of ongoing improvement, take advantage of the recommendations provided by Trusted Advisor on a regular basis to help keep your solutions provisioned optimally.

* Provides best practice recommendations in five categories
   * Cost optimization
   * Fault tolerance
   * Performance
   * Service limits
   * Security
