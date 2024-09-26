Project Structure

├── Features

│   ├── YourFeature.feature          # Feature files

│   └── YourFeatureSteps.cs          # Step definitions

├── Hooks

│   └── Hooks.cs                     # Hooks for SpecFlow and Extent Reports

├── Drivers

│   └── Driver.cs                    # Custom driver for Playwright

├── Reports

│   └── ExtentReport.cs              # Extent Reports setup

├── Tests

│   └── SampleTest.cs                # Sample test file

├── ProjectName.csproj               # Project file

└── README.md                        # This README file

Dependencies

The following dependencies are included in the project:

ExtentReports: For generating detailed test reports.

Microsoft.NET.Test.Sdk: Required for running tests.

Microsoft.Playwright: For browser automation.

SpecFlow.Plus.LivingDocPlugin: For generating living documentation from SpecFlow features.

SpecFlow.NUnit: To integrate SpecFlow with NUnit testing framework.

nunit: The testing framework used in the project.

NUnit3TestAdapter: Adapter for running NUnit tests.

FluentAssertions: For writing assertions in a more readable way.


<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net6.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings</ImplicitUsings>
  </PropertyGroup>

  <ItemGroup>
    <SpecFlowObsoleteCodeBehindFiles Remove="Features\GoogleModel.feature.cs" />
    <SpecFlowObsoleteCodeBehindFiles Remove="Features\GoogleTwoModel.feature.cs" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include="ExtentReports" Version="5.0.4" />
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.11.1" />
    <PackageReference Include="Microsoft.Playwright" Version="1.47.0" />
    <PackageReference Include="SpecFlow.Plus.LivingDocPlugin" Version="3.9.57" />
    <PackageReference Include="SpecFlow.NUnit" Version="3.9.74" />
    <PackageReference Include="nunit" Version="4.2.2" />
    <PackageReference Include="NUnit3TestAdapter" Version="4.6.0" />
    <PackageReference Include="FluentAssertions" Version="6.12.1" />
  </ItemGroup>

</Project>

Generating Reports
Extent Reports will be generated automatically after each test run. You can find the reports in the TestResults directory. Open ExtentReport.html in a web browser to view the results.

Installation

To generate Living Documentation reports, you'll need to install the SpecFlow LivingDoc CLI tool. You can do this using the following command:

dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI

Executing LivingDoc

After running your tests and generating the required files, you can create LivingDoc reports by executing the following command. Navigate to your project’s output directory where the test assembly and TestExecution.json files are located (typically bin/Debug/net6.0):

1. Open your command prompt or terminal.

2. Navigate to the output directory:

cd path\to\your\project\bin\Debug\net6.0

3. Execute the LivingDoc command:

livingdoc test-assembly [projectName.dll] -t [TestExecution.json]

Replace [projectName.dll] with the actual name of your project’s DLL file and [TestExecution.json] with the name of the JSON file generated during your test execution.
