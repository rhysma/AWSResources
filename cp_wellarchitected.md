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

* Security

* Reliability

* Performance Efficiency

* Cost Optimization
