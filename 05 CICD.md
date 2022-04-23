# CICD Pipelines

Definition: CICD stands for Continuous Integration/Continuous Delivery. It is the strategy of regularly merging in new code and deploying it. Some teams will take this to the point of merging and deploying code multiple times a day.

CD is sometimes refered to as Continuous Deployment to indicate that the changes will be regularly pushed to production.

## Why Do CI/CD?

In my personal opinion, CI should be considered best practice in modern software dev, and CD should be built up along as the project grows.

### Continuos Integration

As a team grows, the number of people working on the same parts of the code increases. This leads to what is known as "integration hell" where significant resources have to be dedicated to fixing bugs and merge conflicts that are created by devs making changes to the same chunk of code.

When you diagram out the git tree it looks some thing like this. With your main (or dev) branch being regularly merged into your main (or dev) branch and vice versa.

![Git tree diagram](./Images/CICDGitBranching.png)

This won't completely prevent conflict, but these regular merges will ensure that the issues are small and much easier to deal with.

### Continuous Delivery

CD does a couple things. The timing of these three things can vary, but all should occur on a regular basis.

1. It automates the testing process so that testing isn't forgotten or fails due to the "it works on my machine" problem. This can include things like verifying that the code has sufficient test coverage. It is common practice to run at least some part of the test suite every time code is merged into the main branch.

2. It automates the deployment process so that it is done consistently with minimal downtime. This can include running the full test suite if merges only trigger a portion, deploying to a subset of servers at a time, and even automatic rollback if issues are detected post deployment.

3. Regular deployments shortens the communication line between dev and operations teams as well as between devs and the users. Similar to CI, instead of a long list of changes, users are given a constant stream of small changes that are easier to adapt to and they can quickly give feedback when requirements need to be adjusted.

## CICD Tools

Repository sites like GitHub and GitLab often include CD tools as part of their offerings. You can also use stand-alone tools like Jenkins, OctupusDeploy, or TeamCity along with any sort of repository management. Stand-alone tools are often used when business requirements mean that you can't store code externally.

For today, we'll use GitHub Actions to setup a pipeline that can handle things like running tests whenever we merge changes.
