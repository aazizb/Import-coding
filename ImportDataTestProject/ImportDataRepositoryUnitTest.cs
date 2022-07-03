using Repository;

namespace ImportDataTestProject
{
    public class RepositoryValidJsonFileShould
    {
        [Fact]
        public void RepositoryOutputJson()
        {
            //Arrange
            var expected = "{\n    \"products\": [\n        {\n            \"categories\": [\n                \"Customer Service\",\n                \"Call Center\"\n            ],\n            \"twitter\": \"@freshdesk\",\n            \"title\": \"Freshdesk\"\n        },\n        {\n            \"categories\": [\n                \"CRM\",\n                \"Sales Management\"\n            ],\n            \"title\": \"Zoho\"\n        }\n    ]\n}\n";
            //Act
            var result = ImportDataRepository.GetJsonProducts(expected);
            //Assert
            Assert.True(2 == result.Count);
        }
        [Fact]
        public void RepositoryOutputYaml()
        {
            //Arrange
            var expected = "---\n-\n  tags: \"Bugs & Issue Tracking,Development Tools\"\n  name: \"GitGHub\"\n  twitter: \"github\"\n-\n  tags: \"Instant Messaging & Chat,Web Collaboration,Productivity\"\n  name: \"Slack\"\n  twitter: \"slackhq\"\n-\n  tags: \"Project Management,Project Collaboration,Development Tools\"\n  name: \"JIRA Software\"\n  twitter: \"jira\"\n-\n  tags: \"HR, Accounting \"\n  name: \"Wharehouse\"\n  twitter: \"wharehouse\"";
            //Act
            var result = ImportDataRepository.GetYamlProducts(expected);
            //Assert
            Assert.True(4 == result.Count);
        }
    }
}