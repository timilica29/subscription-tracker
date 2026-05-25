<h2>📋 Subscription Tracker</h2>
<p>Built this app to replace my Excel spreadsheet for tracking monthly subscriptions - showing costs, due dates and payment status in one place. First version of this app is a Console App as I wanted to apply the OOP concepts I've learnt. My goal is to gradually evolve it into a full-stack ASP.NET MVC web application as I continue learning and expanding its functionality.</p>
<br>
<h3>✅ Features</h3><hr>
<ul>
  <li>Add monthly or yearly subscriptions with name, price and due date</li>
  <li>View all active subscriptions with status</li>
  <li>Mark subscriptions as paid</li>
  <li>Delete subscriptions with confirmation</li>
  <li>Calculate total monthly or yearly cost automatically</li>
  <li>Duplicate subscription prevention</li>
</ul>
<br>
<h3>🛠 Tech stack</h3><hr>
<ul>
  <li>C#/.NET 8</li>
  <li>Console application</li>
</ul>
<br>
<h3>🏗 Architecture & design decisions</h3><hr>
<ul>
  <li><strong>Domain/ UI Separation</strong> - Domain classes contain zero console output. All user interaction is handled by SubscriptionMenu, keeping business logic reusable when the web layer is added.</li>
  <li><strong>Abstract Subscription with polymorphism</strong> - MonthlySubscription and YearlySubscription each implement CalculateCost() differently. User.CalculateTotalCost() calls the method without knowing which type it's dealing with.</li>
  <li><strong>Composition over flat classes</strong> - Price is a separate class with its own Currency enum rather than a plain decimal, making multi-currency support straightforward to extend.</li>
  <li><strong>Single responsibility throughout</strong> - Each class owns one concern. Validation, data access, and display are deliberately separated in preparation for the service and repository layers in the MVC version.</li>
</ul>
<br>
<h5>📁 Project Structure</h5>
<pre>
SubscriptionTracker.ConsoleApp/
├── Domain/
│   ├── Enums/
│   │   ├── Currency.cs
│   │   └── SubscriptionStatus.cs
│   │
│   ├── SubscriptionManagement/
│   │   ├── Subscription.cs
│   │   ├── MonthlySubscription.cs
│   │   └── YearlySubscription.cs
│   │
│   ├── Price.cs
│   ├── SubscriptionType.cs
│   └── User.cs
│
├── Program.cs
└── SubscriptionMenu.cs
</pre>
<br>
<h3>🗺 Roadmap</h3><hr>
<ul>
  <li>Console app with full CRUD - complete 🟢</li>
  <li>ASP.NET MVC web interface with calendar UI</li>
  <li>Entity Framework Core + SQL Server</li>
  <li>User authentication with ASP.NET Identity</li>
  <li>Automatic payment status update based on due date</li>
  <li>Monthly spending overview and upcoming payments</li>
</ul>
<br>
<h3>🚀 How to run</h3><hr>
<h5>PREREQUISITES</h5>
<strong>.NET 8 SDK installed</strong>
<h5>Steps</h5>
<ol>
  <li>git clone https://github.com/timilica29/subscription-tracker.git</li>
  <li>cd subscription-tracker/SubscriptionTracker.ConsoleApp</li>
  <li>dotnet run</li>
</ol>
<br>
<h3>👤 Author</h3>
<p>Timotei Daniel Gubernu - <a href="https://www.linkedin.com/in/timotei-daniel-gubernu-330577172/">LinkedIn</a></p>
