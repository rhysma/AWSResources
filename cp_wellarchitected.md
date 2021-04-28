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
     * Learn from all operational events and failures - Drive improvement through lessons learned from all operational events and failures. Share what is learned across teams and through the entire organization.AWS Academy Cloud FoundationsModule 9: Cloud Architecture© 2021 Amazon Web Services, Inc. or its affiliates. All rights reserved.22

  * Best practice areas:
     * Organization
     * Prepare
     * Operate
     * Evolve

Operations teams must understand business and customer needs so they can effectively and efficiently support business outcomes. Operations teams create and use procedures to respond to operational events and validate the effectiveness of procedures to support business needs. Operations teams collect metrics that are used to measure the achievement of desired business outcomes. As business context, business priorities, and customer needs, change over time, it’s important to design operations that evolve in response to change and to incorporate lessons learned through their performance.

[Operational Excellent Pillar Whitepaper](https://d1.awsstatic.com/whitepapers/architecture/AWS-Operational-Excellence-Pillar.pdf)

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
   * Focus: 

   * Key topics:
      * 


   * Design principles:


   * Best practice areas:

## Performance Efficiency
* Focus: 

   * Key topics:
      * 


   * Design principles:


   * Best practice areas:

## Cost Optimization
   * Focus: 

   * Key topics:
      * 


   * Design principles:


   * Best practice areas:
