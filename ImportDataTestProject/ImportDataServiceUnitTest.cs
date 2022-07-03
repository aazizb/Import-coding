using Service;

namespace ImportDataTestProject
{
    public class ServiceValidJsonFileShould
    {
        [Fact]
        public void ServiceOutputJson()
        {
            //Arrange
            var expected = "{\n    \"products\": [\n        {\n            \"categories\": [\n                \"Customer Service\",\n                \"Call Center\"\n            ],\n            \"twitter\": \"@freshdesk\",\n            \"title\": \"Freshdesk\"\n        },\n        {\n            \"categories\": [\n                \"CRM\",\n                \"Sales Management\"\n            ],\n            \"title\": \"Zoho\"\n        }\n    ]\n}\n";
            //Act
            var result = ImportDataService.GetJsonProducts(expected);
            //Assert
            Assert.True(2 == result.Count);
        }
        [Fact]
        public void ServiceOutputYaml()
        {
            //Arrange
            var expected = "---\n-\n  tags: \"Bugs & Issue Tracking,Development Tools\"\n  name: \"GitGHub\"\n  twitter: \"github\"\n-\n  tags: \"Instant Messaging & Chat,Web Collaboration,Productivity\"\n  name: \"Slack\"\n  twitter: \"slackhq\"\n-\n  tags: \"Project Management,Project Collaboration,Development Tools\"\n  name: \"JIRA Software\"\n  twitter: \"jira\"\n-\n  tags: \"HR, Accounting \"\n  name: \"Wharehouse\"\n  twitter: \"wharehouse\"";
            //Act
            var result = ImportDataService.GetYamlProducts(expected);
            //Assert
            Assert.True(4 == result.Count);
        }
    }
}
